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
using static MiniBase.MiniBaseUtils;
using UnityEngine;
using System.IO;

namespace MiniBase
{
    public class MiniBasePatches
    {
        public static string ModPath;

        public static class Mod_OnLoad
        {
            public static void OnLoad(string modPath)
            {
                Log($"MiniBase loaded.", true);
                ModPath = modPath;
                POptions.RegisterOptions(typeof(MiniBaseOptions));
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
                if (!IsMiniBase())
                    return;
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
                if (!IsMiniBase())
                    return;
                if ((category == new HashedString("Power")) && (data.GetType() != typeof(PlanScreen.PlanInfo)))
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
                if (MiniBaseOptions.Instance.FastImmigration)
                {
                    __instance.spawnInterval = new float[] { 10f, 5f };
                    return;
                }
                if (!IsMiniBase())
                    return;
                Log("Immigration_OnPrefabInit_Patch Prefix");
                float frequency = MiniBaseOptions.Instance.CarePackageFrequency * 600f;
                __instance.spawnInterval = new float[] { frequency, frequency };
            }
        }
        
        // Immigration speed
        [HarmonyPatch(typeof(Immigration), "OnSpawn")]
        public static class Immigration_OnSpawn_Patch
        {
            private static void Postfix(Immigration __instance)
            {
                if (__instance.GetType() == typeof(Immigration) && IsMiniBase())
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
            private static void Postfix(Immigration __instance, ref CarePackageInfo[]  ___carePackages)
            {
                Log("Immigration_ConfigureCarePackages_Patch Postfix");
                if (!IsMiniBase())
                    return;

                // Add new care packages
                var packageList = ___carePackages.ToList();

                void AddElement(SimHashes element, float amount, int cycle = -1) { AddItem(ElementLoader.FindElementByHash(element).tag.ToString(), amount, cycle); }
                void AddItem(string name, float amount, int cycle = -1) { packageList.Add(new CarePackageInfo(name, amount, cycle < 0 ? IsMiniBase : (Func<bool>) (() => CycleCondition(cycle) && IsMiniBase()))); }

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
                AddElement(SimHashes.Wolframite, 500f, 24);
                AddElement(SimHashes.Lead, 1000f, 36);
                AddElement(SimHashes.AluminumOre, 500f, 24);
                // Liquids
                AddElement(SimHashes.DirtyWater, 2000f, 12);
                AddElement(SimHashes.CrudeOil, 1000f, 24);
                AddElement(SimHashes.Petroleum, 1000f, 48);
                // Gases
                AddElement(SimHashes.ChlorineGas, 1000f);
                AddElement(SimHashes.Methane, 1000f, 24);
                // Plants
                AddItem("BasicSingleHarvestPlantSeed", 4f);             // Mealwood
                AddItem("SeaLettuceSeed", 3f);                          // Waterweed
                AddItem("SaltPlantSeed", 3f);                           // Dasha Saltvine
                AddItem("PrickleGrassSeed", 3f);                        // Bluff Briar
                AddItem("BulbPlantSeed", 3f);                           // Buddy Bud
                AddItem("ColdWheatSeed", 8f);                           // Sleet Wheat      TODO: solve invisible sleetwheat / nosh bean
                AddItem("BeanPlantSeed", 5f);                           // Nosh Bean
                AddItem("EvilFlowerSeed", 1f, 36);                      // Sporechid
                // Critters
                AddItem("PacuEgg", 3f);                                 // Pacu
                AddItem("Glom", 1f, 24);                                // Morb

                ___carePackages = packageList.ToArray();
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

            private static int GetRandomPackageCount()
            {
                Log("Care packages IsMiniBase: " + IsMiniBase());
                if(IsMiniBase())
                    return 3;
                return UnityEngine.Random.Range(0, 101) > 70 ? 2 : 1;
            }

            private static int GetRandomDuplicantCount(CharacterSelectionController instance)
            {
                Log("Duplicant packages IsMiniBase: " + IsMiniBase());
                if (IsMiniBase())
                    return 1;
                return 4 - ((int) TargetPackageOptions.GetValue(instance));
            }
        }

        #endregion

        #region WorldGen

        // Add minibase asteroid type
        [HarmonyPatch(typeof(Db), "Initialize")]
        public class Db_Initialize_Patch
        {
            public static string Name = "MiniBase";
            private static string Description = "An encapsulated location with just enough to get by.\n\n<smallcaps>Customize this location by clicking MiniBase Options in the Mods menu.</smallcaps>\n\n";
            private static string IconName = "Asteroid_minibase";

            public static void Prefix()
            {
                Log("Db_Initialize_Patch Prefix");
                Strings.Add($"STRINGS.WORLDS." + Name.ToUpperInvariant() + ".NAME", Name);
                Strings.Add($"STRINGS.WORLDS." + Name.ToUpperInvariant() + ".DESCRIPTION", Description);

                string spritePath = System.IO.Path.Combine(ModPath, IconName) + ".png";
                Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                ImageConversion.LoadImage(texture, File.ReadAllBytes(spritePath));
                Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, 512f, 512f), Vector2.zero);
                Assets.Sprites.Add(IconName, sprite);
            }
        }

        // Change minibase world size
        [HarmonyPatch(typeof(Worlds), "UpdateWorldCache")]
        public static class Worlds_UpdateWorldCache_Patch
        {
            private static void Postfix(Worlds __instance)
            {
                Log("Worlds_UpdateWorldCache_Patch Postfix");
                var world = __instance.worldCache["worlds/" + Db_Initialize_Patch.Name];
                Traverse.Create(world).Property("worldsize").SetValue(new Vector2I(WORLD_WIDTH, WORLD_HEIGHT));
            }
        }

        // Bypass and rewrite world generation
        [HarmonyPatch(typeof(WorldGen), "RenderOffline")]
        public static class WorldGen_RenderOffline_Patch
        {
            private static bool Prefix()
            {
                Log("WorldGen_RenderOffline_Patch Prefix");
                // Skip the original method
                return !IsMiniBase();
            }

            private static void Postfix(WorldGen __instance, Sim.Cell[] __result, ref Sim.DiseaseCell[] dc)
            {
                if (!IsMiniBase())
                    return;
                Log("WorldGen_RenderOffline_Patch Postfix");
                __result = MiniBaseWorldGen.CreateWorld(__instance, ref dc);
            }
        }

        #endregion

        #region Debug
        /*
        // test
        [HarmonyPatch(typeof(WorldGen), "GenerateLayout")]
        public static class WorldGen_GenerateLayout_Patch
        {
            private static bool Prefix()
            {
                Log("WorldGen_GenerateLayout_Patch Prefix");
                return false;
            }

            private static void Postfix(ref bool __result)
            {
                Log("WorldGen_GenerateLayout_Patch Postfix");
                __result = true;
            }
        }*/
        #endregion
    }
}
