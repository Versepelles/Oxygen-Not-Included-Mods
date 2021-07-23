using System.Collections.Generic;
using static MiniBase.MiniBaseOptions;

namespace MiniBase
{
    public class MiniBaseConfig
    {
        public static int WORLD_WIDTH = 128;
        public static int WORLD_HEIGHT = 128;
        public static int BORDER_SIZE = 3;
        public static int TOP_MARGIN = 3;
        public static int CORNER_SIZE = 7;
        public static int DIAGONAL_BORDER_SIZE = 4;

        public static int SPACE_ACCESS_SIZE = 8;
        public static int CORE_MIN = 0;
        public static int CORE_DEVIATION = 3;
        public static int CORE_BORDER = 3;

        public enum DiseaseID { NONE, SLIMELUNG, FOOD_POISONING };

        public static string ClusterName = "MiniBase";
        public static string ClusterDescription = "An encapsulated location with just enough to get by.\n\n<smallcaps>Customize this location by clicking MiniBase Options in the Mods menu.</smallcaps>\n\n";
        public static string ClusterIconName = "Asteroid_minibase";

        public static Dictionary<FeatureType, string> GeyserDictionary = new Dictionary<FeatureType, string>()
        {
            { FeatureType.WarmWater, "GeyserGeneric_" + GeyserGenericConfig.HotWater },
            { FeatureType.SaltWater, "GeyserGeneric_" + GeyserGenericConfig.SaltWater },
            { FeatureType.PollutedWater, "GeyserGeneric_" + GeyserGenericConfig.FilthyWater },
            { FeatureType.CoolSlush, "GeyserGeneric_" + GeyserGenericConfig.SlushWater },
            { FeatureType.CoolSteam, "GeyserGeneric_" + GeyserGenericConfig.Steam },
            { FeatureType.HotSteam, "GeyserGeneric_" + GeyserGenericConfig.HotSteam },
            { FeatureType.NaturalGas, "GeyserGeneric_" + GeyserGenericConfig.Methane },
            { FeatureType.Hydrogen, "GeyserGeneric_" + GeyserGenericConfig.HotHydrogen },
            { FeatureType.OilFissure, "GeyserGeneric_" + GeyserGenericConfig.OilDrip },
            { FeatureType.OilReservoir, "OilWell" },
            { FeatureType.SmallVolcano, "GeyserGeneric_" + GeyserGenericConfig.SmallVolcano },
            { FeatureType.Volcano, "GeyserGeneric_" + GeyserGenericConfig.BigVolcano },
            { FeatureType.Copper, "GeyserGeneric_" + GeyserGenericConfig.MoltenCopper },
            { FeatureType.Gold, "GeyserGeneric_" + GeyserGenericConfig.MoltenGold },
            { FeatureType.Iron, "GeyserGeneric_" + GeyserGenericConfig.MoltenIron },
            { FeatureType.ColdCO2, "GeyserGeneric_" + GeyserGenericConfig.LiquidCO2 },
            { FeatureType.HotCO2, "GeyserGeneric_" + GeyserGenericConfig.HotCO2 },
            { FeatureType.InfectedPO2, "GeyserGeneric_" + GeyserGenericConfig.SlimyPO2 },
            { FeatureType.HotPO2, "GeyserGeneric_" + GeyserGenericConfig.HotPO2 },
            { FeatureType.Chlorine, "GeyserGeneric_" + GeyserGenericConfig.ChlorineGas },
        };

        public static FeatureType[] RandomWaterFeatures =
        {
            FeatureType.WarmWater,
            FeatureType.SaltWater,
            FeatureType.PollutedWater,
            FeatureType.CoolSlush,
        };

        public static FeatureType[] RandomUsefulFeatures =
        {
            FeatureType.WarmWater,
            FeatureType.SaltWater,
            FeatureType.PollutedWater,
            FeatureType.CoolSlush,
            FeatureType.CoolSteam,
            FeatureType.HotSteam,
            FeatureType.NaturalGas,
            FeatureType.Hydrogen,
            FeatureType.OilFissure,
            FeatureType.OilReservoir,
        };

        public static FeatureType[] RandomVolcanoFeatures =
        {
            FeatureType.SmallVolcano,
            FeatureType.Volcano,
            FeatureType.Copper,
            FeatureType.Gold,
            FeatureType.Iron,
        };
    }
}
