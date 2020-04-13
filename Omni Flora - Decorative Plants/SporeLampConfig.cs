using System.Collections.Generic;
using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
	public class SporeLampConfig : IEntityConfig
	{
		public const string Id = "SporeLamp";
		public const string Name = "Spore Lamp";
		public static string Description = "When immersed in a reactive element, this mycelial organism emits a mesmerizing glow that lures its prey into inhospitable environments. Their remains provide fertilizer for its spread.";
		public static string DomesticatedDescription = Description;

		public const string SeedId = Id + "Seed";
		public const string SeedName = Name + " Seed";
		public static string SeedDescription = $"The spore of a {UI.FormatAsLink(Name, Id)}.";

		public static PlantTuning tuning = SporeLampTuning;

		public GameObject CreatePrefab()
		{
			var plantEntityTemplate = BaseSharlesPlantConfig.BaseSharlesPlant<ReactivePlant>(Id, Name, Description, SeedId, SeedName, SeedDescription, tuning);

			var reactivePlant = plantEntityTemplate.AddOrGet<ReactivePlant>();
			reactivePlant.requiredTemperature = tuning.transitionTemp;
			SimHashes[] reactiveElements =
				{
					SimHashes.Methane,
					SimHashes.SourGas,
					SimHashes.Hydrogen,
					SimHashes.EthanolGas,
				};
			reactivePlant.reactiveElements = new List<SimHashes>(reactiveElements);

			var light2D = plantEntityTemplate.AddOrGet<Light2D>();
			light2D.Color = new Color(1.0f, 0.8f, 1.0f);
			light2D.Lux = 1800;
			light2D.Range = 5;
			light2D.overlayColour = new Color(0.5f, 0.4f, 0.5f, 0.25f);
			light2D.drawOverlay = true;
			light2D.Offset = new Vector2(-0.05f, 0.7f);

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