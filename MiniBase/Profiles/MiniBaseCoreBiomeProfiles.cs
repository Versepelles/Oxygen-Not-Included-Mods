using System.Collections.Generic;

namespace MiniBase.Profiles
{
    class MiniBaseCoreBiomeProfiles
    {
        public static MiniBaseBiomeProfile MagmaCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Katairite,
            1998f,
            new BandInfo[]
            {
                new BandInfo(0.19f, SimHashes.Diamond),
                new BandInfo(0.23f, SimHashes.Magma),
                new BandInfo(0.27f, SimHashes.Diamond),
                new BandInfo(0.35f, SimHashes.Magma),
                new BandInfo(0.38f, SimHashes.Tungsten),
                new BandInfo(0.40f, SimHashes.Wolframite),
                new BandInfo(0.45f, SimHashes.Diamond),
                new BandInfo(0.52f, SimHashes.Magma),
                new BandInfo(0.53f, SimHashes.Diamond),
                new BandInfo(0.57f, SimHashes.Magma),
                new BandInfo(0.61f, SimHashes.Diamond),
                new BandInfo(0.63f, SimHashes.RefinedCarbon),
                new BandInfo(0.65f, SimHashes.Steel),
                new BandInfo(0.72f, SimHashes.Magma),
                new BandInfo(0.77f, SimHashes.Diamond),
                new BandInfo(0.81f, SimHashes.Magma),
                new BandInfo(1.00f, SimHashes.Diamond),
            });

        public static MiniBaseBiomeProfile FrozenCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Ice,
            233f,
            new BandInfo[]
            {
                new BandInfo(0.19f, SimHashes.Oxygen),
                new BandInfo(0.22f, SimHashes.Snow),
                new BandInfo(0.27f, SimHashes.Ice),
                new BandInfo(0.30f, SimHashes.CarbonDioxide),
                new BandInfo(0.35f, SimHashes.Ice),
                new BandInfo(0.40f, SimHashes.Wolframite),
                new BandInfo(0.45f, SimHashes.Ice),
                new BandInfo(0.50f, SimHashes.Snow),
                new BandInfo(0.53f, SimHashes.Oxygen),
                new BandInfo(0.55f, SimHashes.Snow),
                new BandInfo(0.60f, SimHashes.Ice),
                new BandInfo(0.63f, SimHashes.Oxygen),
                new BandInfo(0.66f, SimHashes.CarbonDioxide),
                new BandInfo(0.70f, SimHashes.Ice),
                new BandInfo(0.77f, SimHashes.Snow),
                new BandInfo(0.81f, SimHashes.Ice),
                new BandInfo(1.00f, SimHashes.CarbonDioxide),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBugBlueBaby", 0.10f },
                { "ColdWheat", 0.15f },
                { "ColdBreather", 0.10f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "ColdBreatherSeed", 0.005f },
            });

        public static MiniBaseBiomeProfile OceanCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Salt,
            -1f,
            new BandInfo[]
            {
                new BandInfo(0.19f, SimHashes.SaltWater),
                new BandInfo(0.25f, SimHashes.Sand),
                new BandInfo(0.32f, SimHashes.Salt),
                new BandInfo(0.35f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.38f, SimHashes.Salt),
                new BandInfo(0.40f, SimHashes.BleachStone, density: 4f),
                new BandInfo(0.45f, SimHashes.Sand),
                new BandInfo(0.50f, SimHashes.SaltWater),
                new BandInfo(0.52f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.55f, SimHashes.Sand),
                new BandInfo(0.61f, SimHashes.Salt),
                new BandInfo(0.64f, SimHashes.ChlorineGas, density: 2f),
                new BandInfo(0.66f, SimHashes.Hydrogen, density: 2f),
                new BandInfo(0.73f, SimHashes.SaltWater),
                new BandInfo(0.80f, SimHashes.Salt),
                new BandInfo(0.85f, SimHashes.BleachStone, density: 4f),
                new BandInfo(1.00f, SimHashes.ChlorineGas),
            },
            spawnablesOnFloor:
            new Dictionary<string, float>()
            {
                { "LightBugPinkBaby", 0.12f },
                { "Crab", 0.08f },
            },
            spawnablesInGround:
            new Dictionary<string, float>()
            {
                { "SeaLettuceSeed", 0.015f },
                { "SpiceVineSeed", 0.015f },
            },
            spawnablesInLiquid:
            new Dictionary<string, float>()
            {
                { "Pacu", 0.05f },
                { "Crab", 0.02f },
            });

        public static MiniBaseBiomeProfile MetalCoreProfile = new MiniBaseBiomeProfile(
            null,
            SimHashes.Iron,
            483f,
            new BandInfo[]
            {
                new BandInfo(0.15f, SimHashes.IronOre),
                new BandInfo(0.25f, SimHashes.Wolframite),
                new BandInfo(0.30f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.34f, SimHashes.MaficRock),
                new BandInfo(0.37f, SimHashes.AluminumOre),
                new BandInfo(0.40f, SimHashes.GoldAmalgam),
                new BandInfo(0.44f, SimHashes.MaficRock),
                new BandInfo(0.47f, SimHashes.FoolsGold),
                new BandInfo(0.50f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.53f, SimHashes.MaficRock),
                new BandInfo(0.56f, SimHashes.IronOre),
                new BandInfo(0.60f, SimHashes.Wolframite),
                new BandInfo(0.65f, SimHashes.AluminumOre),
                new BandInfo(0.70f, SimHashes.SourGas, density: 4f),
                new BandInfo(0.73f, SimHashes.MaficRock),
                new BandInfo(0.76f, SimHashes.Lead),
                new BandInfo(0.80f, SimHashes.GoldAmalgam),
                new BandInfo(0.85f, SimHashes.MaficRock),
                new BandInfo(1.00f, SimHashes.Copper),
            });
    }
}
