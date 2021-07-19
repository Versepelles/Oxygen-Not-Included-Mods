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
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HarmonyLib;
using Klei;
using ProcGen;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	class SharlesPlantsPatches
	{
		public static Dictionary<string, PlantTuning> PlantDictionary;

		public class Mod_OnLoad : KMod.UserMod2
		{
			public override void OnLoad(Harmony harmony)
			{
				Log("Loading plants", true);

				PlantDictionary = new Dictionary<string, PlantTuning>()
				{
					{ PricklyLotusConfig.Id, PricklyLotusTuning },
					{ FrostBlossomConfig.Id, FrostBlossomTuning },
					{ IcyShroomConfig.Id, IcyShroomTuning },
					{ MyrthRoseConfig.Id, MyrthRoseTuning },
					{ RustFernConfig.Id, RustFernTuning },
					{ SporeLampConfig.Id, SporeLampTuning },
					{ TropicalgaeConfig.Id, TropicalgaeTuning },
					{ ShlurpCoralConfig.Id, ShlurpCoralTuning },
				};

				base.OnLoad(harmony);
			}
		}

		// Reveal map on startup (Debug only)
		[HarmonyPatch(typeof(MinionSelectScreen), "OnProceed")]
		public static class MinionSelectScreen_OnProceed_Patch
		{
			private static void Postfix()
			{
				Log("MinionSelectScreen_OnProceed_Patch Postfix");
				if (DebugMode)
				{
					int radius = (int) (Math.Max(Grid.WidthInCells, Grid.HeightInCells) * 1.5f);
					GridVisibility.Reveal(0, 0, radius, radius - 1);
				}
			}
		}

		// Waterweed drowning fix
		[HarmonyPatch(typeof(SeaLettuceConfig), "CreatePrefab")]
		public static class SeaLettuceConfig_CreatePrefab_Patch
		{
			private static void Postfix(GameObject __result)
			{
				Log("EntityTemplates_ExtendEntityToBasicPlant_Patch Postfix");
				var drowningMonitor = __result.GetComponent<DrowningMonitor>();
				if(drowningMonitor != null)
					drowningMonitor.enabled = false;
			}
		}

		// Register plants and seeds to the game
		[HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
		public static class EntityConfigManager_LoadGeneratedEntities_Patch
		{
			public static void Prefix()
			{
				Log("EntityConfigManager_LoadGeneratedEntities_Patch Prefix");

				RegisterPlant(PricklyLotusConfig.Id, PricklyLotusConfig.Name, PricklyLotusConfig.Description, PricklyLotusConfig.DomesticatedDescription);
				RegisterSeed(PricklyLotusConfig.SeedId, PricklyLotusConfig.SeedName, PricklyLotusConfig.SeedDescription);
				RegisterPlant(FrostBlossomConfig.Id, FrostBlossomConfig.Name, FrostBlossomConfig.Description, FrostBlossomConfig.DomesticatedDescription);
				RegisterSeed(FrostBlossomConfig.SeedId, FrostBlossomConfig.SeedName, FrostBlossomConfig.SeedDescription);
				RegisterPlant(IcyShroomConfig.Id, IcyShroomConfig.Name, IcyShroomConfig.Description, IcyShroomConfig.DomesticatedDescription);
				RegisterSeed(IcyShroomConfig.SeedId, IcyShroomConfig.SeedName, IcyShroomConfig.SeedDescription);
				RegisterPlant(MyrthRoseConfig.Id, MyrthRoseConfig.Name, MyrthRoseConfig.Description, MyrthRoseConfig.DomesticatedDescription);
				RegisterSeed(MyrthRoseConfig.SeedId, MyrthRoseConfig.SeedName, MyrthRoseConfig.SeedDescription);
				RegisterPlant(RustFernConfig.Id, RustFernConfig.Name, RustFernConfig.Description, RustFernConfig.DomesticatedDescription);
				RegisterSeed(RustFernConfig.SeedId, RustFernConfig.SeedName, RustFernConfig.SeedDescription);
				RegisterPlant(SporeLampConfig.Id, SporeLampConfig.Name, SporeLampConfig.Description, SporeLampConfig.DomesticatedDescription);
				RegisterSeed(SporeLampConfig.SeedId, SporeLampConfig.SeedName, SporeLampConfig.SeedDescription);
				RegisterPlant(TropicalgaeConfig.Id, TropicalgaeConfig.Name, TropicalgaeConfig.Description, TropicalgaeConfig.DomesticatedDescription);
				RegisterSeed(TropicalgaeConfig.SeedId, TropicalgaeConfig.SeedName, TropicalgaeConfig.SeedDescription);
				RegisterPlant(ShlurpCoralConfig.Id, ShlurpCoralConfig.Name, ShlurpCoralConfig.Description, ShlurpCoralConfig.DomesticatedDescription);
				RegisterSeed(ShlurpCoralConfig.SeedId, ShlurpCoralConfig.SeedName, ShlurpCoralConfig.SeedDescription);
			}
		}

		// Add plants to Mob Dictionary
		[HarmonyPatch(typeof(SettingsCache), "LoadFiles", new Type[] {typeof(string), typeof(string), typeof(List<YamlIO.Error>)})]
		public static class SettingsCache_LoadFiles_Patch
		{
			public static void Postfix()
			{
				Log("SettingsCache_LoadFiles_Patch Postfix");

				var mobs = SettingsCache.mobs.MobLookupTable;

				foreach (string plantName in PlantDictionary.Keys)
				{
					if (mobs.ContainsKey(plantName))
						continue;
					var tuning = PlantDictionary[plantName];
					Mob plant = new Mob(tuning.spawnLocation) { name = plantName };
					var p = Traverse.Create(plant);
					p.Property("width").SetValue(1);
					p.Property("height").SetValue(1);
					p.Property("density").SetValue(tuning.density);
					mobs.Add(plantName, plant);
				}
			}
		}

		// Add plants to Biome presets
		[HarmonyPatch(typeof(SettingsCache), "LoadSubworlds")]
		public static class SettingsCache_LoadSubworlds_Patch
		{
			public static void Postfix()
			{
				Log("SettingsCache_LoadSubworlds_Patch Postfix");

				foreach (var subworld in SettingsCache.subworlds.Values)
					foreach (var biome in subworld.biomes)
						foreach (string plantName in PlantDictionary.Keys)
							if (PlantDictionary[plantName].ValidBiome(subworld, biome.name)) 
							{
								if (biome.tags == null)
									Traverse.Create(biome).Property("tags").SetValue(new List<string>());
								biome.tags.Add(plantName);
							}
			}
		}

		// Add care package drops
		[HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
		public static class Immigration_ConfigureCarePackages_Patch
		{
			public static void Postfix(ref Immigration __instance)
			{
				Log("Immigration_ConfigureCarePackages_Patch Postfix");

				var field = Traverse.Create(__instance).Field("carePackages");
				var list = field.GetValue<CarePackageInfo[]>().ToList();

				list.Add(new CarePackageInfo("BulbPlantSeed", 3f, null)); // add Buddy Bud seeds
				list.Add(new CarePackageInfo("EvilFlowerSeed", 1f, () => GameClock.Instance.GetCycle() >= 24)); // add Sporechid seeds
				list.Add(new CarePackageInfo(PricklyLotusConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(FrostBlossomConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(IcyShroomConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(MyrthRoseConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(RustFernConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(SporeLampConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(TropicalgaeConfig.SeedId, 3f, null));
				list.Add(new CarePackageInfo(ShlurpCoralConfig.SeedId, 3f, null));
				field.SetValue(list.ToArray());
			}
		}

		// Add Molecular Forge recipes
		[HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
		public class SupermaterialRefineryConfig_ConfigureBuildingTemplate_Patch
		{
			public static void Postfix()
			{
				Log("SupermaterialRefineryConfig_ConfigureBuildingTemplate_Patch Postfix");

				RegisterSeedRecipe(PricklyLotusConfig.SeedId, "CactusPlantSeed", SimHashes.Sand, 470);
				RegisterSeedRecipe(FrostBlossomConfig.SeedId, "ColdWheatSeed", SimHashes.Tungsten, 471);
				RegisterSeedRecipe(IcyShroomConfig.SeedId, "MushroomSeed", SimHashes.Wolframite, 472);
				RegisterSeedRecipe(MyrthRoseConfig.SeedId, "LeafyPlantSeed", SimHashes.Fertilizer, 473);
				RegisterSeedRecipe(RustFernConfig.SeedId, "OxyfernSeed", SimHashes.Rust, 474);
				RegisterSeedRecipe(SporeLampConfig.SeedId, "MushroomSeed", SimHashes.Carbon, 475);
				RegisterSeedRecipe(TropicalgaeConfig.SeedId, "BulbPlantSeed", SimHashes.Algae, 476);
				RegisterSeedRecipe(ShlurpCoralConfig.SeedId, "ColdBreatherSeed", SimHashes.Salt, 477);
			}
		}

		public static void RegisterPlant(string plantId, string name, string description, string domesticatedDescription)
		{
			Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, plantId));
			Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.DESC", description);
			Strings.Add($"STRINGS.CREATURES.SPECIES.{plantId.ToUpperInvariant()}.DOMESTICATEDDESC", domesticatedDescription);
		}

		public static void RegisterSeed(string seedId, string seedName, string seedDescription)
		{
			Strings.Add($"STRINGS.CREATURES.SPECIES.SEEDS.{seedId.ToUpperInvariant()}.NAME", UI.FormatAsLink(seedName, seedId));
			Strings.Add($"STRINGS.CREATURES.SPECIES.SEEDS.{seedId.ToUpperInvariant()}.DESC", seedDescription);
		}

		public static void RegisterSeedRecipe(string seedName, Tag seedIngredient, SimHashes materialIngredient, int sortOrder)
		{
			var ingredients = new ComplexRecipe.RecipeElement[]
			{
			  new ComplexRecipe.RecipeElement(seedIngredient, 1f),
			  new ComplexRecipe.RecipeElement(materialIngredient.CreateTag(), 1f),
			};
			var results = new ComplexRecipe.RecipeElement[]
			{
			  new ComplexRecipe.RecipeElement(seedName, 1f)
			};
			var recipeId = ComplexRecipeManager.MakeRecipeID(SupermaterialRefineryConfig.ID, ingredients, results);
			new ComplexRecipe(recipeId, ingredients, results)
			{
				time = 100f,
				//description = null,
				nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
				fabricators = new List<Tag> { SupermaterialRefineryConfig.ID },
				sortOrder = sortOrder,
			};
		}

		public static void Log(string msg, bool force = false)
		{
			if (DebugMode || force)
				Console.WriteLine($"<<Sharles Plants>> {msg}");
		}
	}
}