using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;
using System.Collections.Generic;

namespace SharlesPlants
{
	public class ShlurpCoralConfig : IEntityConfig
	{
		public const string Id = "ShlurpCoral";
		public const string Name = "Shlurp Coral";
		public static string Description = $"The result of genetic experimentation on {UI.FormatAsLink("Wheezeworts", "ColdBreather")}, this plant is actually a colony of symbiotic creatures.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Polyp";
		public const string SeedName = Name + " Polyp";
		public static string SeedDescription = $"The polyp of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = ShlurpCoralTuning;

		public string[] GetDlcIds()
		{
			return SupportedVersions;
		}

		public GameObject CreatePrefab()
		{
			var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WaterPlant>(Id, Name, Description, SeedId, SeedName, SeedDescription, tuning, false);

			var waterPlant = plantEntityTemplate.AddOrGet<WaterPlant>();
			waterPlant.preferredTemperature = tuning.transitionTemp;
			SimHashes[] preferredElements =
				{
					SimHashes.SaltWater,
					SimHashes.Brine,
				};
			waterPlant.preferredElements = new List<SimHashes>(preferredElements);
			SimHashes[] toleratedElements =
				{
					SimHashes.Water,
					SimHashes.DirtyWater,
				};
			waterPlant.toleratedElements = new List<SimHashes>(toleratedElements);

			return plantEntityTemplate;
		}

		public void OnPrefabInit(GameObject inst)
		{
		}

		public void OnSpawn(GameObject inst)
		{
		}
	}
}