using Database;
using Harmony;
using STRINGS;
using static MoreRooms.MoreRoomTypeCategories;

namespace MoreRooms
{
    class MoreRoomTypes
    {
        public static RoomType PrivateBedroom;
        public static RoomType Gym;
        public static RoomType Kitchen;
        public static RoomType Artisan;
        public static RoomType Nursery;
        public static RoomType ShroomFarm;
        public static RoomType NaturePreserve;
        public static RoomType Laboratory;
        public static RoomType Observatory;
        public static RoomType Gallery;
        public static RoomType Museum;
        public static RoomType Rotunda;
        public static RoomType Memorial;
        public static RoomType Storage;
        public static RoomType Silo;

        internal static void CreateRooms(RoomTypes roomTypes)
        {
            PrivateBedroom = roomTypes.Add(
                new RoomType(id: "PrivateBedRoom", name: "Private Quarters", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Sleep,
                    primary_constraint: RoomConstraints.LUXURY_BED_SINGLE,
                    additional_constraints: new RoomConstraints.Constraint[6]
                    {
                        MoreRoomConstraints.PrivateBedroom,
                        RoomConstraints.NO_COTS,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        MoreRoomConstraints.MaxSize32,
                        RoomConstraints.DECORATIVE_ITEM
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2));

            Gym = roomTypes.Add(
                new RoomType(id: "GymRoom", name: "Gym", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Recreation,
                    primary_constraint: MoreRoomConstraints.ManualGenerator,
                    additional_constraints: new RoomConstraints.Constraint[1]
                    {
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Kitchen = roomTypes.Add(
                new RoomType(id: "KitchenRoom", name: "Kitchen", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Food,
                    primary_constraint: MoreRoomConstraints.Grill,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.GasRange,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Artisan = roomTypes.Add(
                new RoomType(id: "ArtisanRoom", name: "Artisan Hall", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Industrial,
                    primary_constraint: MoreRoomConstraints.Loom,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        MoreRoomConstraints.Kiln,
                        MoreRoomConstraints.GlassForge,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            // TODO: require plants
            Nursery = roomTypes.Add(
                new RoomType(id: "NurseryRoom", name: "Botanical Nursery", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Agricultural,
                    primary_constraint: MoreRoomConstraints.PitcherPump,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        MoreRoomConstraints.Compost,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            ShroomFarm = roomTypes.Add(
                new RoomType(id: "ShroomRoom", name: "Shroom Farm", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Agricultural,
                    primary_constraint: RoomConstraints.MASSAGE_TABLE,
                    additional_constraints: new RoomConstraints.Constraint[1]
                    {
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                    },
                    display_details: new RoomDetails.Detail[4]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.CREATURE_COUNT,
                        RoomDetails.PLANT_COUNT
                    },
                    priority: 0));

            NaturePreserve = roomTypes.Add(
                new RoomType(id: "NaturePreserveRoom", name: "True Nature Reserve", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: Db.Get().RoomTypeCategories.Park,
                    primary_constraint: RoomConstraints.MASSAGE_TABLE,
                    additional_constraints: new RoomConstraints.Constraint[1]
                    {
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Laboratory = roomTypes.Add(
                new RoomType(id: "LaboratoryRoom", name: "Laboratory", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: ResearchCategory,
                    primary_constraint: MoreRoomConstraints.ResearchStation,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        MoreRoomConstraints.SuperComputer,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Observatory = roomTypes.Add(
                new RoomType(id: "ObservatoryRoom", name: "Observatory", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: ResearchCategory,
                    primary_constraint: MoreRoomConstraints.Telescope,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        MoreRoomConstraints.Planetarium,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Rotunda = roomTypes.Add(
                new RoomType(id: "RotundaRoom", name: "Rotunda", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: ArtCategory,
                    primary_constraint: MoreRoomConstraints.Pedestal,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        MoreRoomConstraints.Painting,
                        MoreRoomConstraints.Sculpture,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_96,
                        RoomConstraints.CEILING_HEIGHT_6,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2));

            Museum = roomTypes.Add(
                new RoomType(id: "MuseumRoom", name: "Museum", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: ArtCategory,
                    primary_constraint: MoreRoomConstraints.Pedestal,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        MoreRoomConstraints.Painting,
                        MoreRoomConstraints.Sculpture,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_96,
                        RoomConstraints.CEILING_HEIGHT_4,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 1,
                    upgrade_paths: new RoomType[1] { Rotunda }));

            Gallery = roomTypes.Add(
                new RoomType(id: "GalleryRoom", name: "Gallery", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: ArtCategory,
                    primary_constraint: MoreRoomConstraints.Painting,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        MoreRoomConstraints.Sculpture,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0,
                    upgrade_paths: new RoomType[1] { Museum }));

            Memorial = roomTypes.Add(
                new RoomType(id: "MemorialRoom", name: "Memorial Room", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: MemorialCategory,
                    primary_constraint: MoreRoomConstraints.Grave,
                    additional_constraints: new RoomConstraints.Constraint[2]
                    {
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Storage = roomTypes.Add(
                new RoomType(id: "StorageRoom", name: "Storage Room", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: MiscCategory,
                    primary_constraint: MoreRoomConstraints.StorageLocker,
                    additional_constraints: new RoomConstraints.Constraint[1]
                    {
                        MoreRoomConstraints.StorageLockers,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0));

            Silo = roomTypes.Add(
                new RoomType(id: "SiloRoom", name: "Rocket Silo", tooltip: "TODO tooltip",
                    effect: (string) ROOMS.TYPES.NEUTRAL.EFFECT,
                    category: MiscCategory,
                    primary_constraint: MoreRoomConstraints.RocketPart,
                    additional_constraints: null,
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 1));
        }

        internal static void SortRooms(RoomTypes roomTypes)
        {
            void SetSortKey(RoomType room, int order) { Traverse.Create(room).Property("sortKey").SetValue(order); }

            int sortKey = 0;
            int CategoryBuffer = 5;

            // Neutral
            SetSortKey(roomTypes.Neutral, sortKey++);
            sortKey += CategoryBuffer;

            // Bathroom
            SetSortKey(roomTypes.Latrine, sortKey++);
            SetSortKey(roomTypes.PlumbedBathroom, sortKey++);
            sortKey += CategoryBuffer;

            // Bedroom
            SetSortKey(roomTypes.Barracks, sortKey++);
            SetSortKey(roomTypes.Bedroom, sortKey++);
            SetSortKey(PrivateBedroom, sortKey++);
            sortKey += CategoryBuffer;

            // Food
            SetSortKey(roomTypes.MessHall, sortKey++);
            SetSortKey(roomTypes.GreatHall, sortKey++);
            SetSortKey(Kitchen, sortKey++);
            sortKey += CategoryBuffer;

            // Medicine
            SetSortKey(roomTypes.Hospital, sortKey++);
            SetSortKey(roomTypes.MassageClinic, sortKey++);
            sortKey += CategoryBuffer;

            // Industrial
            SetSortKey(roomTypes.PowerPlant, sortKey++);
            SetSortKey(roomTypes.MachineShop, sortKey++);
            SetSortKey(Artisan, sortKey++);
            sortKey += CategoryBuffer;

            // Agricultural
            SetSortKey(roomTypes.Farm, sortKey++);
            SetSortKey(roomTypes.CreaturePen, sortKey++);
            SetSortKey(Nursery, sortKey++);
            SetSortKey(ShroomFarm, sortKey++);
            sortKey += CategoryBuffer;

            // Recreation
            SetSortKey(roomTypes.RecRoom, sortKey++);
            SetSortKey(Gym, sortKey++);
            sortKey += CategoryBuffer;

            // Park
            SetSortKey(roomTypes.Park, sortKey++);
            SetSortKey(roomTypes.NatureReserve, sortKey++);
            SetSortKey(NaturePreserve, sortKey++);
            sortKey += CategoryBuffer;

            // Research
            SetSortKey(Laboratory, sortKey++);
            SetSortKey(Observatory, sortKey++);
            sortKey += CategoryBuffer;

            // Art
            SetSortKey(Gallery, sortKey++);
            SetSortKey(Museum, sortKey++);
            SetSortKey(Rotunda, sortKey++);
            sortKey += CategoryBuffer;

            // Misc
            SetSortKey(Storage, sortKey++);
            SetSortKey(Silo, sortKey++);

            // Memorial
            SetSortKey(Memorial, sortKey++);
            sortKey += CategoryBuffer;
        }
    }
}
