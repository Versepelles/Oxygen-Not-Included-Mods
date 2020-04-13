using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace SharlesPlants
{
    class BaseSharlesPlantConfig
    {
        public static GameObject BaseSharlesPlant<T>(
            string id,
            string name,
            string description,
            string seedId,
            string seedName,
            string seedDescription,
			SharlesPlantsTuning.PlantTuning tuning,
			bool canDrown = true
			) where T : SharlesPlant
		{
			string lowerId = id.ToLowerInvariant();
			string animName = lowerId + "_kanim";
			string seedAnimName = "seed_" + animName;
			string previewId = lowerId + "_preview";

			var plantEntityTemplate = EntityTemplates.CreatePlacedEntity(
				id: id,
				name: UI.FormatAsLink(name, id),
				desc: description,
				width: 1,
				height: 1,
				mass: 1f,
				anim: Assets.GetAnim(animName),
				initialAnim: "juvenile",
				sceneLayer: Grid.SceneLayer.BuildingFront,
				decor: tuning.juvenileDecor,
				defaultTemperature: tuning.defaultTemperature);

			EntityTemplates.ExtendEntityToBasicPlant(
				template: plantEntityTemplate,
				temperature_lethal_low: tuning.lethalLow,
				temperature_warning_low: tuning.warningLow,
				temperature_warning_high: tuning.warningHigh,
				temperature_lethal_high: tuning.lethalhigh,
				safe_elements: tuning.safeElements,
				pressure_sensitive: false,
				can_drown: canDrown,
				can_tinker: false);

			var seed = EntityTemplates.CreateAndRegisterSeedForPlant(
				plant: plantEntityTemplate,
				id: seedId,
				name: UI.FormatAsLink(seedName, id),
				desc: seedDescription,
				productionType: SeedProducer.ProductionType.Hidden,
				anim: Assets.GetAnim(seedAnimName),
				numberOfSeeds: 0,
				additionalTags: new List<Tag> { GameTags.DecorSeed },
				sortOrder: 7,
				width: 0.33f,
				height: 0.33f);

			EntityTemplates.CreateAndRegisterPreviewForPlant(
				seed: seed,
				id: previewId,
				anim: Assets.GetAnim(animName),
				initialAnim: "place",
				width: 1,
				height: 1);

			SharlesPlant sharlesPlant = plantEntityTemplate.AddOrGet<T>();
			sharlesPlant.juvenileDecor = tuning.juvenileDecor;
			sharlesPlant.matureDecor = tuning.matureDecor;
			sharlesPlant.flourishingDecor = tuning.flourishingDecor;

			return plantEntityTemplate;
		}
    }
}
