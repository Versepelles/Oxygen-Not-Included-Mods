﻿using System.Collections.Generic;

namespace MiniBase.Profiles
{
    class MiniBaseBiomeProfiles
    {
        public static MiniBaseBiomeProfile SandstoneProfile = new MiniBaseBiomeProfile(
            "subworlds/sandstone/SandstoneStart",
            SimHashes.SandStone,
            -1f,
            new BandInfo[]
            {
                new BandInfo(0.25f, SimHashes.Water),
                new BandInfo(0.30f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.35f, SimHashes.Dirt),
                new BandInfo(0.40f, SimHashes.Algae, density: 4f),
                new BandInfo(0.44f, SimHashes.IronOre),
                new BandInfo(0.47f, SimHashes.SandStone),
                new BandInfo(0.50f, SimHashes.SandStone),
                new BandInfo(0.53f, SimHashes.SandStone),
                new BandInfo(0.56f, SimHashes.Carbon),
                new BandInfo(0.60f, SimHashes.SedimentaryRock),
                new BandInfo(0.62f, SimHashes.Fossil),
                new BandInfo(0.65f, SimHashes.Granite),
                new BandInfo(0.70f, SimHashes.GoldAmalgam),
                new BandInfo(0.74f, SimHashes.Copper),
                new BandInfo(0.78f, SimHashes.Dirt),
                new BandInfo(0.93f, SimHashes.Oxygen, density: 2f),
                new BandInfo(1.00f, SimHashes.CarbonDioxide),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "Drecko", 0.04f },
                { "Squirrel", 0.04f },
                { "BasicSingleHarvestPlant", 0.06f },
                { "PrickleFlower", 0.04f },
                { "Oxyfern", 0.04f },
                { "PrickleGrass", 0.05f },
                { "LeafyPlant", 0.05f },
                { "BasicForagePlantPlanted", 0.04f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "Hatch", 0.005f },
                { "BasicForagePlant", 0.010f },
                { "BasicSingleHarvestPlantSeed", 0.010f },
                { "PrickleFlowerSeed", 0.005f },
                { "ForestTreeSeed", 0.005f },
                { "SpiceVineSeed", 0.005f },
                { "SaltPlantSeed", 0.005f },
                { "MushroomSeed", 0.005f },
                { "SwampLilySeed", 0.005f },
                { "BasicFabricMaterialPlantSeed", 0.005f },
                { "ColdBreatherSeed", 0.001f },
                { "EvilFlowerSeed", 0.001f },
            },
            spawnablesInAir:
            new Dictionary<string, float>()
            {
                { "LightBug", 0.02f },
                { "Puft", 0.01f },
            });

        public static MiniBaseBiomeProfile ForestProfile = new MiniBaseBiomeProfile(
            "subworlds/forest/ForestStart",
            SimHashes.Dirt,
            -1f,
            new BandInfo[]
            {
                new BandInfo(0.25f, SimHashes.Water),
                new BandInfo(0.27f, SimHashes.CarbonDioxide),
                new BandInfo(0.30f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.35f, SimHashes.AluminumOre),
                new BandInfo(0.38f, SimHashes.Carbon),
                new BandInfo(0.44f, SimHashes.Algae, density: 2f),
                new BandInfo(0.47f, SimHashes.Granite),
                new BandInfo(0.50f, SimHashes.IgneousRock),
                new BandInfo(0.53f, SimHashes.IgneousRock),
                new BandInfo(0.56f, SimHashes.Dirt),
                new BandInfo(0.60f, SimHashes.Dirt),
                new BandInfo(0.63f, SimHashes.Dirt),
                new BandInfo(0.65f, SimHashes.Sand),
                new BandInfo(0.68f, SimHashes.Fossil),
                new BandInfo(0.72f, SimHashes.Fertilizer),
                new BandInfo(0.75f, SimHashes.Dirt),
                new BandInfo(0.87f, SimHashes.Oxygen, density: 2f),
                new BandInfo(1.00f, SimHashes.CarbonDioxide),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBug", 0.04f },
                { "LightBugOrange", 0.03f },
                { "Drecko", 0.04f },
                { "Squirrel", 0.07f },
                { "BasicSingleHarvestPlant", 0.06f },
                { "ForestTree", 0.08f },
                { "PrickleFlower", 0.05f },
                { "Oxyfern", 0.07f },
                { "PrickleGrass", 0.03f },
                { "LeafyPlant", 0.05f },
                { "ForestForagePlantPlanted", 0.06f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "Hatch", 0.005f },
                { "ForestForagePlant", 0.010f },
                { "BasicSingleHarvestPlantSeed", 0.010f },
                { "PrickleFlowerSeed", 0.004f },
                { "ForestTreeSeed", 0.005f },
                { "SpiceVineSeed", 0.003f },
                { "SaltPlantSeed", 0.002f },
                { "MushroomSeed", 0.003f },
                { "SwampLilySeed", 0.003f },
                { "BasicFabricMaterialPlantSeed", 0.003f },
                { "ColdBreatherSeed", 0.001f },
                { "EvilFlowerSeed", 0.001f },
            });

        public static MiniBaseBiomeProfile SwampProfile = new MiniBaseBiomeProfile(
            "subworlds/marsh/HotMarsh",
            SimHashes.Algae,
            303f,
            new BandInfo[]
            {
                new BandInfo(0.23f, SimHashes.Water, 310f),
                new BandInfo(0.27f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.30f, SimHashes.SlimeMold),
                new BandInfo(0.32f, SimHashes.Clay),
                new BandInfo(0.34f, SimHashes.Sand, density: 2f),
                new BandInfo(0.37f, SimHashes.FoolsGold),
                new BandInfo(0.40f, SimHashes.IgneousRock, density: 2f),
                new BandInfo(0.43f, SimHashes.Carbon),
                new BandInfo(0.48f, SimHashes.Dirt),
                new BandInfo(0.52f, SimHashes.Algae),
                new BandInfo(0.53f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.60f, SimHashes.ContaminatedOxygen, density: 2f),
                new BandInfo(0.63f, SimHashes.IgneousRock, density: 2f),
                new BandInfo(0.64f, SimHashes.BleachStone, density: 4f),
                new BandInfo(0.66f, SimHashes.SedimentaryRock),
                new BandInfo(0.73f, SimHashes.SlimeMold),
                new BandInfo(0.77f, SimHashes.GoldAmalgam),
                new BandInfo(0.85f, SimHashes.ContaminatedOxygen, density: 2f),
                new BandInfo(1.00f, SimHashes.DirtyWater, 310f),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBug", 0.02f },
                { "LightBugOrange", 0.03f },
                { "Drecko", 0.03f },
                { "Glom", 0.04f },
                { "Puft", 0.02f },
                { "PuftAlpha", 0.02f },
                { "BasicSingleHarvestPlant", 0.06f },
                { "SwampLily", 0.04f },
                { "BasicFabricPlant", 0.04f },
                { "BulbPlant", 0.04f },
                { "LeafyPlant", 0.04f },
                { "MushroomPlant", 0.06f },
                { "BasicForagePlantPlanted", 0.02f },
                { "ForestForagePlantPlanted", 0.04f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "HatchVeggie", 0.005f },
                { "BasicForagePlant", 0.005f },
                { "ForestForagePlant", 0.005f },
                { "BasicSingleHarvestPlantSeed", 0.005f },
                { "MushroomSeed", 0.005f },
                { "SwampLilySeed", 0.005f },
                { "BasicFabricMaterialPlantSeed", 0.005f },
                { "PrickleFlowerSeed", 0.003f },
                { "ForestTreeSeed", 0.003f },
                { "SpiceVineSeed", 0.003f },
                { "SaltPlantSeed", 0.002f },
                { "OxyfernSeed", 0.002f },
                { "EvilFlowerSeed", 0.001f },
            },
            spawnablesInLiquid:
            new Dictionary<string, float>()
            {
                { "Pacu", 0.02f },
            });

        public static MiniBaseBiomeProfile FrozenProfile = new MiniBaseBiomeProfile(
            "subworlds/frozen/Frozen",
            SimHashes.IgneousRock,
            275f,
            new BandInfo[]
            {
                new BandInfo(0.10f, SimHashes.CarbonDioxide, 245f, density: 2f),
                new BandInfo(0.25f, SimHashes.Oxygen, 245f, 2f),
                new BandInfo(0.30f, SimHashes.Wolframite, 235f),
                new BandInfo(0.34f, SimHashes.DirtyIce, 235f),
                new BandInfo(0.37f, SimHashes.BrineIce, 235f),
                new BandInfo(0.40f, SimHashes.Ice, 245f),
                new BandInfo(0.44f, SimHashes.Snow, 245f),
                new BandInfo(0.47f, SimHashes.OxyRock, 265f, density: 2f),
                new BandInfo(0.50f, SimHashes.IgneousRock),
                new BandInfo(0.54f, SimHashes.IgneousRock, 285f),
                new BandInfo(0.57f, SimHashes.Carbon),
                new BandInfo(0.60f, SimHashes.Granite),
                new BandInfo(0.62f, SimHashes.Fossil),
                new BandInfo(0.64f, SimHashes.Lime),
                new BandInfo(0.69f, SimHashes.Dirt),
                new BandInfo(0.74f, SimHashes.Wolframite),
                new BandInfo(0.77f, SimHashes.Oxygen, density: 2f),
                new BandInfo(1.00f, SimHashes.Water, 278f),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBugBlue", 0.07f },
                { "BasicForagePlantPlanted", 0.12f },
                { "BasicSingleHarvestPlant", 0.06f },
                { "ColdWheat", 0.12f },
                { "ColdBreather", 0.05f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "BasicForagePlant", 0.010f },
                { "BasicSingleHarvestPlantSeed", 0.010f },
                { "Warm_Vest", 0.005f },
                { "PrickleFlowerSeed", 0.003f },
                { "ColdBreatherSeed", 0.001f },
            });

        public static MiniBaseBiomeProfile DesertProfile = new MiniBaseBiomeProfile(
            "subworlds/oil/OilPatch",
            SimHashes.SandStone,
            313f,
            new BandInfo[]
            {
                new BandInfo(0.12f, SimHashes.CrudeOil, 373f, density: 2f),
                new BandInfo(0.15f, SimHashes.Water, 373f),
                new BandInfo(0.18f, SimHashes.Water, 333f),
                new BandInfo(0.20f, SimHashes.Water, 313f),
                new BandInfo(0.22f, SimHashes.Water, 303f),
                new BandInfo(0.25f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.30f, SimHashes.Carbon, density: 2f),
                new BandInfo(0.34f, SimHashes.Fossil),
                new BandInfo(0.36f, SimHashes.Sand),
                new BandInfo(0.40f, SimHashes.SandStone),
                new BandInfo(0.44f, SimHashes.SandStone),
                new BandInfo(0.47f, SimHashes.SandStone),
                new BandInfo(0.50f, SimHashes.Sand),
                new BandInfo(0.53f, SimHashes.Sand, 323f),
                new BandInfo(0.56f, SimHashes.MaficRock),
                new BandInfo(0.60f, SimHashes.Dirt),
                new BandInfo(0.65f, SimHashes.Copper),
                new BandInfo(0.67f, SimHashes.Sand),
                new BandInfo(0.70f, SimHashes.SandStone),
                new BandInfo(0.73f, SimHashes.OxyRock, density: 2f),
                new BandInfo(0.90f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.94f, SimHashes.Hydrogen, density: 2f),
                new BandInfo(0.96f, SimHashes.SandStone),
                new BandInfo(1.00f, SimHashes.OxyRock, density: 2f),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBug", 0.04f },
                { "LightBugOrange", 0.03f },
                { "LightBugPink", 0.02f },
                { "Oilfloater", 0.04f },
                { "OilfloaterDecor", 0.02f },
                { "BasicSingleHarvestPlant", 0.06f },
                { "CactusPlant", 0.08f },
                { "PrickleGrass", 0.04f },
                { "EvilFlower", 0.02f },
                { "BasicForagePlantPlanted", 0.08f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "Hatch", 0.003f },
                { "HatchHard", 0.002f },
                { "HatchMetal", 0.001f },
                { "BasicForagePlant", 0.010f },
                { "BasicSingleHarvestPlantSeed", 0.010f },
                { "CactusPlantSeed", 0.005f },
                { "EvilFlowerSeed", 0.003f },
            });

        public static MiniBaseBiomeProfile BarrenProfile = new MiniBaseBiomeProfile(
            "subworlds/barren/BarrenGranite",
            SimHashes.IgneousRock,
            283f,
            new BandInfo[]
            {
                new BandInfo(0.20f, SimHashes.Water),
                new BandInfo(0.27f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.30f, SimHashes.IgneousRock),
                new BandInfo(0.36f, SimHashes.IronOre, density: 2f),
                new BandInfo(0.42f, SimHashes.Granite),
                new BandInfo(0.45f, SimHashes.Diamond),
                new BandInfo(0.49f, SimHashes.CrushedRock),
                new BandInfo(0.53f, SimHashes.IgneousRock),
                new BandInfo(0.56f, SimHashes.IgneousRock),
                new BandInfo(0.60f, SimHashes.Dirt, density: 2f),
                new BandInfo(0.63f, SimHashes.Carbon),
                new BandInfo(0.65f, SimHashes.IgneousRock),
                new BandInfo(0.70f, SimHashes.IgneousRock),
                new BandInfo(0.75f, SimHashes.OxyRock, density: 2f),
                new BandInfo(0.90f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.94f, SimHashes.CarbonDioxide, density: 2f),
                new BandInfo(0.96f, SimHashes.IgneousRock),
                new BandInfo(1.00f, SimHashes.OxyRock, density: 2f),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "HatchHard", 0.008f },
                { "EvilFlowerSeed", 0.003f },
            });

        public static MiniBaseBiomeProfile StrangeProfile = new MiniBaseBiomeProfile(
            "subworlds/barren/BarrenGranite",
            SimHashes.Dirt,
            -1f,
            new BandInfo[]
            {
                new BandInfo(0.08f, SimHashes.Water),
                new BandInfo(0.10f, SimHashes.Aluminum),
                new BandInfo(0.12f, SimHashes.FoolsGold),
                new BandInfo(0.14f, SimHashes.MaficRock),
                new BandInfo(0.16f, SimHashes.Regolith),
                new BandInfo(0.18f, SimHashes.SedimentaryRock),
                new BandInfo(0.20f, SimHashes.CrushedRock),
                new BandInfo(0.22f, SimHashes.IgneousRock),
                new BandInfo(0.24f, SimHashes.Phosphorite),
                new BandInfo(0.26f, SimHashes.OxyRock),
                new BandInfo(0.28f, SimHashes.Hydrogen),
                new BandInfo(0.30f, SimHashes.Oxygen),
                new BandInfo(0.32f, SimHashes.Wolframite),
                new BandInfo(0.34f, SimHashes.Tungsten),
                new BandInfo(0.36f, SimHashes.Glass),
                new BandInfo(0.38f, SimHashes.Rust),
                new BandInfo(0.40f, SimHashes.ChlorineGas),
                new BandInfo(0.42f, SimHashes.Clay),
                new BandInfo(0.44f, SimHashes.Methane),
                new BandInfo(0.46f, SimHashes.CrudeOil),
                new BandInfo(0.48f, SimHashes.OxyRock),
                new BandInfo(0.50f, SimHashes.BleachStone),
                new BandInfo(0.52f, SimHashes.Fossil),
                new BandInfo(0.54f, SimHashes.Steel),
                new BandInfo(0.56f, SimHashes.Brine),
                new BandInfo(0.58f, SimHashes.SaltWater),
                new BandInfo(0.60f, SimHashes.SaltWater),
                new BandInfo(0.62f, SimHashes.Salt),
                new BandInfo(0.64f, SimHashes.Carbon),
                new BandInfo(0.66f, SimHashes.OxyRock),
                new BandInfo(0.68f, SimHashes.Diamond),
                new BandInfo(0.70f, SimHashes.Fertilizer),
                new BandInfo(0.72f, SimHashes.Polypropylene),
                new BandInfo(0.74f, SimHashes.Carbon),
                new BandInfo(0.76f, SimHashes.Granite),
                new BandInfo(0.78f, SimHashes.Glass),
                new BandInfo(0.80f, SimHashes.Dirt),
                new BandInfo(0.82f, SimHashes.SlimeMold),
                new BandInfo(0.84f, SimHashes.OxyRock),
                new BandInfo(0.86f, SimHashes.Sand),
                new BandInfo(0.88f, SimHashes.Clay),
                new BandInfo(0.90f, SimHashes.ContaminatedOxygen, density: 2f),
                new BandInfo(0.93f, SimHashes.DirtyIce),
                new BandInfo(0.95f, SimHashes.OxyRock),
                new BandInfo(1.00f, SimHashes.DirtyWater),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBug", 0.03f },
                { "LightBugOrange", 0.03f },
                { "LightBugBlue", 0.03f },
                { "LightBugPink", 0.03f },
                { "LightBugCrystal", 0.03f },
                { "Drecko", 0.03f },
                { "DreckoPlastic", 0.03f },
                { "Squirrel", 0.03f },
                { "Puft", 0.03f },
                { "PuftAlpha", 0.03f },
                { "PuftOxylite", 0.03f },
                { "PuftBleachstone", 0.03f },
                { "Glom", 0.06f },
                { "Oilfloater", 0.03f },
                { "OilfloaterDecor", 0.03f },
                { "Pacu", 0.03f },
                { "Crab", 0.03f },
                { "Mole", 0.03f },
                { "Moo", 0.03f },
                { "BasicSingleHarvestPlant", 0.06f },
                { "PrickleFlower", 0.03f },
                { "Oxyfern", 0.03f },
                { "PrickleGrass", 0.03f },
                { "LeafyPlant", 0.03f },
                { "BulbPlant", 0.03f },
                { "BasicForagePlantPlanted", 0.03f },
                { "ForestForagePlantPlanted", 0.03f },
                { "BasicFabricPlant", 0.03f },
                { "EvilFlower", 0.03f },
                { "BeanPlant", 0.03f },
                { "ColdWheat", 0.03f },
                { "GasGrass", 0.03f },
                { "ColdBreather", 0.03f },
                { "CactusPlant", 0.03f },
                { "MushroomPlant", 0.03f },
                { "SwampLily", 0.03f },
                { "SeaLettuce", 0.03f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "Hatch", 0.005f },
                { "HatchHard", 0.005f },
                { "HatchVeggie", 0.005f },
                { "HatchMetal", 0.005f },
                { "FieldRation", 0.020f },
                { "BasicForagePlant", 0.010f },
                { "ForestForagePlant", 0.010f },
                { "BasicSingleHarvestPlantSeed", 0.010f },
                { "PrickleFlowerSeed", 0.005f },
                { "ForestTreeSeed", 0.005f },
                { "SpiceVineSeed", 0.005f },
                { "SaltPlantSeed", 0.005f },
                { "MushroomSeed", 0.005f },
                { "SwampLilySeed", 0.005f },
                { "BasicFabricMaterialPlantSeed", 0.005f },
                { "ColdBreatherSeed", 0.001f },
                { "EvilFlowerSeed", 0.001f },
                { "Cool_Vest", 0.002f },
                { "Warm_Vest", 0.002f },
                { "Funky_Vest", 0.005f },
            });
    }
}