using Newtonsoft.Json;
using PeterHan.PLib.Options;
using System.Collections.Generic;
using static MiniBase.Profiles.MiniBaseBiomeProfiles;
using static MiniBase.Profiles.MiniBaseCoreBiomeProfiles;

namespace MiniBase
{
    [ConfigFile("config.json", true)]
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class MiniBaseOptions
    {
        public static MiniBaseOptions Instance { get; private set; }

        private const string WorldGenCategory = "These options are only applied when the map is generated";
        private const string SizeCategory = "These options change the size of the liveable area\nTo define a custom size, set Map Size to 'Custom'";
        private const string AnytimeCategory = "These options may be changed at any time";

        [Option("Western Feature", "The geyser, vent, or volcano on the left side of the map", WorldGenCategory)]
        [JsonProperty]
        public FeatureType FeatureWest { get; set; }

        [Option("Eastern Feature", "The geyser, vent, or volcano on the right side of the map", WorldGenCategory)]
        [JsonProperty]
        public FeatureType FeatureEast { get; set; }

        [Option("Southern Feature", "The geyser, vent, or volcano at the bottom of the map\nInaccessible until the abyssalite boundary is breached", WorldGenCategory)]
        [JsonProperty]
        public FeatureType FeatureSouth { get; set; }

        [Option("Main Biome", "The main biome of the map\nDetermines available resources, flora, and fauna", WorldGenCategory)]
        [JsonProperty]
        public BiomeType Biome { get; set; }

        //[Option("Side Biomes", "The areas outside the liveable area.\nThis is a purely aesthetic option.", WorldGenCategory)]
        //[JsonProperty]
        public SideType SideBiome { get; set; }

        [Option("Southern Biome", "The small biome at the bottom of the map\nProtected by a layer of abyssalite", WorldGenCategory)]
        [JsonProperty]
        public CoreType CoreBiome { get; set; }
        
        [Option("Resource Density", "Modifies the density of available resources", WorldGenCategory)]
        [JsonProperty]
        public ResourceModifier ResourceMod { get; set; }

        [Option("Space Access", "Allows renewable resources to be collected from meteorites\nDoes not significantly increase the liveable area", WorldGenCategory)]
        [JsonProperty]
        public AccessType SpaceAccess { get; set; }

        [Option("Map Size", "The size of the liveable area\nSelect 'Custom' to define a custom size", SizeCategory)]
        [JsonProperty]
        public BaseSize Size { get; set; }

        [Option("Custom Width", "The width of the liveable area\nMap Size must be set to 'Custom' for this to apply", SizeCategory)]
        [Limit(20, 100)]
        [JsonProperty]
        public int CustomWidth { get; set; }

        [Option("Custom Height", "The height of the liveable area\nMap Size must be set to 'Custom' for this to apply", SizeCategory)]
        [Limit(20, 100)]
        [JsonProperty]
        public int CustomHeight { get; set; }

        [Option("Care Package Timer (Cycles)", "Period of care package drops, in cycles\nLower values give more frequent drops", AnytimeCategory)]
        [Limit(1, 10)]
        [JsonProperty]
        public int CarePackageFrequency { get; set; }

        #region Debug

        [JsonProperty]
        public bool DebugMode;
        [JsonProperty]
        public bool FastImmigration;
        [JsonProperty]
        public bool SkipLiveableArea;

        #endregion

        public MiniBaseOptions()
        {
            FeatureWest = FeatureType.PollutedWater;
            FeatureEast = FeatureType.RandomUseful;
            FeatureSouth = FeatureType.OilReservoir;
            Biome = BiomeType.Temperate;
            CoreBiome = CoreType.Magma;
            SideBiome = SideType.Space;
            ResourceMod = ResourceModifier.Normal;
            SpaceAccess = AccessType.Classic;
            Size = BaseSize.Normal;
            CustomWidth = 70;
            CustomHeight = 40;
            CarePackageFrequency = 2;

            DebugMode = false;
            FastImmigration = false;
            SkipLiveableArea = false;
        }

        public static void Reload()
        {
            Instance = POptions.ReadSettings<MiniBaseOptions>() ?? new MiniBaseOptions();
        }

        public Vector2I GetBaseSize()
        {
            if (Size == BaseSize.Custom)
                return new Vector2I(CustomWidth, CustomHeight);
            return BaseSizeDictionary.ContainsKey(Size) ? BaseSizeDictionary[Size] : BaseSizeDictionary[BaseSize.Normal];
        }

        public MiniBaseBiomeProfile GetBiome()
        {
            return BiomeTypeMap.ContainsKey(Biome) ? BiomeTypeMap[Biome] : TemperateProfile;
        }

        public bool HasCore() { return CoreBiome != CoreType.None; }

        public MiniBaseBiomeProfile GetCoreBiome()
        {
            return HasCore() ? CoreTypeMap[CoreBiome] : MagmaCoreProfile;
        }

        public float GetResourceModifier()
        {
            switch(ResourceMod)
            {
                case ResourceModifier.Poor: return 0.5f;
                case ResourceModifier.Normal: return 1.0f;
                case ResourceModifier.Rich: return 1.5f;
                default: return 1.0f;
            }
        }

        public enum FeatureType
        {
            [Option("Warm Water", "95C fresh water geyser")]
            WarmWater,
            [Option("Salt Water", "95C salt water geyser")]
            SaltWater,
            [Option("Polluted Water", "30C polluted water geyser")]
            PollutedWater,
            [Option("Cool Slush", "-10C polluted water geyser")]
            CoolSlush,
            [Option("Cool Steam", "110C steam vent")]
            CoolSteam,
            [Option("Hot Steam", "500C steam vent")]
            HotSteam,
            [Option("Natural Gas", "150C natural gas vent")]
            NaturalGas,
            [Option("Hydrogen", "500C hydrogen vent")]
            Hydrogen,
            [Option("Oil Fissure", "327C leaky oil fissure")]
            OilFissure,
            [Option("Oil Reservoir", "Requires an oil well to extract 90C+ crude oil")]
            OilReservoir,
            [Option("Minor Volcano", "Minor volcano")]
            SmallVolcano,
            [Option("Volcano", "Standard volcano")]
            Volcano,
            [Option("Copper Volcano", "Copper volcano")]
            Copper,
            [Option("Gold Volcano", "Gold volcano")]
            Gold,
            [Option("Iron Volcano", "Iron volcano")]
            Iron,
            [Option("CO2 Geyser", "-55C carbon dioxide geyser")]
            ColdCO2,
            [Option("CO2 Vent", "500C carbon dioxide vent")]
            HotCO2,
            [Option("Infectious PO2", "60C infectious polluted oxygen vent")]
            InfectedPO2,
            [Option("Hot PO2 Vent", "500C polluted oxygen vent")]
            HotPO2,
            [Option("Chlorine Vent", "60C chlorine vent")]
            Chlorine,
            [Option("Random (Any)", "It could be anything!")]
            RandomAny,
            [Option("Random (Water)", "Warm water, salt water, polluted water, or cool slush geyser")]
            RandomWater,
            [Option("Random (Useful)", "Random water or power feature\nExcludes volcanoes and features like chlorine, CO2, etc")]
            RandomUseful,
            [Option("Random (Volcano)", "Random lava or metal volcano")]
            RandomVolcano,
            None,
        }

        public enum BaseSize
        {
            [Option("Tiny", "30x20")]
            Tiny,
            [Option("Small", "50x40")]
            Small,
            [Option("Normal", "70x40")]
            Normal,
            [Option("Large", "90x50")]
            Large,
            [Option("Square", "50x50")]
            Square,
            [Option("Medium Square", "70x70")]
            MediumSquare,
            [Option("Large Square", "90x90")]
            LargeSquare,
            [Option("Inverted", "40x70")]
            Inverted,
            [Option("Tall", "40x100")]
            Tall,
            [Option("Skinny", "26x100")]
            Skinny,
            [Option("Custom", "Select to define custom size")]
            Custom,
        }

        private static Dictionary<BaseSize, Vector2I> BaseSizeDictionary = new Dictionary<BaseSize, Vector2I>()
        {
            { BaseSize.Tiny, new Vector2I(30, 20) },
            { BaseSize.Small, new Vector2I(50, 30) },
            { BaseSize.Normal, new Vector2I(70, 40) },
            { BaseSize.Large, new Vector2I(90, 50) },
            { BaseSize.Square, new Vector2I(50, 50) },
            { BaseSize.MediumSquare, new Vector2I(70, 70) },
            { BaseSize.LargeSquare, new Vector2I(90, 90) },
            { BaseSize.Inverted, new Vector2I(40, 70) },
            { BaseSize.Tall, new Vector2I(40, 100) },
            { BaseSize.Skinny, new Vector2I(26, 100) },
        };

        public enum BiomeType
        {
            [Option("Temperate", "Inviting and inhabitable")]
            Temperate,
            [Option("Forest", "Temperate and earthy")]
            Forest,
            [Option("Swamp", "Beware the slime!")]
            Swamp,
            [Option("Frozen", "Cold, but at least you get some jackets")]
            Frozen,
            [Option("Desert", "Hot and sandy")]
            Desert,
            [Option("Barren", "Hard rocks, hard hatches, hard to survive")]
            Barren,
            [Option("Str?nge", "#%*@&#^$%(_#$&%^#@*&")]
            Strange,
            [Option("Deep Essence", "Filled with vibes")]
            DeepEssence,
        }

        private static Dictionary<BiomeType, MiniBaseBiomeProfile> BiomeTypeMap = new Dictionary<BiomeType, MiniBaseBiomeProfile>()
        {
            { BiomeType.Temperate, TemperateProfile },
            { BiomeType.Forest, ForestProfile },
            { BiomeType.Swamp, SwampProfile },
            { BiomeType.Frozen, FrozenProfile },
            { BiomeType.Desert, DesertProfile },
            { BiomeType.Barren, BarrenProfile },
            { BiomeType.Strange, StrangeProfile },
            { BiomeType.DeepEssence, DeepEssenceProfile },
        };

        public enum CoreType
        {
            [Option("Molten", "Magma, diamond, and a smattering of tough metals")]
            Magma,
            [Option("Ocean", "Saltwater, bleachstone, sand, and crabs")]
            Ocean,
            [Option("Frozen", "Cold, cold, and more cold")]
            Frozen,
            [Option("Oil", "A whole lot of crude")]
            Oil,
            [Option("Metal", "Ores and metals of all varieties")]
            Metal,
            [Option("Fertile", "Dirt, water, algae, and iron")]
            Fertile,
            [Option("Boneyard", "Cool remains of an ancient world")]
            Boneyard,
            [Option("Aesthetic", "Filled with  V I B E S")]
            Aesthetic,
            [Option("Pearl Inferno", "Molten inferno of aluminum, glass, steam, \nand some high temperature materials")]
            Pearl,
            [Option("None", "No core or abyssalite border")]
            None,
        }

        private static Dictionary<CoreType, MiniBaseBiomeProfile> CoreTypeMap = new Dictionary<CoreType, MiniBaseBiomeProfile>()
        {
            { CoreType.Magma, MagmaCoreProfile },
            { CoreType.Ocean, OceanCoreProfile },
            { CoreType.Frozen, FrozenCoreProfile },
            { CoreType.Oil, OilCoreProfile },
            { CoreType.Metal, MetalCoreProfile },
            { CoreType.Fertile, FertileCoreProfile },
            { CoreType.Boneyard, BoneyardCoreProfile },
            { CoreType.Aesthetic, AestheticCoreProfile },
            { CoreType.Pearl, PearlCoreProfile },
        };

        public enum ResourceModifier
        {
            [Option("Poor", "50% fewer resources")]
            Poor,
            [Option("Normal", "Standard amount of resources")]
            Normal,
            [Option("Rich", "50% more resources")]
            Rich,
        }

        public enum AccessType
        {
            [Option("None", "Fully contained and protected")]
            None,
            [Option("Classic", "Limited space access ports")]
            Classic,
            [Option("Full", "Space access across the top border")]
            Full,
        }

        public enum SideType
        {
            Space,
            Terrain,
        }
    }
}
