using Database;
using Harmony;
using System;
using UnityEngine;

namespace MoreRooms
{
    class MoreRoomTypeCategories
    {
        public static RoomTypeCategory ResearchCategory;
        public static RoomTypeCategory ArtCategory;
        public static RoomTypeCategory MemorialCategory;
        public static RoomTypeCategory MiscCategory;

        internal static void AddCategories(RoomTypeCategories categories)
        {
            var AddCategory = Traverse.Create(categories).Method("Add", new Type[] { typeof(string), typeof(string), typeof(Color) });
            ResearchCategory = AddCategory.GetValue<RoomTypeCategory>("MoreRooms", "", new Color(0.7f, 0.5f, 9f));
            ArtCategory = AddCategory.GetValue<RoomTypeCategory>("MoreRooms", "", new Color(0.9f, 0.5f, 0.9f));
            MemorialCategory = AddCategory.GetValue<RoomTypeCategory>("MoreRooms", "", new Color(0.2f, 0.2f, 0.2f));
            MiscCategory = AddCategory.GetValue<RoomTypeCategory>("MoreRooms", "", new Color(0.7f, 0.3f, 0.3f));
        }
    }
}
