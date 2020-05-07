using System.Collections.Generic;

namespace MiniBase.Profiles
{
    class MiniBaseCoreBiomeProfiles
    {
        public static MiniBaseBiomeProfile MagmaCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Diamond,
            1998f,
            new BandInfo[]
            {
                new BandInfo(0.18f, SimHashes.Diamond),
                new BandInfo(0.22f, SimHashes.Tungsten),
                new BandInfo(0.26f, SimHashes.Magma),
                new BandInfo(0.29f, SimHashes.Diamond),
                new BandInfo(0.35f, SimHashes.Magma),
                new BandInfo(0.38f, SimHashes.Tungsten),
                new BandInfo(0.41f, SimHashes.Wolframite),
                new BandInfo(0.45f, SimHashes.Diamond),
                new BandInfo(0.49f, SimHashes.Magma),
                new BandInfo(0.52f, SimHashes.Diamond),
                new BandInfo(0.57f, SimHashes.Magma),
                new BandInfo(0.60f, SimHashes.Diamond),
                new BandInfo(0.63f, SimHashes.RefinedCarbon),
                new BandInfo(0.68f, SimHashes.Steel),
                new BandInfo(0.74f, SimHashes.Magma),
                new BandInfo(0.76f, SimHashes.Diamond),
                new BandInfo(0.80f, SimHashes.Magma),
                new BandInfo(0.84f, SimHashes.Steel),
                new BandInfo(1.00f, SimHashes.Diamond),
            });

        public static MiniBaseBiomeProfile FrozenCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Ice,
            233f,
            new BandInfo[]
            {
                new BandInfo(0.10f, SimHashes.CarbonDioxide, density: 2f),
                new BandInfo(0.18f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.22f, SimHashes.Snow, density: 50f),
                new BandInfo(0.27f, SimHashes.Ice),
                new BandInfo(0.30f, SimHashes.CarbonDioxide, density: 2f),
                new BandInfo(0.33f, SimHashes.Ice),
                new BandInfo(0.37f, SimHashes.IronOre),
                new BandInfo(0.41f, SimHashes.Wolframite),
                new BandInfo(0.45f, SimHashes.Ice),
                new BandInfo(0.49f, SimHashes.Snow, density: 50f),
                new BandInfo(0.53f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.56f, SimHashes.IronOre),
                new BandInfo(0.60f, SimHashes.Ice),
                new BandInfo(0.63f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.65f, SimHashes.CarbonDioxide, density: 2f),
                new BandInfo(0.69f, SimHashes.Ice),
                new BandInfo(0.73f, SimHashes.Wolframite),
                new BandInfo(0.76f, SimHashes.Snow, density: 50f),
                new BandInfo(0.81f, SimHashes.Ice),
                new BandInfo(0.85f, SimHashes.Oxygen, density: 2f),
                new BandInfo(1.00f, SimHashes.CarbonDioxide, density: 2f),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "ColdWheat", 0.15f },
                { "ColdBreather", 0.10f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "ColdBreatherSeed", 0.005f },
            },
            spawnablesInAir:
            new Dictionary<string, float>()
            {
                { "LightBugBlueBaby", 0.04f },
            });

        public static MiniBaseBiomeProfile OceanCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Salt,
            -1f,
            new BandInfo[]
            {
                new BandInfo(0.08f, SimHashes.Hydrogen, density: 2f),
                new BandInfo(0.19f, SimHashes.SaltWater, density: 0.9f),
                new BandInfo(0.22f, SimHashes.Rust, density: 2f),
                new BandInfo(0.25f, SimHashes.Sand),
                new BandInfo(0.30f, SimHashes.Salt),
                new BandInfo(0.34f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.36f, SimHashes.Hydrogen, density: 2f),
                new BandInfo(0.38f, SimHashes.Salt),
                new BandInfo(0.41f, SimHashes.BleachStone, density: 4f),
                new BandInfo(0.44f, SimHashes.Sand),
                new BandInfo(0.49f, SimHashes.SaltWater, density: 0.9f),
                new BandInfo(0.51f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.55f, SimHashes.Sand),
                new BandInfo(0.59f, SimHashes.Salt),
                new BandInfo(0.62f, SimHashes.Rust, density: 2f),
                new BandInfo(0.65f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.67f, SimHashes.Hydrogen, density: 2f),
                new BandInfo(0.73f, SimHashes.SaltWater, density: 0.9f),
                new BandInfo(0.80f, SimHashes.Salt),
                new BandInfo(0.85f, SimHashes.BleachStone, density: 4f),
                new BandInfo(1.00f, SimHashes.ChlorineGas, density: 2f),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "Crab", 0.08f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "SeaLettuceSeed", 0.015f },
                { "SpiceVineSeed", 0.015f },
            },
            spawnablesInAir:
            new Dictionary<string, float>()
            {
                { "LightBugPinkBaby", 0.04f },
            },
            spawnablesInLiquid:
            new Dictionary<string, float>()
            {
                { "Pacu", 0.05f },
                { "PacuTropical", 0.02f },
                { "Crab", 0.02f },
            });

        public static MiniBaseBiomeProfile OilCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Diamond,
            553f,
            new BandInfo[]
            {
                new BandInfo(0.18f, SimHashes.Diamond),
                new BandInfo(0.20f, SimHashes.Fossil),
                new BandInfo(0.24f, SimHashes.Petroleum, density: 4.3f),
                new BandInfo(0.28f, SimHashes.SourGas, density: 2f),
                new BandInfo(0.50f, SimHashes.CrudeOil, density: 4.3f),
                new BandInfo(0.52f, SimHashes.SandStone),
                new BandInfo(0.55f, SimHashes.Fossil),
                new BandInfo(0.59f, SimHashes.IronOre),
                new BandInfo(0.62f, SimHashes.Diamond),
                new BandInfo(0.79f, SimHashes.CrudeOil, density: 4.3f),
                new BandInfo(0.86f, SimHashes.Lead),
                new BandInfo(1.00f, SimHashes.Diamond),
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "EvilFlowerSeed", 0.005f },
            });

        public static MiniBaseBiomeProfile MetalCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.IronOre,
            483f,
            new BandInfo[]
            {
                new BandInfo(0.18f, SimHashes.IronOre),
                new BandInfo(0.25f, SimHashes.Wolframite),
                new BandInfo(0.30f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.34f, SimHashes.MaficRock),
                new BandInfo(0.37f, SimHashes.AluminumOre),
                new BandInfo(0.40f, SimHashes.GoldAmalgam),
                new BandInfo(0.43f, SimHashes.MaficRock),
                new BandInfo(0.46f, SimHashes.IronOre),
                new BandInfo(0.48f, SimHashes.FoolsGold),
                new BandInfo(0.51f, SimHashes.MaficRock),
                new BandInfo(0.56f, SimHashes.IronOre),
                new BandInfo(0.60f, SimHashes.Wolframite),
                new BandInfo(0.65f, SimHashes.AluminumOre),
                new BandInfo(0.70f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.73f, SimHashes.MaficRock),
                new BandInfo(0.77f, SimHashes.Lead),
                new BandInfo(0.82f, SimHashes.GoldAmalgam),
                new BandInfo(0.85f, SimHashes.MaficRock),
                new BandInfo(1.00f, SimHashes.Cuprite),
            });

        public static MiniBaseBiomeProfile FertileCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Dirt,
            -1f,
            new BandInfo[]
            {
                new BandInfo(0.10f, SimHashes.Sand),
                new BandInfo(0.27f, SimHashes.Water),
                new BandInfo(0.30f, SimHashes.Oxygen, density: 3f),
                new BandInfo(0.33f, SimHashes.Sand),
                new BandInfo(0.38f, SimHashes.Algae),
                new BandInfo(0.45f, SimHashes.Dirt),
                new BandInfo(0.47f, SimHashes.Algae),
                new BandInfo(0.56f, SimHashes.IronOre),
                new BandInfo(0.58f, SimHashes.Algae),
                new BandInfo(0.63f, SimHashes.Dirt),
                new BandInfo(0.65f, SimHashes.Sand),
                new BandInfo(0.69f, SimHashes.Algae),
                new BandInfo(0.72f, SimHashes.IronOre),
                new BandInfo(0.77f, SimHashes.Oxygen, density: 3f),
                new BandInfo(0.90f, SimHashes.Water),
                new BandInfo(1.00f, SimHashes.Sand),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LeafyPlant", 0.10f },
                { "BasicForagePlantPlanted", 0.07f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
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
            },
            spawnablesInAir:
            new Dictionary<string, float>()
            {
                { "LightBug", 0.025f },
            },
            spawnablesInLiquid:
            new Dictionary<string, float>()
            {
                { "Pacu", 0.01f },
            });

        public static MiniBaseBiomeProfile BoneyardCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Granite,
            265f,
            new BandInfo[]
            {
                new BandInfo(0.16f, SimHashes.IgneousRock),
                new BandInfo(0.21f, SimHashes.Carbon),
                new BandInfo(0.25f, SimHashes.Fossil),
                new BandInfo(0.35f, SimHashes.CrudeOil, density: 4.3f),
                new BandInfo(0.39f, SimHashes.IgneousRock),
                new BandInfo(0.44f, SimHashes.Ceramic),
                new BandInfo(0.45f, SimHashes.Fullerene),
                new BandInfo(0.50f, SimHashes.Granite),
                new BandInfo(0.57f, SimHashes.IgneousRock),
                new BandInfo(0.66f, SimHashes.CrudeOil, density: 4.3f),
                new BandInfo(0.69f, SimHashes.Fossil),
                new BandInfo(0.72f, SimHashes.IgneousRock),
                new BandInfo(0.80f, SimHashes.Granite),
                new BandInfo(0.91f, SimHashes.Fullerene),
                new BandInfo(0.95f, SimHashes.Fossil),
                new BandInfo(1.00f, SimHashes.Granite),
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "HatchHard", 0.010f },
                { "HatchMetal", 0.010f },
            });

        public static MiniBaseBiomeProfile AestheticCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Katairite,
            265f,
            new BandInfo[]
            {
                new BandInfo(0.12f, SimHashes.Katairite),
                new BandInfo(0.27f, SimHashes.Ethanol),
                new BandInfo(0.33f, SimHashes.Oxygen, density: 3f),
                new BandInfo(0.35f, SimHashes.Ethanol),
                new BandInfo(0.38f, SimHashes.Glass),
                new BandInfo(0.45f, SimHashes.IronOre, density: 1.5f),
                new BandInfo(0.55f, SimHashes.Katairite),
                new BandInfo(0.60f, SimHashes.Hydrogen, density: 3f),
                new BandInfo(0.65f, SimHashes.Salt),
                new BandInfo(0.68f, SimHashes.Glass),
                new BandInfo(0.88f, SimHashes.ViscoGel),
                new BandInfo(1.00f, SimHashes.Katairite),
            },
            spawnablesInAir:
            new Dictionary<string, float>()
            {
                { "LightBugPurple", 0.030f },
            });

        public static MiniBaseBiomeProfile PearlCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Diamond,
            1759f,
            new BandInfo[]
            {
                new BandInfo(0.13f, SimHashes.Steam, density: 20f),
                new BandInfo(0.18f, SimHashes.Diamond),
                new BandInfo(0.24f, SimHashes.Tungsten),
                new BandInfo(0.28f, SimHashes.Diamond),
                new BandInfo(0.32f, SimHashes.Ceramic),
                new BandInfo(0.35f, SimHashes.Tungsten),
                new BandInfo(0.42f, SimHashes.MoltenAluminum, density: 10f),
                new BandInfo(0.49f, SimHashes.Steam, density: 20f),
                new BandInfo(0.50f, SimHashes.Tungsten),
                new BandInfo(0.52f, SimHashes.Ceramic),
                new BandInfo(0.54f, SimHashes.Diamond),
                new BandInfo(0.56f, SimHashes.Tungsten),
                new BandInfo(0.58f, SimHashes.Steam, density: 20f),
                new BandInfo(0.66f, SimHashes.MoltenGlass, density: 9f),
                new BandInfo(0.68f, SimHashes.Tungsten),
                new BandInfo(0.75f, SimHashes.Ceramic),
                new BandInfo(0.84f, SimHashes.Diamond),
                new BandInfo(0.93f, SimHashes.Tungsten),
                new BandInfo(1.00f, SimHashes.Steam, density: 20f),
            });
    }
}
