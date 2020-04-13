using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;
using System.Collections.Generic;

namespace SharlesPlants
{
	public class TropicalgaeConfig : IEntityConfig
	{
		public const string Id = "Tropicalgae";
		public const string Name = "Tropicalgae";
		public static string Description = "Many consider this plant to be an unsightly nuisance, but it provides shelter and food for aquatic life.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The seed bulb of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = TropicalgaeTuning;

		public GameObject CreatePrefab()
		{
			var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WaterPlant>(Id, Name, Description, SeedId, SeedName, SeedDescription, tuning, false);

			var waterPlant = plantEntityTemplate.AddOrGet<WaterPlant>();
			waterPlant.preferredTemperature = tuning.transitionTemp;
			SimHashes[] preferredElements =
				{
					SimHashes.DirtyWater,
				};
			waterPlant.preferredElements = new List<SimHashes>(preferredElements);
			SimHashes[] toleratedElements =
				{
					SimHashes.Water,
					SimHashes.SaltWater,
					SimHashes.Brine,
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