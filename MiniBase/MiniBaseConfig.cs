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
        public static int CORE_MIN = 3;
        public static int CORE_MAX = 6;
        public static int CORE_BORDER = 3;

        // DEBUG
        public static bool DEBUG_MODE = true;
        public static bool FAST_IMMIGRATION = false;
        public static bool TEST_NOISEMAPS = false;
        public static bool SKIP_LIVEABLE_AREA = false;

        public static Dictionary<BaseSize, Vector2I> BaseSizeDictionary = new Dictionary<BaseSize, Vector2I>()
        {
            { BaseSize.Tiny, new Vector2I(30, 20) },
            { BaseSize.Small, new Vector2I(50, 30) },
            { BaseSize.Normal, new Vector2I(70, 40) },
            { BaseSize.Large, new Vector2I(90, 50) },
            { BaseSize.SkinnyMid, new Vector2I(26, 70) },
            { BaseSize.SkinnyTall, new Vector2I(26, 100) },
            { BaseSize.NormalMid, new Vector2I(40, 70) },
            { BaseSize.NormalTall, new Vector2I(40, 100) },
            { BaseSize.LargeSquare, new Vector2I(90, 90) },
        };

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
            FeatureType.SmallVolcano,
            FeatureType.Volcano,
            FeatureType.Copper,
            FeatureType.Gold,
            FeatureType.Iron,
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
