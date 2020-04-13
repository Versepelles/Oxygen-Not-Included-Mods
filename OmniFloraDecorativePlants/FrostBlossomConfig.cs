using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	public class FrostBlossomConfig : IEntityConfig
	{
		public const string Id = "FrostBlossom";
		public const string Name = "Frost Blossom";
		public static string Description = "A plant with exquisite petals that thrives in the chilliest of environments.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The seed of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = FrostBlossomTuning;

		public GameObject CreatePrefab()
		{
			var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<ColdLovingPlant>(Id, Name, Description, SeedId, SeedName, SeedDescription, tuning);

			var coldPlant = plantEntityTemplate.AddOrGet<ColdLovingPlant>();
			coldPlant.lowTransition = tuning.transitionLow;
			coldPlant.highTransition = tuning.transitionHigh;

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