/*
	MIT License

	Copyright (c) 2020 Steven Brelsford (Versepelles)

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
*/
 
using System;
using Harmony;
using ProcGen;
using ProcGenGame;
using PeterHan.PLib.Options;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using static MiniBase.MiniBaseConfig;
using static MiniBase.MiniBaseDebugUtils;

namespace MiniBase
{
    public class MiniBasePatches
    {
        public static class Mod_OnLoad
        {
            public static void OnLoad()
            {
                Log("TinyWorld loaded.");
                POptions.RegisterOptions(typeof(MiniBaseOptions));

                // Noisemap test
                if (TEST_NOISEMAPS)
                    TestNoiseMaps();
            }
        }

        // Change world size
        [HarmonyPatch(typeof(Worlds), "UpdateWorldCache")]
        public static class Worlds_UpdateWorldCache_Patch
        {
            private static void Postfix(Worlds __instance)
            {
                Log("Worlds_UpdateWorldCache_Patch Postfix");
                foreach (ProcGen.World world in __instance.worldCache.Values)
                    Traverse.Create(world).Property("worldsize").SetValue(new Vector2I(WORLD_WIDTH, WORLD_HEIGHT));
            }
        }

        // Reload mod options at asteroid select screen, before world gen happens
        [HarmonyPatch(typeof(ColonyDestinationSelectScreen), "LaunchClicked")]
        public static class ColonyDestinationSelectScreen_LaunchClicked_Patch
        {
            private static void Prefix()
            {
                Log("ColonyDestinationSelectScreen_LaunchClicked_Patch Prefix");
                MiniBaseOptions.Reload();
            }
        }

        // Reload mod options when game is reloaded from save
        [HarmonyPatch(typeof(Game), "OnSpawn")]
        public static class Game_OnLoadLevel_Patch
        {
            private static void Prefix()
            {
                Log("Game_OnSpawn_Patch Prefix");
                MiniBaseOptions.Reload();
            }
        }

        // Reveal map on startup
        [HarmonyPatch(typeof(MinionSelectScreen), "OnProceed")]
        public static class MinionSelectScreen_OnProceed_Patch
        {
            private static void Postfix()
            {
                Log("MinionSelectScreen_OnProceed_Patch Postfix");
                float radius = Math.Max(Grid.WidthInCells, Grid.HeightInCells) * 1.5f;
                GridVisibility.Reveal(0, 0, radius, radius - 1);
            }
        }

        // Disable Steam Turbine
        // TODO: convert to tech tree option
        [HarmonyPatch(typeof(PlanScreen), "PopulateOrderInfo")]
        public static class PlanScreen_PopulateOrderInfo_Patch
        {
            private static void Prefix(HashedString category, ref object data)
            {
                if((category == new HashedString("Power")) && (data.GetType() != typeof(PlanScreen.PlanInfo)))
                {
                    Log("PlanScreen_PopulateOrderInfo_Patch Prefix");
                    var list = new List<string>((List<string>) data); // Shallow copy
                    string SteamTurbine = "SteamTurbine2";
                    if (MiniBaseOptions.Instance.TurbinesDisabled && list.Contains(SteamTurbine))
                    {
                        list.Remove(SteamTurbine);
                        data = list;
                    }
                }
            }
        }

        #region CarePackages

        // Immigration speed
        [HarmonyPatch(typeof(Immigration), "OnPrefabInit")]
        public static class Immigration_OnPrefabInit_Patch
        {
            private static void Prefix(Immigration __instance)
            {
                Log("Immigration_OnPrefabInit_Patch Prefix");
                float frequency = MiniBaseOptions.Instance.CarePackageFrequency * 600f;
                __instance.spawnInterval = new float[] { frequency, frequency };
                if (FAST_IMMIGRATION)
                    __instance.spawnInterval = new float[] { 10f, 5f };
            }
        }
        
        // Immigration speed
        [HarmonyPatch(typeof(Immigration), "OnSpawn")]
        public static class Immigration_OnSpawn_Patch
        {
            private static void Postfix(Immigration __instance)
            {
                if (__instance.GetType() == typeof(Immigration))
                {
                    Log("Immigration_OnSpawn_Patch Postfix");
                    float frequency = MiniBaseOptions.Instance.CarePackageFrequency * 600f;
                    __instance.timeBeforeSpawn = Math.Min(frequency, __instance.timeBeforeSpawn);
                }
            }
        }

        // Add care package drops
        [HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            private static void Postfix(Immigration __instance)
            {
                Log("Immigration_ConfigureCarePackages_Patch Postfix");

                var carePackagesField = Traverse.Create(__instance).Field("carePackages");
                var infoArray = carePackagesField.GetValue<CarePackageInfo[]>();

                // Remove the "discovered" requirement for these materials
                var RemoveConditionPackages = new List<string>
                {
                    "Cuprite",
                    "GoldAmalgam",
                    "Copper",
                    "Iron",
                    "Ethanol",
                    "AluminumOre",
                };

                for (int i = 0; i < infoArray.Length; i ++)
                {
                    var info = infoArray[i];
                    if (RemoveConditionPackages.Contains(info.id))
                        infoArray[i] = new CarePackageInfo(info.id, info.quantity, () => GameClock.Instance.GetCycle() >= 32);
                }

                // Add new care packages
                var infoList = infoArray.ToList();

                void AddElement(SimHashes element, float amount, int cycle = -1) { AddItem(ElementLoader.FindElementByHash(element).tag.ToString(), amount, cycle); }
                void AddItem(string name, float amount, int cycle = -1) { infoList.Add(new CarePackageInfo(name, amount, cycle < 0 ? null : (Func<bool>) (() => CycleCondition(cycle)))); }

                // Minerals
                AddElement(SimHashes.Granite, 2000f);
                AddElement(SimHashes.IgneousRock, 2000f);
                AddElement(SimHashes.Obsidian, 2000f, 24);
                AddElement(SimHashes.Salt, 2000f);
                AddElement(SimHashes.BleachStone, 2000f, 12);
                AddElement(SimHashes.Fossil, 1000f, 24);
                // Metals
                AddElement(SimHashes.IronOre, 1000f);
                AddElement(SimHashes.FoolsGold, 1000f, 12);
                AddElement(SimHashes.Wolframite, 1000f, 24);
                AddElement(SimHashes.Lead, 2000f, 24);
                // Liquids
                AddElement(SimHashes.DirtyWater, 2000f, 12);
                AddElement(SimHashes.CrudeOil, 2000f, 12);
                AddElement(SimHashes.Petroleum, 2000f, 48);
                // Gases
                AddElement(SimHashes.ChlorineGas, 2000f);
                AddElement(SimHashes.Methane, 2000f, 24);
                // Plants
                AddItem("BasicSingleHarvestPlantSeed", 3f);             // Mealwood
                AddItem("SeaLettuceSeed", 3f);                          // Waterweed
                AddItem("BeanPlantSeed", 3f);                           // Nosh Bean
                AddItem("SaltPlantSeed", 3f);                           // Dasha Saltvine
                AddItem("PrickleGrassSeed", 3f);                        // Bluff Briar
                AddItem("BulbPlantSeed", 3f);                           // Buddy Bud
                AddItem("ColdWheatSeed", 3f);                           // Sleet Wheat      TODO: solve invisible sleetwheat / nosh bean
                AddItem("GasGrassSeed", 3f, 36);                        // Gas Grass
                AddItem("EvilFlowerSeed", 1f, 36);                      // Sporechid
                // Critters
                AddItem("PacuEgg", 3f);                                 // Pacu
                AddItem("Glom", 1f, 24);                                // Morb
                AddItem("Moo", 1f, 48);                                 // Gassy Moo

                carePackagesField.SetValue(infoList.ToArray());
            }

            private static bool CycleCondition(int cycle) { return GameClock.Instance.GetCycle() >= cycle; }
        }

        // This code was edited and used with permission from asquared31415 and is subject to their licenses and rights
        // The complete unedited code and project can be found at https://github.com/asquared31415/ONI-Mods/tree/dev/src/ConfigurablePrintingPod
        [HarmonyPatch(typeof(CharacterSelectionController), "InitializeContainers")]
        public class CharacterSelectionControler_InitializeContainers_Patches
        {
            private static readonly FieldInfo TargetPackageOptions = AccessTools.Field(
                typeof(CharacterSelectionController),
                "numberOfCarePackageOptions"
            );

            private static readonly FieldInfo TargetDupeOptions = AccessTools.Field(
                typeof(CharacterSelectionController),
                "numberOfDuplicantOptions"
            );

            private static readonly MethodInfo PackageCount = AccessTools.Method(
                typeof(CharacterSelectionControler_InitializeContainers_Patches),
                nameof(GetRandomPackageCount)
            );

            private static readonly MethodInfo DupeCount = AccessTools.Method(
                typeof(CharacterSelectionControler_InitializeContainers_Patches),
                nameof(GetRandomDuplicantCount)
            );

            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> orig)
            {
                var codes = orig.ToList();

                var label = new Label();
                for (var i = 0; i < codes.Count; ++i)
                {
                    // Store label for the else branch
                    if (codes[i].operand as string == "Enabled")
                    {
                        label = (Label) codes[i + 2].operand;
                    }

                    // the br.s is what goes to the end of the if...else
                    // Despite the fact that the IL viewer claims it's a br.s, it's a br???
                    if (codes[i].opcode == OpCodes.Br)
                    {
                        // ... so we start at the next instruction
                        i++;
                        // Search for and remove both stores
                        var first = codes.FindIndex(i, ci => ci.opcode == OpCodes.Stfld);
                        var finalIndex = codes.FindIndex(first + 1, ci => ci.opcode == OpCodes.Stfld);
                        if (finalIndex != -1)
                        {
                            codes.RemoveRange(i, finalIndex - i + 1);

                            // Then start adding our code
                            // We call helpers to GREATLY simplify the IL
                            // First get packages, then dupes
                            codes.Insert(i++, new CodeInstruction(OpCodes.Ldarg_0) { labels = new List<Label> { label } });
                            codes.Insert(i++, new CodeInstruction(OpCodes.Call, PackageCount));
                            codes.Insert(i++, new CodeInstruction(OpCodes.Stfld, TargetPackageOptions));

                            codes.Insert(i++, new CodeInstruction(OpCodes.Ldarg_0));
                            codes.Insert(i++, new CodeInstruction(OpCodes.Call, DupeCount));
                            codes.Insert(i, new CodeInstruction(OpCodes.Stfld, TargetDupeOptions));
                        }
                        else
                        {
                            Debug.LogError("[ConfigurablePrintingPod] Could not patch InitializeContainers: Index");
                        }

                        return codes;
                    }
                }

                Debug.LogError("[ConfigurablePrintingPod] Something went really wrong!");
                return codes;
            }

            private static int GetRandomPackageCount() { return 3; }
            private static int GetRandomDuplicantCount() { return 1; }
        }

        #endregion

        #region WorldGen

        // Bypass and rewrite world generation
        [HarmonyPatch(typeof(WorldGen), "RenderOffline")]
        public static class WorldGen_RenderOffline_Patch
        {
            private static bool Prefix()
            {
                Log("WorldGen_RenderOffline_Patch Prefix");
                // Skip the original method
                return false;
            }

            private static void Postfix(WorldGen __instance, Sim.Cell[] __result, ref Sim.DiseaseCell[] dc)
            {
                Log("WorldGen_RenderOffline_Patch Postfix");
                __result = MiniBaseWorldGen.CreateWorld(__instance, ref dc);
            }
        }

        #endregion
    }
}
