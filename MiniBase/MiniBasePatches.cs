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
using HarmonyLib;
using ProcGen;
using ProcGenGame;
using PeterHan.PLib.Options;
using System.Linq;
using static MiniBase.MiniBaseConfig;
using static MiniBase.MiniBaseUtils;
using UnityEngine;
using System.IO;

namespace MiniBase
{
    public class MiniBasePatches : KMod.UserMod2
    {
        public static string ModPath;

        public override void OnLoad(Harmony harmony)
        {
            MiniBaseOptions.Reload();
            new POptions().RegisterOptions(this, typeof(MiniBaseOptions));
            ModPath = mod.ContentPath;
            base.OnLoad(harmony);

            Log($"MiniBase loaded.", true);
        }

        // Reload mod options at asteroid select screen, before world gen happens
        [HarmonyPatch(typeof(ColonyDestinationSelectScreen), "LaunchClicked")]
        public static class ColonyDestinationSelectScreen_LaunchClicked_Patch
        {
            public static void Prefix()
            {
                Log("ColonyDestinationSelectScreen_LaunchClicked_Patch Prefix");
                MiniBaseOptions.Reload();
            }
        }

        // Reload mod options when game is reloaded from save
        [HarmonyPatch(typeof(Game), "OnPrefabInit")]
        public static class Game_OnPrefabInit_Patch
        {
            public static void Prefix()
            {
                Log("Game_OnPrefabInit_Patch Prefix");
                MiniBaseOptions.Reload();
            }
        }

        // Reveal map on startup
        [HarmonyPatch(typeof(MinionSelectScreen), "OnProceed")]
        public static class MinionSelectScreen_OnProceed_Patch
        {
            public static void Postfix()
            {
                if (!IsMiniBase())
                    return;
                Log("MinionSelectScreen_OnProceed_Patch Postfix");
                int radius = (int) (Math.Max(Grid.WidthInCells, Grid.HeightInCells) * 1.5f);
                GridVisibility.Reveal(0, 0, radius, radius - 1);
            }
        }

        #region CarePackages

        // Immigration Speed
        [HarmonyPatch(typeof(Game), "OnSpawn")]
        public static class Game_OnSpawn_Patch
        {
            public static void Postfix()
            {
                Log("Game_OnSpawn_Patch Postfix");
                if (IsMiniBase())
                {
                    var immigration = Immigration.Instance;
                    const float SecondsPerDay = 600f;
                    float frequency = MiniBaseOptions.Instance.FastImmigration ? 10f : MiniBaseOptions.Instance.CarePackageFrequency * SecondsPerDay;
                    immigration.spawnInterval = new float[] { frequency, frequency };
                    immigration.timeBeforeSpawn = Math.Min(frequency, immigration.timeBeforeSpawn);
                }
            }
        }
        
        // Add care package drops
        [HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            public static void Postfix(ref CarePackageInfo[]  ___carePackages)
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
                AddElement(SimHashes.ChlorineGas, 50f);
                AddElement(SimHashes.Methane, 50f, 24);
                // Plants
                AddItem("BasicSingleHarvestPlantSeed", 4f);             // Mealwood
                AddItem("SeaLettuceSeed", 3f);                          // Waterweed
                AddItem("SaltPlantSeed", 3f);                           // Dasha Saltvine
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

        #endregion

        #region WorldGen

        // Add minibase asteroid cluster
        [HarmonyPatch(typeof(Db), "Initialize")]
        public class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                Log("Db_Initialize_Patch Prefix");
                Strings.Add($"STRINGS.WORLDS.{ClusterName.ToUpperInvariant()}.NAME", ClusterName);
                Strings.Add($"STRINGS.WORLDS.{ClusterName.ToUpperInvariant()}.DESCRIPTION", ClusterDescription);
                
                string spritePath = System.IO.Path.Combine(ModPath, ClusterIconName) + ".png";
                Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                ImageConversion.LoadImage(texture, File.ReadAllBytes(spritePath));
                Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, 512f, 512f), Vector2.zero);
                Assets.Sprites.Add(ClusterIconName, sprite);
            }
        }

        // Change minibase world size
        [HarmonyPatch(typeof(Worlds), "UpdateWorldCache")]
        public static class Worlds_UpdateWorldCache_Patch
        {
            public static void Postfix(Worlds __instance)
            {
                Log("Worlds_UpdateWorldCache_Patch Postfix");
                var world = __instance.worldCache["worlds/" + ClusterName];
                Traverse.Create(world).Property("worldsize").SetValue(new Vector2I(WORLD_WIDTH, WORLD_HEIGHT));
            }
        }

        // Bypass and rewrite world generation
        [HarmonyPatch(typeof(WorldGen), "RenderOffline")]
        public static class WorldGen_RenderOffline_Patch
        {
            public static bool Prefix()
            {
                Log("WorldGen_RenderOffline_Patch Prefix");
                // Skip the original method if on minibase world
                return !IsMiniBase();
            }

            public static void Postfix(WorldGen __instance, ref bool __result, ref Sim.Cell[] cells, ref Sim.DiseaseCell[] dc, int baseId)
            {
                if (!IsMiniBase())
                    return;
                Log("WorldGen_RenderOffline_Patch Postfix");
                __result = MiniBaseWorldGen.CreateWorld(__instance, ref cells, ref dc, baseId);
            }
        }

        #endregion

        #region Debug

        // test
        /*
        [HarmonyPatch(typeof(WorldGen), "GenerateLayout")]
        public static class WorldGen_GenerateLayout_Patch
        {
            public static bool Prefix()
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
