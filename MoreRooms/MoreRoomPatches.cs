using Database;
using Harmony;
using System;
using UnityEngine;
using UnityEngine.UI;
using PeterHan.PLib.UI;
using System.Collections.Generic;
using PeterHan.PLib;

namespace MoreRooms
{
    class MoreRoomPatches
    {
        public static bool DEBUG_MODE = true;
        public static string ModName { get; } = "MoreRooms";

        public static class Mod_OnLoad
        {
            public static void OnLoad(string modPath)
            {
                Log($"{ModName} loaded.");
            }
        }

        #region OverlayLegendScrolling
        // Handle Overlay changing (Not strictly necessary)
        [HarmonyPatch(typeof(OverlayLegend), "ClearLegend")]
        public static class OverlayLegend_ClearLegend_Patch
        {
            private static void Prefix(GameObject ___activeUnitsParent)
            {
                Log("OverlayLegend_ClearLegend_Patch Prefix");

                var scrollBody = OverlayLegend_PopulateGeneratedLegend_Patch.scrollBody;
                var scrollContainer = OverlayLegend_PopulateGeneratedLegend_Patch.scrollContainer;
                if (scrollContainer != null)
                {
                    scrollContainer.SetParent(null);
                    scrollContainer.SetActive(false);
                    if(scrollBody.transform.childCount > 0)
                    {
                        var originalChildren = new List<Transform>();
                        for (int i = 0; i < scrollBody.transform.childCount; i++)
                            originalChildren.Add(scrollBody.transform.GetChild(i));
                        foreach (var child in originalChildren)
                            child.SetParent(___activeUnitsParent.transform);
                    }
                }
            }
        }

        // Add scrollbar to Room Overlay Legend
        [HarmonyPatch(typeof(OverlayLegend), "PopulateGeneratedLegend")]
        public static class OverlayLegend_PopulateGeneratedLegend_Patch
        {
            internal static GameObject scrollBody;
            internal static GameObject scrollContainer;
            public static string RoomOverlayName = "ROOM OVERLAY"; // TODO: Language independent name

            private static void Postfix(OverlayLegend.OverlayInfo info, GameObject ___activeUnitsParent)
            {
                Log("OverlayLegend_PopulateGeneratedLegend_Patch Postfix");

                if (scrollContainer == null)
                {
                    var scrollBody = new PPanel("MoreRoomsScrollBody")
                    {
                        Spacing = 4,
                        Direction = PanelDirection.Vertical,
                        Alignment = TextAnchor.UpperCenter,
                        FlexSize = Vector2.right,
                        DynamicSize = true
                    };
                    scrollBody.OnRealize += (go) => 
                    {
                        OverlayLegend_PopulateGeneratedLegend_Patch.scrollBody = go;
                        go.AddOrGet<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;
                        go.AddComponent<Image>().color = new Color(0f, 0f, 0f, 0f); // This helps scrolling over transparent areas in the Panel
                    };

                    var scrollPane = new PScrollPane("MoreRoomsScrollPane")
                    {
                        ScrollHorizontal = false,
                        Child = scrollBody,
                        FlexSize = Vector2.one,
                        TrackSize = 8,
                        ScrollVertical = true,
                        AlwaysShowVertical = true,
                        AlwaysShowHorizontal = false,
                    };

                    scrollContainer = scrollPane.Build();
                    var layoutE = scrollContainer.AddOrGet<LayoutElement>();
                    layoutE.preferredHeight = 750f;
                    layoutE.layoutPriority = 100;
                }

                if(info.name == RoomOverlayName)
                {
                    var originalChildren = new List<Transform>();
                    for (int i = 0; i < ___activeUnitsParent.transform.childCount; i++)
                        originalChildren.Add(___activeUnitsParent.transform.GetChild(i));
                    foreach (var legendEntry in originalChildren)
                        legendEntry.SetParent(scrollBody.transform);

                    scrollContainer.SetParent(___activeUnitsParent);
                    scrollContainer.SetActive(true);
                }
            }
        }

        // TODO: Direct Room Overlay Legend to take priority of scrolling over zooming
        [HarmonyPatch(typeof(OverlayMenu), "OnActivate")]
        public static class OverlayMenu_OnActivate_Patch
        {
            private static void Postfix(OverlayMenu __instance)
            {
                Log("OverlayLegend_PopulateGeneratedLegend_Patch Postfix");
                __instance.ConsumeMouseScroll = true;
                // TODO: remove zooming
            }
        }
        #endregion

        // Add effects
        [HarmonyPatch(typeof(Db), "Initialize")]
        public static class Db_Initialize_Patch
        {
            private static void Postfix(Db __instance)
            {
                Log("RoomTypeCategories_Constructor_Patch Postfix");
                MoreRoomEffects.CreateEffects(__instance);
            }
        }

        // Add Room Categories
        [HarmonyPatch(typeof(RoomTypeCategories))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(ResourceSet) })]
        public static class RoomTypeCategories_Constructor_Patch
        {
            private static void Postfix(RoomTypeCategories __instance)
            {
                Log("RoomTypeCategories_Constructor_Patch Postfix");
                MoreRoomTypeCategories.AddCategories(__instance);
                MoreRoomTypeCategories.ModifyCategories(__instance);
            }
        }

        // Add Rooms and modify attributes of existing rooms
        [HarmonyPatch(typeof(RoomTypes))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(ResourceSet) })]
        public static class RoomTypes_Constructor_Patch
        {
            [HarmonyPriority(Priority.LowerThanNormal)]
            private static void Postfix(RoomTypes __instance)
            {
                Log("RoomTypes_Constructor_Patch Postfix");

                MoreRoomConstraints.CreateRoomConstraints();
                MoreRoomConstraints.StompConflicts();
                MoreRoomTypes.CreateRooms(__instance);
                MoreRoomTypes.SortRooms(__instance);
                MoreRoomTypes.ModifyRooms(__instance);
            }
        }

        public static void Log(String msg)
        {
            if (DEBUG_MODE)
                Console.WriteLine($"<{ModName}> {msg}");
        }
    }
}
