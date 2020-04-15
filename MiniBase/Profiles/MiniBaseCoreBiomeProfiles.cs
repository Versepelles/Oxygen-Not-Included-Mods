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
                new BandInfo(0.40f, SimHashes.Wolframite),
                new BandInfo(0.45f, SimHashes.Diamond),
                new BandInfo(0.49f, SimHashes.Magma),
                new BandInfo(0.52f, SimHashes.Diamond),
                new BandInfo(0.57f, SimHashes.Magma),
                new BandInfo(0.61f, SimHashes.Diamond),
                new BandInfo(0.63f, SimHashes.RefinedCarbon),
                new BandInfo(0.66f, SimHashes.Steel),
                new BandInfo(0.73f, SimHashes.Magma),
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
                new BandInfo(0.19f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.22f, SimHashes.Snow, density: 50f),
                new BandInfo(0.27f, SimHashes.Ice),
                new BandInfo(0.30f, SimHashes.CarbonDioxide, density: 2f),
                new BandInfo(0.35f, SimHashes.Ice),
                new BandInfo(0.40f, SimHashes.Wolframite),
                new BandInfo(0.45f, SimHashes.Ice),
                new BandInfo(0.50f, SimHashes.Snow, density: 50f),
                new BandInfo(0.53f, SimHashes.Oxygen, density: 2f),
                new BandInfo(0.55f, SimHashes.Snow, density: 50f),
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
                new BandInfo(0.25f, SimHashes.Sand),
                new BandInfo(0.30f, SimHashes.Salt),
                new BandInfo(0.34f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.36f, SimHashes.Hydrogen, density: 2f),
                new BandInfo(0.38f, SimHashes.Salt),
                new BandInfo(0.41f, SimHashes.BleachStone, density: 4f),
                new BandInfo(0.44f, SimHashes.Sand),
                new BandInfo(0.50f, SimHashes.SaltWater, density: 0.9f),
                new BandInfo(0.52f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.56f, SimHashes.Sand),
                new BandInfo(0.60f, SimHashes.Salt),
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
                new BandInfo(0.59f, SimHashes.Diamond),
                new BandInfo(0.80f, SimHashes.CrudeOil, density: 4.3f),
                new BandInfo(0.85f, SimHashes.Lead),
                new BandInfo(1.00f, SimHashes.Diamond),
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "EvilFlower", 0.005f },
            });

        public static MiniBaseBiomeProfile MetalCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Iron,
            483f,
            new BandInfo[]
            {
                new BandInfo(0.18f, SimHashes.IronOre),
                new BandInfo(0.25f, SimHashes.Wolframite),
                new BandInfo(0.30f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.34f, SimHashes.MaficRock),
                new BandInfo(0.37f, SimHashes.AluminumOre),
                new BandInfo(0.40f, SimHashes.GoldAmalgam),
                new BandInfo(0.44f, SimHashes.MaficRock),
                new BandInfo(0.48f, SimHashes.FoolsGold),
                new BandInfo(0.52f, SimHashes.MaficRock),
                new BandInfo(0.56f, SimHashes.IronOre),
                new BandInfo(0.60f, SimHashes.Wolframite),
                new BandInfo(0.65f, SimHashes.AluminumOre),
                new BandInfo(0.70f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.73f, SimHashes.MaficRock),
                new BandInfo(0.77f, SimHashes.Lead),
                new BandInfo(0.82f, SimHashes.GoldAmalgam),
                new BandInfo(0.85f, SimHashes.MaficRock),
                new BandInfo(1.00f, SimHashes.Copper),
            });
    }
}
