using ProcGen;
using System.Collections.Generic;

namespace SharlesPlants
{
    public class SharlesPlantsTuning
    {
        public static bool DebugMode = false;
        public static string Version = "1.0.2";

        public static EffectorValues WiltDecor = TUNING.DECOR.PENALTY.TIER3;
        public static EffectorValues LowDecor = new EffectorValues() { amount = 10, radius = 3 };
        public static EffectorValues StandardDecor = new EffectorValues() { amount = 20, radius = 3 };
        public static EffectorValues MediumDecor = new EffectorValues() { amount = 40, radius = 5 };
        public static EffectorValues HighDecor = new EffectorValues() { amount = 70, radius = 6 };
        public static EffectorValues AmazingDecor = new EffectorValues() { amount = 100, radius = 7 };

        // Prickly Lotus tuning
        public static PlantTuning PricklyLotusTuning = new PlantTuning
        {
            density = new MinMax(0.08f, 0.14f),
            lethalLow = 263.15f,            // -10C
            warningLow = 283.15f,           //  10C
            transitionLow = 303.15f,        //  30C
            transitionHigh = 323.15f,       //  50C
            warningHigh = 363.15f,          //  90C
            lethalhigh = 393.15f,           // 120C
            defaultTemperature = 298.15f,   //  25C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Hydrogen,
                SimHashes.ChlorineGas,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Sedimentary/Desert",
                "biomes/Jungle/Basic",
                "biomes/Jungle/Toxic",
                "biomes/Jungle/Solid",
                "biomes/Oil/OilPockets",
                "biomes/Oil/OilField",
                "biomes/Oil/OilPatch",
                "biomes/Oil/OilDry",
            },
            spawnLocation = Mob.Location.Floor,
        };

        // Frost Blossom tuning
        public static PlantTuning FrostBlossomTuning = new PlantTuning
        {
            density = new MinMax(0.1f, 0.18f),
            lethalLow = 183.15f,            // -90C
            warningLow = 213.15f,           // -60C
            transitionLow = 253.15f,        // -20C
            transitionHigh = 273.15f,       //   0C
            warningHigh = 283.15f,          //  10C
            lethalhigh = 303.15f,           //  30C
            defaultTemperature = 275.15f,   //   2C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = AmazingDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Frozen/Wet",
                "biomes/Frozen/Dry",
                "biomes/Frozen/Solid",
            },
            spawnLocation = Mob.Location.Floor,
        };

        // Icy Shroom tuning
        public static PlantTuning IcyShroomTuning = new PlantTuning
        {
            density = new MinMax(0.1f, 0.18f),
            lethalLow = 193.15f,            // -80C
            warningLow = 233.15f,           // -40C
            transitionLow = 268.15f,        //  -5C
            transitionHigh = 281.15f,       //   8C
            warningHigh = 291.15f,          //  18C
            lethalhigh = 303.15f,           //  30C
            defaultTemperature = 283.15f,   //  10C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Frozen/Wet",
                "biomes/Frozen/Dry",
                "biomes/Frozen/Solid",
            },
            spawnLocation = Mob.Location.Floor,
        };

        // Myrth Rose tuning
        public static PlantTuning MyrthRoseTuning = new PlantTuning
        {
            density = new MinMax(0.08f, 0.12f),
            lethalLow = 273.15f,            //   0C
            warningLow = 288.15f,           //  15C
            transitionLow = 295.15f,        //  22C
            transitionHigh = 309.15f,       //  36C
            warningHigh = 328.15f,          //  55C
            lethalhigh = 348.15f,           //  75C
            defaultTemperature = 293.15f,   //  20C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Hydrogen,
                SimHashes.ChlorineGas,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Sedimentary/Basic",
                "biomes/Sedimentary/Basic_CO2",
                "biomes/Sedimentary/Metal_CO2",
                "biomes/Sedimentary/Lake_Oxygen",
                "biomes/Sedimentary/Lake_CO2",
                "biomes/Sedimentary/Desert",
                "biomes/Forest/Basic",
                "biomes/Forest/BasicOxy",
                "biomes/Forest/Metal",
                "biomes/Jungle/Basic",
                "biomes/Jungle/Toxic",
                "biomes/Jungle/Solid",
                "biomes/HotMarsh/Basic",
                "biomes/HotMarsh/Dry",
            },
            spawnLocation = Mob.Location.Floor,
        };

        // Rust Fern tuning
        public static PlantTuning RustFernTuning = new PlantTuning
        {
            density = new MinMax(0.13f, 0.20f),
            lethalLow = 243.15f,            // -30C
            warningLow = 258.15f,           // -15C
            transitionLow = 307.15f,        //  34C
            transitionHigh = 321.15f,       //  48C
            warningHigh = 335.15f,          //  62C
            lethalhigh = 353.15f,           //  80C
            defaultTemperature = 308.15f,   //  35C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = HighDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Hydrogen,
                SimHashes.ChlorineGas,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Rust/Basic",
                "biomes/Rust/Snowy",
                "biomes/Rust/Sulfurous",
                "biomes/Ocean/Basic",
                "biomes/Ocean/Dry",
                "biomes/Ocean/Briny",
                "biomes/Ocean/Frozen",
                "biomes/Ocean/Deep",
            },
            spawnLocation = Mob.Location.Floor,
        };

        // Spore Lamp tuning
        public static PlantTuning SporeLampTuning = new PlantTuning
        {
            density = new MinMax(0.18f, 0.28f),
            lethalLow = 263.15f,            // -10C
            warningLow = 278.15f,           //   5C
            transitionTemp = 301.15f,       //  28C
            warningHigh = 361.15f,          //  88C
            lethalhigh = 383.15f,           // 110C
            defaultTemperature = 298.15f,   //  25C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = AmazingDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Methane,
                SimHashes.SourGas,
                SimHashes.Hydrogen,
                SimHashes.EthanolGas,
            },
            biomes = new HashSet<string>()
            {
                "biomes/HotMarsh/Basic",
                "biomes/HotMarsh/Dry",
            },
            spawnLocation = Mob.Location.Floor,
        };

        // Tropicalgae tuning
        public static PlantTuning TropicalgaeTuning = new PlantTuning
        {
            density = new MinMax(0.18f, 0.28f),
            lethalLow = 263.15f,            // -10C
            warningLow = 283.15f,           //  10C
            transitionTemp = 303.15f,       //  30C
            warningHigh = 328.15f,          //  55C
            lethalhigh = 353.15f,           //  80C
            defaultTemperature = 298.15f,   //  25C
            juvenileDecor = LowDecor,
            matureDecor = StandardDecor,
            flourishingDecor = MediumDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Water,
                SimHashes.DirtyWater,
                SimHashes.SaltWater,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Sedimentary/Basic",
                "biomes/Sedimentary/Basic_CO2",
                "biomes/Sedimentary/Metal_CO2",
                "biomes/Sedimentary/Lake_Oxygen",
                "biomes/Sedimentary/Lake_CO2",
                "biomes/Sedimentary/Desert",
                "biomes/Forest/Basic",
                "biomes/Forest/BasicOxy",
                "biomes/Forest/Metal",
                "biomes/HotMarsh/Basic",
                "biomes/HotMarsh/Dry",
                "biomes/Ocean/Basic",
                "biomes/Ocean/Dry",
                "biomes/Ocean/Briny",
                "biomes/Ocean/Frozen",
                "biomes/Ocean/Deep",
            },
            spawnLocation = Mob.Location.LiquidFloor,
        };

        // Shlurp Coral tuning
        public static PlantTuning ShlurpCoralTuning = new PlantTuning
        {
            density = new MinMax(0.18f, 0.28f),
            lethalLow = 263.15f,            // -10C
            warningLow = 288.15f,           //  15C
            transitionTemp = 305.15f,       //  32C
            warningHigh = 322.15f,          //  49C
            lethalhigh = 348.15f,           //  75C
            defaultTemperature = 303.15f,   //  30C
            juvenileDecor = StandardDecor,
            matureDecor = MediumDecor,
            flourishingDecor = AmazingDecor,
            safeElements = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.Water,
                SimHashes.DirtyWater,
                SimHashes.SaltWater,
            },
            biomes = new HashSet<string>()
            {
                "biomes/Ocean/Basic",
                "biomes/Ocean/Dry",
                "biomes/Ocean/Briny",
                "biomes/Ocean/Frozen",
                "biomes/Ocean/Deep",
            },
            spawnLocation = Mob.Location.LiquidFloor,
        };

        public struct PlantTuning
        {
            public MinMax density;
            public float lethalLow;
            public float warningLow;
            public float transitionLow;
            public float transitionTemp;
            public float transitionHigh;
            public float warningHigh;
            public float lethalhigh;
            public float defaultTemperature;
            public EffectorValues juvenileDecor;
            public EffectorValues matureDecor;
            public EffectorValues flourishingDecor;
            public SimHashes[] safeElements;
            public ISet<string> biomes;
            public Mob.Location spawnLocation;
        }
    }
}