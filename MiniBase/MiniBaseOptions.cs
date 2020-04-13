using Newtonsoft.Json;
using PeterHan.PLib;
using PeterHan.PLib.Options;
using System.Collections.Generic;
using static MiniBase.Profiles.MiniBaseBiomeProfiles;
using static MiniBase.Profiles.MiniBaseCoreBiomeProfiles;

namespace MiniBase
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MiniBaseOptions : POptions.SingletonOptions<MiniBaseOptions>
    {
        [Option("These options are only applied when the map is generated,\nwith the exception of Steam Turbines.\n ")]
        public LocText Header { get; }

        [Option("Western Feature", "The geyser, vent, or volcano on the left side of the map.")]
        [JsonProperty]
        public FeatureType FeatureWest { get; set; }

        [Option("Eastern Feature", "The geyser, vent, or volcano on the right side of the map.")]
        [JsonProperty]
        public FeatureType FeatureEast { get; set; }

        [Option("Core Feature", "The geyser, vent, or volcano at the bottom of the map.\nInaccessible until the abyssalite boundary is breached.")]
        [JsonProperty]
        public FeatureType FeatureSouth { get; set; }

        [Option("Biome", "The main biome of the map.\nDetermines available resources, flora, and fauna.")]
        [JsonProperty]
        public BiomeType Biome { get; set; }

        [Option("Planet Core", "The auxiliary biome at the bottom of the map.\nProtected by a layer of abyssalite.")]
        [JsonProperty]
        public CoreType CoreBiome { get; set; }

        [Option("Resource Density", "Modifies the density of available resources.")]
        [JsonProperty]
        public ResourceModifier ResourceMod { get; set; }

        [Option("Space Access", "Allows renewable resources to be collected from meteorites.\nDoes not increase the building area.")]
        [JsonProperty]
        public bool SpaceAccess { get; set; }

        [Option("Disable Steam Turbines", "Prevents steam turbines from being built.\nAlternative cooling methods will be required.")]
        [JsonProperty]
        public bool TurbinesDisabled { get; set; }

        public MiniBaseOptions()
        {
            FeatureWest = FeatureType.RandomWater;
            FeatureEast = FeatureType.RandomUseful;
            FeatureSouth = FeatureType.None;
            Biome = BiomeType.Sandstone;
            CoreBiome = CoreType.Magma;
            ResourceMod = ResourceModifier.Normal;
            SpaceAccess = true;
            TurbinesDisabled = true;
        }

        public static void Reload()
        {
            Instance = POptions.ReadSettings<MiniBaseOptions>();
        }

        public MiniBaseBiomeProfile GetBiome()
        {
            return BiomeTypeMap.ContainsKey(Biome) ? BiomeTypeMap[Biome] : SandstoneProfile;
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
            [Option("Random (Useful)", "Random water, power, volcano, or metal feature\nExcludes features like chlorine, CO2, etc")]
            RandomUseful,
            [Option("Random (Volcano)", "Random lava or metal volcano")]
            RandomVolcano,
            None,
        }

        public enum BiomeType
        {
            Sandstone,
            Forest,
            Swamp,
            Frozen,
            Desert,
            Barren,
            [Option("Str?nge", "A random hodgepodge of all kinds of things with no discernable order")]
            Strange,
        }

        private static Dictionary<BiomeType, MiniBaseBiomeProfile> BiomeTypeMap = new Dictionary<BiomeType, MiniBaseBiomeProfile>()
        {
            { BiomeType.Sandstone, SandstoneProfile },
            { BiomeType.Forest, ForestProfile },
            { BiomeType.Swamp, SwampProfile },
            { BiomeType.Frozen, FrozenProfile },
            { BiomeType.Desert, DesertProfile },
            { BiomeType.Barren, BarrenProfile },
            { BiomeType.Strange, StrangeProfile },
        };

        public enum CoreType
        {
            [Option("Molten", "Magma, diamond, and a smattering of tough metals")]
            Magma,
            [Option("Ocean", "Saltwater, bleachstone, sand, and crabs")]
            Ocean,
            [Option("Frozen", "Cold, cold, and more cold")]
            Frozen,
            [Option("Metal", "Ores and metals of all varieties")]
            Metal,
            [Option("None", "No core or abyssalite border")]
            None,
        }

        private static Dictionary<CoreType, MiniBaseBiomeProfile> CoreTypeMap = new Dictionary<CoreType, MiniBaseBiomeProfile>()
        {
            { CoreType.Magma, MagmaCoreProfile },
            { CoreType.Ocean, OceanCoreProfile },
            { CoreType.Frozen, FrozenCoreProfile },
            { CoreType.Metal, MetalCoreProfile },
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
    }
}
