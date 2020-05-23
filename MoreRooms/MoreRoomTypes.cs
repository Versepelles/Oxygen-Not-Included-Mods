using Database;
using Harmony;
using System.Linq;
using static MoreRooms.MoreRoomTypeCategories;
using RSTRINGS = MoreRooms.MoreRoomStrings.ROOMS.TYPES;

namespace MoreRooms
{
    class MoreRoomTypes
    {
        public static RoomType PrivateQuarters;
        public static RoomType Parlour;
        public static RoomType GameRoom;
        public static RoomType Gym;
        public static RoomType Spa;
        public static RoomType Kitchen;
        public static RoomType Artisan;
        public static RoomType PetroPlant;
        public static RoomType Nursery;
        public static RoomType ShroomFarm;
        public static RoomType BlueZoo;
        public static RoomType ShinebugZoo;
        public static RoomType MooZoo;
        public static RoomType Laboratory;
        public static RoomType Observatory;
        public static RoomType Gallery;
        public static RoomType Museum;
        public static RoomType WinterRoom;
        public static RoomType Memorial;
        public static RoomType Storage;

        internal static void CreateRooms(RoomTypes roomTypes)
        {
            PrivateQuarters = roomTypes.Add(
                new RoomType(id: RSTRINGS.PRIVATEQUARTERS.ID, name: RSTRINGS.PRIVATEQUARTERS.NAME, tooltip: RSTRINGS.PRIVATEQUARTERS.TOOLTIP,
                    effect: RSTRINGS.PRIVATEQUARTERS.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Sleep,
                    primary_constraint: RoomConstraints.LUXURY_BED_SINGLE,
                    additional_constraints: new RoomConstraints.Constraint[6]
                    {
                        MoreRoomConstraints.OneBed,
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
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.PrivateQuarters }));

            Parlour = roomTypes.Add(
                new RoomType(id: "ParlourRoom", name: RSTRINGS.PARLOUR.NAME, tooltip: RSTRINGS.PARLOUR.TOOLTIP,
                    effect: RSTRINGS.PARLOUR.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Recreation,
                    primary_constraint: MoreRoomConstraints.Coffee,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        RoomConstraints.DECORATIVE_ITEM_20,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                        RoomConstraints.CEILING_HEIGHT_4,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.Parlour }));

            GameRoom = roomTypes.Add(
                new RoomType(id: "GameRoom", name: RSTRINGS.GAMEROOM.NAME, tooltip: RSTRINGS.GAMEROOM.TOOLTIP,
                    effect: RSTRINGS.GAMEROOM.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Recreation,
                    primary_constraint: MoreRoomConstraints.Arcade,
                    additional_constraints: new RoomConstraints.Constraint[2]
                    {
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.GameRoom }));

            Gym = roomTypes.Add(
                new RoomType(id: "GymRoom", name: RSTRINGS.GYM.NAME, tooltip: RSTRINGS.GYM.TOOLTIP,
                    effect: RSTRINGS.GYM.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Recreation,
                    primary_constraint: MoreRoomConstraints.ManualGenerator,
                    additional_constraints: new RoomConstraints.Constraint[2]
                    {
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0,
                    upgrade_paths: new RoomType[1] { roomTypes.PowerPlant },
                    effects: new string[1] { MoreRoomEffects.IDs.Gym }));

            Spa = roomTypes.Add(
                new RoomType(id: "SpaRoom", name: RSTRINGS.SPA.NAME, tooltip: RSTRINGS.SPA.TOOLTIP,
                    effect: RSTRINGS.SPA.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Hospital,
                    primary_constraint: RoomConstraints.MASSAGE_TABLE,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.HotTub,
                        MoreRoomConstraints.Sauna,
                        RoomConstraints.MINIMUM_SIZE_32,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.Spa }));

            Kitchen = roomTypes.Add(
                new RoomType(id: "KitchenRoom", name: RSTRINGS.KITCHEN.NAME, tooltip: RSTRINGS.KITCHEN.TOOLTIP,
                    effect: RSTRINGS.KITCHEN.DESCRIPTION,
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
                    priority: 1,
                    effects: new string[1] { MoreRoomEffects.IDs.Kitchen }));

            Artisan = roomTypes.Add(
                new RoomType(id: "ArtisanRoom", name: RSTRINGS.ARTISAN.NAME, tooltip: RSTRINGS.ARTISAN.TOOLTIP,
                    effect: RSTRINGS.ARTISAN.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Industrial,
                    primary_constraint: MoreRoomConstraints.Loom,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.Kiln,
                        MoreRoomConstraints.GlassForge,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 1,
                    effects: new string[1] { MoreRoomEffects.IDs.Artisan }));

            PetroPlant = roomTypes.Add(
                new RoomType(id: "PetroRoom", name: RSTRINGS.PETROPLANT.NAME, tooltip: RSTRINGS.PETROPLANT.TOOLTIP,
                    effect: RSTRINGS.PETROPLANT.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Industrial,
                    primary_constraint: MoreRoomConstraints.OilWell,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        MoreRoomConstraints.OilRefinery,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 1,
                    effects: new string[1] { MoreRoomEffects.IDs.PetroPlant }));

            Nursery = roomTypes.Add(
                new RoomType(id: "NurseryRoom", name: RSTRINGS.NURSERY.NAME, tooltip: RSTRINGS.NURSERY.TOOLTIP,
                    effect: RSTRINGS.NURSERY.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Agricultural,
                    primary_constraint: MoreRoomConstraints.PitcherPump,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        MoreRoomConstraints.Compost,
                        MoreRoomConstraints.Plants,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[3]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.PLANT_COUNT,
                    },
                    priority: 1,
                    effects: new string[1] { MoreRoomEffects.IDs.Nursery }));

            ShroomFarm = roomTypes.Add(
                new RoomType(id: "ShroomRoom", name: RSTRINGS.SHROOMFARM.NAME, tooltip: RSTRINGS.SHROOMFARM.TOOLTIP,
                    effect: RSTRINGS.SHROOMFARM.DESCRIPTION,
                    category: Db.Get().RoomTypeCategories.Agricultural,
                    primary_constraint: RoomConstraints.FARM_STATION,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.Shrooms,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[3]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.PLANT_COUNT
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.ShroomFarm }));

            BlueZoo = roomTypes.Add(
                new RoomType(id: "BlueZooRoom", name: RSTRINGS.BLUEZOO.NAME, tooltip: RSTRINGS.BLUEZOO.TOOLTIP,
                    effect: RSTRINGS.BLUEZOO.DESCRIPTION,
                    category: AnimalCategory,
                    primary_constraint: RoomConstraints.PARK_BUILDING,
                    additional_constraints: new RoomConstraints.Constraint[6]
                    {
                        MoreRoomConstraints.SmoothHatch,
                        MoreRoomConstraints.GlossyDrecko,
                        MoreRoomConstraints.LonghairSlickster,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_32,
                        RoomConstraints.MAXIMUM_SIZE_120,
                    },
                    display_details: new RoomDetails.Detail[4]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.PLANT_COUNT,
                        RoomDetails.CREATURE_COUNT
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.BlueZoo }));

            ShinebugZoo = roomTypes.Add(
                new RoomType(id: "ShinebugZooRoom", name: RSTRINGS.SHINEBUGZOO.NAME, tooltip: RSTRINGS.SHINEBUGZOO.TOOLTIP,
                    effect: RSTRINGS.SHINEBUGZOO.DESCRIPTION,
                    category: AnimalCategory,
                    primary_constraint: RoomConstraints.PARK_BUILDING,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.Shinebugs,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_32,
                        RoomConstraints.MAXIMUM_SIZE_120,
                    },
                    display_details: new RoomDetails.Detail[4]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.PLANT_COUNT,
                        RoomDetails.CREATURE_COUNT
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.ShinebugZoo }));

            MooZoo = roomTypes.Add(
                new RoomType(id: "MooZooRoom", name: RSTRINGS.MOOZOO.NAME, tooltip: RSTRINGS.MOOZOO.TOOLTIP,
                    effect: RSTRINGS.MOOZOO.DESCRIPTION,
                    category: AnimalCategory,
                    primary_constraint: RoomConstraints.PARK_BUILDING,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        MoreRoomConstraints.GassyMoo,
                        MoreRoomConstraints.GasGrass,
                        // TODO: Thermium Statue
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_32,
                        RoomConstraints.MAXIMUM_SIZE_120,
                    },
                    display_details: new RoomDetails.Detail[4]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.PLANT_COUNT,
                        RoomDetails.CREATURE_COUNT
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.MooZoo }));

            Laboratory = roomTypes.Add(
                new RoomType(id: "LaboratoryRoom", name: RSTRINGS.LABORATORY.NAME, tooltip: RSTRINGS.LABORATORY.TOOLTIP,
                    effect: RSTRINGS.LABORATORY.DESCRIPTION,
                    category: ResearchCategory,
                    primary_constraint: MoreRoomConstraints.ResearchStations,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.Laboratory }));

            Observatory = roomTypes.Add(
                new RoomType(id: "ObservatoryRoom", name: RSTRINGS.OBSERVATORY.NAME, tooltip: RSTRINGS.OBSERVATORY.TOOLTIP,
                    effect: RSTRINGS.OBSERVATORY.DESCRIPTION,
                    category: ResearchCategory,
                    primary_constraint: MoreRoomConstraints.Telescope,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.Planetarium,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_32,
                        RoomConstraints.MAXIMUM_SIZE_96,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 2,
                    effects: new string[1] { MoreRoomEffects.IDs.Observatory }));

            WinterRoom = roomTypes.Add(
                new RoomType(id: "WinterRoom", name: RSTRINGS.WINTER.NAME, tooltip: RSTRINGS.WINTER.TOOLTIP,
                    effect: RSTRINGS.WINTER.DESCRIPTION,
                    category: UtilityCategory,
                    primary_constraint: MoreRoomConstraints.IceSculpture,
                    additional_constraints: new RoomConstraints.Constraint[4]
                    {
                        MoreRoomConstraints.Wheezewort,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[3]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                        RoomDetails.PLANT_COUNT,
                    },
                    priority: 1,
                    effects: new string[1] { MoreRoomEffects.IDs.WinterRoom }));

            Gallery = roomTypes.Add(
                new RoomType(id: "GalleryRoom", name: RSTRINGS.GALLERY.NAME, tooltip: RSTRINGS.GALLERY.TOOLTIP,
                    effect: RSTRINGS.GALLERY.DESCRIPTION,
                    category: ArtCategory,
                    primary_constraint: MoreRoomConstraints.MarbleSculpture,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        MoreRoomConstraints.Paintings,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                        RoomConstraints.CEILING_HEIGHT_4,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0,
                    effects: new string[1] { MoreRoomEffects.IDs.Gallery }));

            Museum = roomTypes.Add(
                new RoomType(id: "MuseumRoom", name: RSTRINGS.MUSEUM.NAME, tooltip: RSTRINGS.MUSEUM.TOOLTIP,
                    effect: RSTRINGS.MUSEUM.DESCRIPTION,
                    category: ArtCategory,
                    primary_constraint: MoreRoomConstraints.MarbleSculpture,
                    additional_constraints: new RoomConstraints.Constraint[5]
                    {
                        MoreRoomConstraints.Pedestals,
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_96,
                        RoomConstraints.CEILING_HEIGHT_4,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 0,
                    effects: new string[1] { MoreRoomEffects.IDs.Museum }));

            Memorial = roomTypes.Add(
                new RoomType(id: "MemorialRoom", name: RSTRINGS.MEMORIAL.NAME, tooltip: RSTRINGS.MEMORIAL.TOOLTIP,
                    effect: RSTRINGS.MEMORIAL.DESCRIPTION,
                    category: MemorialCategory,
                    primary_constraint: MoreRoomConstraints.Grave,
                    additional_constraints: new RoomConstraints.Constraint[3]
                    {
                        RoomConstraints.NO_INDUSTRIAL_MACHINERY,
                        RoomConstraints.MINIMUM_SIZE_12,
                        RoomConstraints.MAXIMUM_SIZE_64,
                    },
                    display_details: new RoomDetails.Detail[2]
                    {
                        RoomDetails.SIZE,
                        RoomDetails.BUILDING_COUNT,
                    },
                    priority: 1,
                    effects: new string[1] { MoreRoomEffects.IDs.Memorial }));

            Storage = roomTypes.Add(
                new RoomType(id: "StorageRoom", name: RSTRINGS.STORAGE.NAME, tooltip: RSTRINGS.STORAGE.TOOLTIP,
                    effect: RSTRINGS.STORAGE.DESCRIPTION,
                    category: UtilityCategory,
                    primary_constraint: MoreRoomConstraints.SmartStorageLocker,
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
            SetSortKey(PrivateQuarters, sortKey++);
            sortKey += CategoryBuffer;

            // Agricultural
            SetSortKey(Nursery, sortKey++);
            SetSortKey(roomTypes.Farm, sortKey++);
            SetSortKey(ShroomFarm, sortKey++);
            sortKey += CategoryBuffer;

            // Food
            SetSortKey(Kitchen, sortKey++);
            SetSortKey(roomTypes.MessHall, sortKey++);
            SetSortKey(roomTypes.GreatHall, sortKey++);
            sortKey += CategoryBuffer;

            // Medicine
            SetSortKey(roomTypes.Hospital, sortKey++);
            SetSortKey(roomTypes.MassageClinic, sortKey++);
            SetSortKey(Spa, sortKey++);
            sortKey += CategoryBuffer;

            // Industrial
            SetSortKey(Artisan, sortKey++);
            SetSortKey(roomTypes.MachineShop, sortKey++);
            SetSortKey(roomTypes.PowerPlant, sortKey++);
            SetSortKey(PetroPlant, sortKey++);
            sortKey += CategoryBuffer;

            // Park
            SetSortKey(roomTypes.Park, sortKey++);
            SetSortKey(roomTypes.NatureReserve, sortKey++);
            sortKey += CategoryBuffer;

            // Animal
            SetSortKey(roomTypes.CreaturePen, sortKey++);
            SetSortKey(BlueZoo, sortKey++);
            SetSortKey(ShinebugZoo, sortKey++);
            SetSortKey(MooZoo, sortKey++);
            sortKey += CategoryBuffer;

            // Recreation
            SetSortKey(roomTypes.RecRoom, sortKey++);
            SetSortKey(Parlour, sortKey++);
            SetSortKey(GameRoom, sortKey++);
            SetSortKey(Gym, sortKey++);
            sortKey += CategoryBuffer;

            // Research
            SetSortKey(Laboratory, sortKey++);
            SetSortKey(Observatory, sortKey++);
            sortKey += CategoryBuffer;

            // Art
            SetSortKey(Gallery, sortKey++);
            SetSortKey(Museum, sortKey++);
            sortKey += CategoryBuffer;

            // Misc
            SetSortKey(WinterRoom, sortKey++);
            SetSortKey(Storage, sortKey++);

            // Memorial
            SetSortKey(Memorial, sortKey++);
        }

        internal static void ModifyRooms(RoomTypes roomTypes)
        {
            var effects = Db.Get().effects;
            effects.Get("RoomMessHall").SelfModifiers.First().SetValue(1);
            effects.Get("RoomGreatHall").SelfModifiers.First().SetValue(2);
            effects.Get("RoomPark").SelfModifiers.First().SetValue(2);
            effects.Get("RoomNatureReserve").SelfModifiers.First().SetValue(3);

            Traverse.Create(roomTypes.Bedroom).Property("tooltip").SetValue("Sleeping in a Bedroom will improve Duplicants' Morale.");
            Traverse.Create(roomTypes.CreaturePen).Property("category").SetValue(AnimalCategory);

            ModifyPaths(roomTypes.Barracks, new RoomType[2] { roomTypes.Bedroom, PrivateQuarters });
            ModifyPaths(roomTypes.Bedroom, new RoomType[1] { PrivateQuarters });
            ModifyPaths(roomTypes.RecRoom, new RoomType[2] { Parlour, GameRoom });
            ModifyPaths(roomTypes.MassageClinic, new RoomType[1] { Spa });
            ModifyPaths(roomTypes.Farm, new RoomType[1] { ShroomFarm });
        }

        private static void ModifyPaths(RoomType room, RoomType[] newRooms)
        {
            var paths = Traverse.Create(room).Property("upgrade_paths");
            var existingPaths = paths.GetValue<RoomType[]>();
            RoomType[] newPaths = newRooms;
            if (existingPaths != null)
                newPaths = newRooms.Concat(existingPaths).ToArray();
            paths.SetValue(newPaths);
        }
    }
}
