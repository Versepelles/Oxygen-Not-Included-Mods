using STRINGS;
using System;

namespace MoreRooms
{
    class MoreRoomConstraints
    {
        public static RoomConstraints.Constraint PrivateBedroom;
        public static RoomConstraints.Constraint Grill;
        public static RoomConstraints.Constraint GasRange;
        public static RoomConstraints.Constraint ManualGenerator;
        public static RoomConstraints.Constraint Kiln;
        public static RoomConstraints.Constraint GlassForge;
        public static RoomConstraints.Constraint Loom;
        public static RoomConstraints.Constraint Painting;
        public static RoomConstraints.Constraint Sculpture;
        public static RoomConstraints.Constraint Pedestal;
        public static RoomConstraints.Constraint PitcherPump;
        public static RoomConstraints.Constraint Compost;
        public static RoomConstraints.Constraint ResearchStation;
        public static RoomConstraints.Constraint SuperComputer;
        public static RoomConstraints.Constraint Planetarium;
        public static RoomConstraints.Constraint Telescope;
        public static RoomConstraints.Constraint Grave;
        public static RoomConstraints.Constraint StorageLocker;
        public static RoomConstraints.Constraint StorageLockers;
        public static RoomConstraints.Constraint RocketPart;


        public static RoomConstraints.Constraint MaxSize32;

        internal static void CreateRoomConstraints()
        {
            PrivateBedroom = new RoomConstraints.Constraint(null, room => {
                    int numBeds = 0;
                    foreach (KPrefabID building in room.buildings)
                        if (building.HasTag(RoomConstraints.ConstraintTags.LuxuryBed))
                            numBeds++;
                    return numBeds == 1;
                }, 1, "PrivateBedroomCriteria", "A single Comfy Bed");
            Grill = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Grill)), null, 1, "GrillCriteria", "Electric Grill");
            GasRange = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.GasRange)), null, 1, "GasRangeCriteria", "Gas Range");
            ManualGenerator = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.ManualGenerator)), null, 1, "ManualGeneratorCriteria", "Manual Generator");
            Kiln = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Kiln)), null, 1, "KilnCriteria", "Kiln");
            GlassForge = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.GlassForge)), null, 1, "GlassForgeCriteria", "Glass Forge");
            Loom = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Loom)), null, 1, "LoomCriteria", "Textile Loom");
            Painting = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Painting)), null, 1, "PaintingCriteria", "Painting");
            Sculpture = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Sculpture)), null, 1, "SculptureCriteria", "Sculpture");
            Pedestal = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Pedestal)), null, 1, "PedestalCriteria", "Pedestal");
            PitcherPump = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.PitcherPump)), null, 1, "PitcherPumpCriteria", "Pitcher Pump");
            Compost = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Compost)), null, 1, "CompostCriteria", "Compost Bin");
            ResearchStation = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.ResearchStation)), null, 1, "ResearchStationCriteria", "Research Station");
            SuperComputer = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.SuperComputer)), null, 1, "SuperComputerCriteria", "Super Computer");
            Planetarium = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Planetarium)), null, 1, "PlanetariumCriteria", "Virtual Planetarium");
            Telescope = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Telescope)), null, 1, "TelescopeCriteria", "Telescope");
            Grave = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.Grave)), null, 1, "GraveCriteria", "Grave");
            StorageLocker = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.StorageLocker)), null, 1, "StorageLockerCriteria", "Storage Locker");
            StorageLockers = new RoomConstraints.Constraint(null, room => {
                    int numLockers = 0;
                    foreach (KPrefabID building in room.buildings)
                        if (building.HasTag(ConstraintTags.StorageLocker))
                            numLockers++;
                    return numLockers >= 5;
                }, 1, "StorageLockersCriteria", "Storage Lockers");
            RocketPart = new RoomConstraints.Constraint((bc => bc.HasTag(ConstraintTags.RocketPart)), null, 1, "RocketPartCriteria", "Rocket Part");


            MaxSize32 = new RoomConstraints.Constraint(null, (room => room.cavity.numCells <= 32), 1, string.Format(ROOMS.CRITERIA.MAXIMUM_SIZE.NAME, "32"), string.Format(ROOMS.CRITERIA.MAXIMUM_SIZE.DESCRIPTION, "32"));
        }

        public class ConstraintTags
        {
            public static Tag Grill = nameof(Grill).ToTag();
            public static Tag GasRange = nameof(GasRange).ToTag();
            public static Tag ManualGenerator = nameof(ManualGenerator).ToTag();
            public static Tag Kiln = nameof(Kiln).ToTag();
            public static Tag GlassForge = nameof(GlassForge).ToTag();
            public static Tag Loom = nameof(Loom).ToTag();
            public static Tag Painting = nameof(Painting).ToTag();
            public static Tag Sculpture = nameof(Sculpture).ToTag();
            public static Tag Pedestal = nameof(Pedestal).ToTag();
            public static Tag PitcherPump = nameof(PitcherPump).ToTag();
            public static Tag Compost = nameof(Compost).ToTag();
            public static Tag ResearchStation = nameof(ResearchStation).ToTag();
            public static Tag SuperComputer = nameof(SuperComputer).ToTag();
            public static Tag Planetarium = nameof(Planetarium).ToTag();
            public static Tag Telescope = nameof(Telescope).ToTag();
            public static Tag Grave = nameof(Grave).ToTag();
            public static Tag StorageLocker = nameof(StorageLocker).ToTag();
            public static Tag RocketPart = nameof(RocketPart).ToTag();
        }
    }
}
