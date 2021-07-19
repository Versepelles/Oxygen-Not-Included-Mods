using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	public class PricklyLotusConfig : IEntityConfig
	{
		public const string Id = "PricklyLotus";
		public const string Name = "Prickly Lotus";
		public static string Description = "This bulbous succulent is oddly reminiscent of a young duplicant but much easier to take care of.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The seed bulb of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = PricklyLotusTuning;

		public string[] GetDlcIds()
		{
			return SupportedVersions;
		}

		public GameObject CreatePrefab()
		{
			var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<WarmLovingPlant>(Id, Name, Description, SeedId, SeedName, SeedDescription, tuning);

			var warmPlant = plantEntityTemplate.AddOrGet<WarmLovingPlant>();
			warmPlant.lowTransition = tuning.transitionLow;
			warmPlant.highTransition = tuning.transitionHigh;

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