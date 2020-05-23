using Database;
using Harmony;
using System;
using UnityEngine;
using RSTRINGS = MoreRooms.MoreRoomStrings.ROOMS.CATEGORIES;

namespace MoreRooms
{
    class MoreRoomTypeCategories
    {
        public static RoomTypeCategory AnimalCategory;
        public static RoomTypeCategory ResearchCategory;
        public static RoomTypeCategory ArtCategory;
        public static RoomTypeCategory UtilityCategory;
        public static RoomTypeCategory MemorialCategory;

        internal static void AddCategories(RoomTypeCategories categories)
        {
            var AddCategory = Traverse.Create(categories).Method("Add", new Type[] { typeof(string), typeof(string), typeof(Color) });
            AnimalCategory = AddCategory.GetValue<RoomTypeCategory>(RSTRINGS.ANIMAL.NAME, RSTRINGS.ANIMAL.DESCRIPTION, new Color(0.25f, 0.75f, 0.6f));
            ResearchCategory = AddCategory.GetValue<RoomTypeCategory>(RSTRINGS.RESEARCH.NAME, RSTRINGS.RESEARCH.DESCRIPTION, new Color(0.7f, 0.5f, 9f));
            ArtCategory = AddCategory.GetValue<RoomTypeCategory>(RSTRINGS.ART.NAME, RSTRINGS.ART.DESCRIPTION, new Color(0.9f, 0.5f, 0.9f));
            UtilityCategory = AddCategory.GetValue<RoomTypeCategory>(RSTRINGS.Utility.NAME, RSTRINGS.Utility.DESCRIPTION, new Color(0.7f, 0.3f, 0.3f));
            MemorialCategory = AddCategory.GetValue<RoomTypeCategory>(RSTRINGS.MEMORIAL.NAME, RSTRINGS.MEMORIAL.DESCRIPTION, new Color(0.2f, 0.2f, 0.2f));
        }

        internal static void ModifyCategories(RoomTypeCategories categories)
        {
            void SetColor(RoomTypeCategory category, Color color) { Traverse.Create(category).Property("color").SetValue(color); }
            SetColor(categories.Bathroom, new Color(0.4f, 0.9f, 1.0f));
            SetColor(categories.Sleep, new Color(0.6f, 1.0f, 0.88f));
            SetColor(categories.Food, new Color(0.95f, 0.88f, 0.45f));
            SetColor(categories.Industrial, new Color(1.00f, 0.70f, 0.25f));
            SetColor(categories.Agricultural, new Color(0.60f, 1.0f, 0.52f));
            SetColor(categories.Park, new Color(1.0f, 1.0f, 0.38f));
        }
    }
}
