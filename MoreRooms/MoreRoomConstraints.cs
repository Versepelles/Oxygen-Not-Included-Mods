using ProcGen;
using STRINGS;
using System.Collections.Generic;
using RSTRINGS = MoreRooms.MoreRoomStrings.ROOMS.CRITERIA;

namespace MoreRooms
{
    class MoreRoomConstraints
    {
        public static RoomConstraints.Constraint OneBed;
        public static RoomConstraints.Constraint Grill;
        public static RoomConstraints.Constraint GasRange;
        public static RoomConstraints.Constraint Coffee;
        public static RoomConstraints.Constraint Arcade;
        public static RoomConstraints.Constraint ManualGenerator;
        public static RoomConstraints.Constraint HotTub;
        public static RoomConstraints.Constraint Sauna;
        public static RoomConstraints.Constraint Kiln;
        public static RoomConstraints.Constraint GlassForge;
        public static RoomConstraints.Constraint Loom;
        public static RoomConstraints.Constraint OilWell;
        public static RoomConstraints.Constraint OilRefinery;
        public static RoomConstraints.Constraint MarbleSculpture;
        public static RoomConstraints.Constraint Paintings;
        public static RoomConstraints.Constraint Pedestals;
        public static RoomConstraints.Constraint IceSculpture;
        public static RoomConstraints.Constraint Wheezewort;
        public static RoomConstraints.Constraint Shrooms;
        public static RoomConstraints.Constraint PitcherPump;
        public static RoomConstraints.Constraint Compost;
        public static RoomConstraints.Constraint Plants;
        public static RoomConstraints.Constraint SmoothHatch;
        public static RoomConstraints.Constraint GlossyDrecko;
        public static RoomConstraints.Constraint LonghairSlickster;
        public static RoomConstraints.Constraint Shinebugs;
        public static RoomConstraints.Constraint GassyMoo;
        public static RoomConstraints.Constraint GasGrass;
        public static RoomConstraints.Constraint ResearchStations;
        public static RoomConstraints.Constraint Planetarium;
        public static RoomConstraints.Constraint Telescope;
        public static RoomConstraints.Constraint Grave;
        public static RoomConstraints.Constraint StorageLockers;
        public static RoomConstraints.Constraint SmartStorageLocker;
        public static RoomConstraints.Constraint MaxSize32;

        private const int ShinebugSpeciesCount = 7;
        private static Dictionary<string, Tag> ShinebugSpecies = new Dictionary<string, Tag>()
        {
            { LightBugConfig.ID, ConstraintTags.YellowShinebug },
            { LightBugBabyConfig.ID, ConstraintTags.YellowShinebug },
            { LightBugOrangeConfig.ID, ConstraintTags.OrangeShinebug },
            { LightBugOrangeBabyConfig.ID, ConstraintTags.OrangeShinebug },
            { LightBugPurpleConfig.ID, ConstraintTags.PurpleShinebug },
            { LightBugPurpleBabyConfig.ID, ConstraintTags.PurpleShinebug },
            { LightBugPinkConfig.ID, ConstraintTags.PinkShinebug },
            { LightBugPinkBabyConfig.ID, ConstraintTags.PinkShinebug },
            { LightBugBlueConfig.ID, ConstraintTags.BlueShinebug },
            { LightBugBlueBabyConfig.ID, ConstraintTags.BlueShinebug },
            { LightBugBlackConfig.ID, ConstraintTags.BlackShinebug },
            { LightBugBlackBabyConfig.ID, ConstraintTags.BlackShinebug },
            { LightBugCrystalConfig.ID, ConstraintTags.WhiteShinebug },
            { LightBugCrystalBabyConfig.ID, ConstraintTags.WhiteShinebug },
        };

        public class ConstraintTags
        {
            public static Tag YellowShinebug = nameof(YellowShinebug).ToTag();
            public static Tag OrangeShinebug = nameof(OrangeShinebug).ToTag();
            public static Tag PurpleShinebug = nameof(PurpleShinebug).ToTag();
            public static Tag PinkShinebug = nameof(PinkShinebug).ToTag();
            public static Tag BlueShinebug = nameof(BlueShinebug).ToTag();
            public static Tag BlackShinebug = nameof(BlackShinebug).ToTag();
            public static Tag WhiteShinebug = nameof(WhiteShinebug).ToTag();
        }

        internal static void CreateRoomConstraints()
        {
            OneBed = new RoomConstraints.Constraint(null, room => {
                    int numBeds = 0;
                    foreach (KPrefabID building in room.buildings)
                        if (building.HasTag(RoomConstraints.ConstraintTags.LuxuryBed))
                            numBeds++;
                    return numBeds == 1;
                }, 1, RSTRINGS.PRIVATEQUARTERS.NAME, RSTRINGS.PRIVATEQUARTERS.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { RoomConstraints.TOILET, RoomConstraints.FLUSH_TOILET });
            Grill = new RoomConstraints.Constraint(bc => bc.PrefabID() == CookingStationConfig.ID, null, 1, RSTRINGS.GRILL.NAME, RSTRINGS.GRILL.DESCRIPTION);
            GasRange = new RoomConstraints.Constraint(bc => bc.PrefabID() == GourmetCookingStationConfig.ID, null, 1, RSTRINGS.GASRANGE.NAME, RSTRINGS.GASRANGE.DESCRIPTION);
            Arcade = new RoomConstraints.Constraint(bc => bc.PrefabID() == ArcadeMachineConfig.ID, null, 1, RSTRINGS.ARCADE.NAME, RSTRINGS.ARCADE.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { RoomConstraints.REC_BUILDING });
            ManualGenerator = new RoomConstraints.Constraint(bc => bc.PrefabID() == ManualGeneratorConfig.ID, null, 1, RSTRINGS.MANUALGENERATOR.NAME, RSTRINGS.MANUALGENERATOR.DESCRIPTION);
            HotTub = new RoomConstraints.Constraint(bc => bc.PrefabID() == HotTubConfig.ID, null, 1, RSTRINGS.HOTTUB.NAME, RSTRINGS.HOTTUB.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { RoomConstraints.REC_BUILDING });
            Sauna = new RoomConstraints.Constraint(bc => bc.PrefabID() == SaunaConfig.ID, null, 1, RSTRINGS.SAUNA.NAME, RSTRINGS.SAUNA.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { RoomConstraints.REC_BUILDING });
            Kiln = new RoomConstraints.Constraint(bc => bc.PrefabID() == KilnConfig.ID, null, 1, RSTRINGS.KILN.NAME, RSTRINGS.KILN.DESCRIPTION);
            GlassForge = new RoomConstraints.Constraint(bc => bc.PrefabID() == GlassForgeConfig.ID, null, 1, RSTRINGS.GLASSFORGE.NAME, RSTRINGS.GLASSFORGE.DESCRIPTION);
            Loom = new RoomConstraints.Constraint(bc => bc.PrefabID() == ClothingFabricatorConfig.ID, null, 1, RSTRINGS.LOOM.NAME, RSTRINGS.LOOM.DESCRIPTION);
            OilWell = new RoomConstraints.Constraint(bc => bc.PrefabID() == OilWellConfig.ID, null, 1, RSTRINGS.OILWELL.NAME, RSTRINGS.OILWELL.DESCRIPTION);
            OilRefinery = new RoomConstraints.Constraint(bc => bc.PrefabID() == OilRefineryConfig.ID, null, 1, RSTRINGS.OILREFINERY.NAME, RSTRINGS.OILREFINERY.DESCRIPTION);
            MarbleSculpture = new RoomConstraints.Constraint(bc => bc.PrefabID() == MarbleSculptureConfig.ID, null, 1, RSTRINGS.MARBLESCULTPURE.NAME, RSTRINGS.MARBLESCULTPURE.DESCRIPTION);
            Paintings = new RoomConstraints.Constraint(bc => {
                    return bc.PrefabID() == CanvasConfig.ID || bc.PrefabID() == CanvasTallConfig.ID || bc.PrefabID() == CanvasWideConfig.ID;
                }, null, RSTRINGS.PAINTINGS.COUNT, RSTRINGS.PAINTINGS.NAME, RSTRINGS.PAINTINGS.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { MarbleSculpture });
            Pedestals = new RoomConstraints.Constraint(bc => bc.PrefabID() == ItemPedestalConfig.ID, null, RSTRINGS.PEDESTALs.COUNT, RSTRINGS.PEDESTALs.NAME, RSTRINGS.PEDESTALs.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { MarbleSculpture });
            IceSculpture = new RoomConstraints.Constraint(bc => bc.PrefabID() == IceSculptureConfig.ID, null, 1, RSTRINGS.ICESCULPTURE.NAME, RSTRINGS.ICESCULPTURE.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { RoomConstraints.REC_BUILDING });
            Wheezewort = new RoomConstraints.Constraint(bc => bc.PrefabID() == ColdBreatherConfig.ID, null, 1, RSTRINGS.WHEEZEWORT.NAME, RSTRINGS.WHEEZEWORT.DESCRIPTION);
            Shrooms = new RoomConstraints.Constraint(bc => bc.PrefabID() == MushroomPlantConfig.ID, null, RSTRINGS.SHROOMS.COUNT, RSTRINGS.SHROOMS.NAME, RSTRINGS.SHROOMS.DESCRIPTION, stomp_in_conflict: new List<RoomConstraints.Constraint>() { RoomConstraints.FARM_STATION });
            Coffee = new RoomConstraints.Constraint(bc => bc.PrefabID() == EspressoMachineConfig.ID, null, 1, RSTRINGS.COFFEE.NAME, RSTRINGS.COFFEE.DESCRIPTION);
            PitcherPump = new RoomConstraints.Constraint(bc => bc.PrefabID() == LiquidPumpingStationConfig.ID, null, 1, RSTRINGS.PITCHERPUMP.NAME, RSTRINGS.PITCHERPUMP.DESCRIPTION);
            Compost = new RoomConstraints.Constraint(bc => bc.PrefabID() == CompostConfig.ID, null, 1, RSTRINGS.COMPOST.NAME, RSTRINGS.COMPOST.DESCRIPTION);
            Plants = new RoomConstraints.Constraint(null, room => { return room.plants.Count >= 3; }, 1, RSTRINGS.PLANTS.NAME, RSTRINGS.PLANTS.DESCRIPTION);
            SmoothHatch = new RoomConstraints.Constraint(null, room => {
                    int index = room.cavity.creatures.FindIndex(pf =>
                        pf.PrefabID().ToString() == HatchMetalConfig.ID || pf.PrefabID().ToString() == BabyHatchMetalConfig.ID);
                    return index >= 0;
                }, 1, RSTRINGS.SMOOTHHATCH.NAME, RSTRINGS.SMOOTHHATCH.DESCRIPTION);
            GlossyDrecko = new RoomConstraints.Constraint(null, room => {
                    int index = room.cavity.creatures.FindIndex(pf =>
                        pf.PrefabID().ToString() == DreckoPlasticConfig.ID || pf.PrefabID().ToString() == BabyDreckoPlasticConfig.ID);
                    return index >= 0;
                }, 1, RSTRINGS.GLOSSYDRECKO.NAME, RSTRINGS.GLOSSYDRECKO.DESCRIPTION);
            LonghairSlickster = new RoomConstraints.Constraint(null, room => {
                    int index = room.cavity.creatures.FindIndex(pf =>
                        pf.PrefabID().ToString() == OilFloaterDecorConfig.ID || pf.PrefabID().ToString() == OilFloaterDecorBabyConfig.ID);
                    return index >= 0;
                }, 1, RSTRINGS.LONGHAIRSLICKSTER.NAME, RSTRINGS.LONGHAIRSLICKSTER.DESCRIPTION);
            Shinebugs = new RoomConstraints.Constraint(null, room => {
                    var speciesList = new HashSet<Tag>();
                    foreach(var creature in room.cavity.creatures)
                    {
                        if (!ShinebugSpecies.TryGetValue(creature.PrefabID().ToString(), out Tag species))
                            return false;
                        speciesList.Add(species);
                    }
                    return speciesList.Count == ShinebugSpeciesCount;
                }, 1, RSTRINGS.SHINEBUGS.NAME, RSTRINGS.SHINEBUGS.DESCRIPTION);
            GassyMoo = new RoomConstraints.Constraint(null, room => {
                    int index = room.cavity.creatures.FindIndex(pf =>
                        pf.PrefabID().ToString() == MooConfig.ID);
                    return index >= 0;
                }, 1, RSTRINGS.GASSYMOO.NAME, RSTRINGS.GASSYMOO.DESCRIPTION);
            GasGrass = new RoomConstraints.Constraint(bc => bc.PrefabID() == GasGrassConfig.ID, null, 1, RSTRINGS.GASGRASS.NAME, RSTRINGS.GASGRASS.DESCRIPTION);
            ResearchStations = new RoomConstraints.Constraint(bc => {
                    return bc.PrefabID() == ResearchCenterConfig.ID || bc.PrefabID() == AdvancedResearchCenterConfig.ID || bc.PrefabID() == CosmicResearchCenterConfig.ID;
                }, null, RSTRINGS.RESEARCHSTATIONS.COUNT, RSTRINGS.RESEARCHSTATIONS.NAME, RSTRINGS.RESEARCHSTATIONS.DESCRIPTION);
            Planetarium = new RoomConstraints.Constraint(bc => bc.PrefabID() == CosmicResearchCenterConfig.ID, null, 1, RSTRINGS.PLANETARIUM.NAME, RSTRINGS.PLANETARIUM.DESCRIPTION);
            Telescope = new RoomConstraints.Constraint(bc => bc.PrefabID() == TelescopeConfig.ID, null, 1, RSTRINGS.TELESCOPE.NAME, RSTRINGS.TELESCOPE.DESCRIPTION);
            Grave = new RoomConstraints.Constraint(bc => bc.PrefabID() == GraveConfig.ID, null, 1, RSTRINGS.GRAVE.NAME, RSTRINGS.GRAVE.DESCRIPTION);
            StorageLockers = new RoomConstraints.Constraint(bc => bc.PrefabID() == StorageLockerConfig.ID, null, RSTRINGS.STORAGELOCKERS.COUNT, RSTRINGS.STORAGELOCKERS.NAME, RSTRINGS.STORAGELOCKERS.DESCRIPTION);
            SmartStorageLocker = new RoomConstraints.Constraint(bc => bc.PrefabID() == StorageLockerSmartConfig.ID, null, 1, RSTRINGS.SMARTSTORAGELOCKER.NAME, RSTRINGS.SMARTSTORAGELOCKER.DESCRIPTION);
            MaxSize32 = new RoomConstraints.Constraint(null, room => room.cavity.numCells <= 32, 1, string.Format(ROOMS.CRITERIA.MAXIMUM_SIZE.NAME, "32"), string.Format(ROOMS.CRITERIA.MAXIMUM_SIZE.DESCRIPTION, "32"));
        }

        internal static void StompConflicts()
        {
            RoomConstraints.MESS_STATION_SINGLE.stomp_in_conflict.Add(Coffee);
            RoomConstraints.MESS_STATION_SINGLE.stomp_in_conflict.Add(Arcade);

            var primaryConstraints = new List<RoomConstraints.Constraint>()
            {
                RoomConstraints.TOILET,
                RoomConstraints.FLUSH_TOILET,
                RoomConstraints.BED_SINGLE,
                RoomConstraints.LUXURY_BED_SINGLE,
                RoomConstraints.MESS_STATION_SINGLE,
                RoomConstraints.CLINIC,
                RoomConstraints.MASSAGE_TABLE,
                RoomConstraints.POWER_STATION,
                RoomConstraints.FARM_STATION,
                RoomConstraints.RANCH_STATION,
                RoomConstraints.MACHINE_SHOP,
                RoomConstraints.REC_BUILDING,
                RoomConstraints.PARK_BUILDING,
                ManualGenerator,
                Grill,
                Loom,
                PitcherPump,
                ResearchStations,
                Telescope,
                MarbleSculpture,
                Coffee,
                Arcade,
                Grave,
                StorageLockers,
                IceSculpture,
                OilWell,
            };

            foreach (var constraint in primaryConstraints)
            {
                if (constraint.stomp_in_conflict == null)
                    constraint.stomp_in_conflict = new List<RoomConstraints.Constraint>();
                if (constraint != MarbleSculpture)
                    constraint.stomp_in_conflict.Add(MarbleSculpture);
            }
        }
    }
}
