using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	public class RustFernConfig : IEntityConfig
	{
		public const string Id = "RustFern";
		public const string Name = "Rust Fern";
		public static string Description = "The fronds of this fern are hardened by minerals absorbed from the soil. Cooler environments promote mineral formation.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The seed of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = RustFernTuning;

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