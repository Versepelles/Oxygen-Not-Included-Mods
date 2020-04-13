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
                if (DEBUG_MODE)
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

        // Reload mod options
        [HarmonyPatch(typeof(ColonyDestinationSelectScreen), "LaunchClicked")]
        public static class ColonyDestinationSelectScreen_LaunchClicked_Patch
        {
            private static void Prefix()
            {
                Log("ColonyDestinationSelectScreen_LaunchClicked_Patch Prefix");
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
        // TODO: remove steam turbine icon from build menu
        [HarmonyPatch(typeof(PlanScreen), "BuildableState")]
        public static class PlanScreen_BuildableState_Patch
        {
            private static void Postfix(BuildingDef def, ref PlanScreen.RequirementsState __result)
            {
                if (MiniBaseOptions.Instance.TurbinesDisabled && def.name == "SteamTurbine2")
                    __result = PlanScreen.RequirementsState.Tech;
            }
        }

        #region CarePackages

        // Fast immigration
        // TODO: remove
        [HarmonyPatch(typeof(Immigration), "OnPrefabInit")]
        public static class Immigration_OnPrefabInit_Patch
        {
            private static void Prefix(Immigration __instance)
            {
                Log("Immigration_OnPrefabInit_Patch Prefix");
                if(DEBUG_MODE)
                    __instance.spawnInterval = new float[] { 10f, 5f };
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

                // Minerals
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Granite).tag.ToString(), 2000f, null));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.IgneousRock).tag.ToString(), 2000f, null));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Obsidian).tag.ToString(), 2000f, () => CycleCondition(24)));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Salt).tag.ToString(), 2000f, null));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.BleachStone).tag.ToString(), 2000f, () => CycleCondition(12)));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Fossil).tag.ToString(), 1000f, () => CycleCondition(24)));
                // Metals
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.IronOre).tag.ToString(), 1000f, null));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.FoolsGold).tag.ToString(), 1000f, () => CycleCondition(12)));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Wolframite).tag.ToString(), 1000f, () => CycleCondition(24)));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Lead).tag.ToString(), 2000f, () => CycleCondition(24)));
                // Liquids
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.DirtyWater).tag.ToString(), 2000f, () => CycleCondition(12)));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.CrudeOil).tag.ToString(), 2000f, () => CycleCondition(24)));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Petroleum).tag.ToString(), 2000f, () => CycleCondition(48)));
                // Gases
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.ChlorineGas).tag.ToString(), 2000f, null));
                infoList.Add(new CarePackageInfo(ElementLoader.FindElementByHash(SimHashes.Methane).tag.ToString(), 2000f, () => CycleCondition(24)));
                // Plants
                infoList.Add(new CarePackageInfo("BasicSingleHarvestPlantSeed", 3f, null));             // Mealwood
                infoList.Add(new CarePackageInfo("SeaLettuceSeed", 3f, null));                          // Waterweed
                infoList.Add(new CarePackageInfo("BeanPlantSeed", 3f, null));                           // Nosh Bean
                infoList.Add(new CarePackageInfo("SaltPlantSeed", 3f, null));                           // Dasha Saltvine
                infoList.Add(new CarePackageInfo("PrickleGrassSeed", 3f, null));                        // Bluff Briar
                infoList.Add(new CarePackageInfo("BulbPlantSeed", 3f, null));                           // Buddy Bud
                infoList.Add(new CarePackageInfo("ColdWheatSeed", 3f, null));                           // Sleet Wheat      TODO: solve invisible sleetwheat / nosh bean
                infoList.Add(new CarePackageInfo("GasGrassSeed", 3f, () => CycleCondition(36)));        // Gas Grass
                infoList.Add(new CarePackageInfo("EvilFlowerSeed", 1f, () => CycleCondition(36)));      // Sporechid
                // Critters
                infoList.Add(new CarePackageInfo("PacuEgg", 3f, null));                                 // Pacu
                infoList.Add(new CarePackageInfo("Glom", 1f, () => CycleCondition(24)));                // Morb
                infoList.Add(new CarePackageInfo("Moo", 1f, () => CycleCondition(48)));                 // Gassy Moo

                carePackagesField.SetValue(infoList.ToArray());
            }

            private static bool CycleCondition(int cycle) { return GameClock.Instance.GetCycle() >= cycle; }
        }

        // This code was edited and used with permission from asquared31415 and is subject to their licenses and rights
        // The complete unedited code and prject can be found at https://github.com/asquared31415/ONI-Mods/tree/dev/src/ConfigurablePrintingPod
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
