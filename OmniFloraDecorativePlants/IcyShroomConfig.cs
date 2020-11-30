using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	public class IcyShroomConfig : IEntityConfig
	{
		public const string Id = "IcyShroom";
		public const string Name = "Icy Shroom";
		public static string Description = "An adorable little toadstool with a great affection for frigid conditions.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The seed of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = IcyShroomTuning;

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

		public string GetDlcId() { return ""; }
	}
}