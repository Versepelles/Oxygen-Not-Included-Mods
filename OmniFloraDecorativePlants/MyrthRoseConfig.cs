using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	public class MyrthRoseConfig : IEntityConfig
	{
		public const string Id = "MyrthRose";
		public const string Name = "Myrth Rose";
		public static string Description = "A royalty among plants, prized for its alluring colors that fully emerge in warm climates.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The seed of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = MyrthRoseTuning;

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

		public string GetDlcId() { return ""; }
	}
}