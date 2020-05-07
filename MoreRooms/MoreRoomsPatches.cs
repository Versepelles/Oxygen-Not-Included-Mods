using Database;
using Harmony;
using System;
using UnityEngine;
using UnityEngine.UI;
using PeterHan.PLib.UI;
using System.Collections.Generic;
using ConstraintTags = MoreRooms.MoreRoomConstraints.ConstraintTags;
using PeterHan.PLib;

namespace MoreRooms
{
    class MoreRoomsPatches
    {
        public static bool DEBUG_MODE = true;

        public static class Mod_OnLoad
        {
            public static void OnLoad(string modPath)
            {
                Log($"MoreRooms loaded.");
            }
        }

        // Add scrollbar to Room Overlay Legend
        [HarmonyPatch(typeof(OverlayLegend), "PopulateGeneratedLegend")]
        public static class OverlayLegend_PopulateGeneratedLegend_Patch
        {
            private static GameObject scrollContainer;
            private static GameObject scrollBody;

            private static void Postfix(OverlayLegend.OverlayInfo info, GameObject ___activeUnitsParent)
            {
                Log("OverlayLegend_PopulateGeneratedLegend_Patch Postfix");

                if(scrollContainer == null)
                {
                    var scrollBody = new PPanel("MoreRoomsScrollBody")
                    {
                        Spacing = 1,
                        Direction = PanelDirection.Vertical,
                        Alignment = TextAnchor.UpperCenter,
                        FlexSize = Vector2.right,
                        DynamicSize = true
                    };
                    scrollBody.SetKleiPinkColor(); // TODO: delete
                    scrollBody.OnRealize += (go) => 
                    {
                        OverlayLegend_PopulateGeneratedLegend_Patch.scrollBody = go;
                        go.AddOrGet<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;
                    };

                    var scrollPane = new PScrollPane("MoreRoomsScrollPane")
                    {
                        ScrollHorizontal = false,
                        Child = scrollBody,
                        FlexSize = Vector2.right,
                        TrackSize = 8,
                        ScrollVertical = true,
                        AlwaysShowVertical = true,
                        AlwaysShowHorizontal = false,
                    };
                    scrollContainer = scrollPane.AddTo(___activeUnitsParent);

                    var layoutE = scrollContainer.AddOrGet<LayoutElement>();
                    layoutE.minHeight = 200f;

                    var fitter = scrollContainer.AddOrGet<ContentSizeFitter>();
                    fitter.verticalFit = ContentSizeFitter.FitMode.MinSize;

                    //var screen = scrollContainer.AddOrGet<KScreen>();
                    //Traverse.Create(screen).SetField("ConsumeMouseScroll", true);
                }

                if(info.name == "ROOM OVERLAY")
                {

                    var originalChildren = new List<Transform>();
                    for (int i = 0; i < ___activeUnitsParent.transform.childCount; i++)
                        originalChildren.Add(___activeUnitsParent.transform.GetChild(i));

                    foreach (var child in originalChildren)
                        child.SetParent(scrollBody.transform);
                }
                scrollContainer.SetActive(info.name == "ROOM OVERLAY");
            }
        }

        /*// TODO: Direct Room Overlay Legend to take priority of scrolling over zooming
        [HarmonyPatch(typeof(OverlayMenu), "OnActivate")]
        public static class OverlayMenu_OnActivate_Patch
        {
            private static void Postfix(OverlayMenu __instance, ref bool ___ConsumeMouseScroll)
            {
                Log("OverlayLegend_PopulateGeneratedLegend_Patch Postfix");
                ___ConsumeMouseScroll = true;
                // TODO: remove zooming
            }
        }*/

        [HarmonyPatch(typeof(RoomTypeCategories))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(ResourceSet) })]
        public static class RoomTypeCategories_Constructor_Patch
        {
            private static void Postfix(RoomTypeCategories __instance)
            {
                Log("RoomTypeCategories_Constructor_Patch Postfix");
                MoreRoomTypeCategories.AddCategories(__instance);
            }
        }

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
                MoreRoomTypes.CreateRooms(__instance);
                MoreRoomTypes.SortRooms(__instance);
                // TODO: modify upgrade paths
                //Traverse.Create(__instance.Barracks).Property("upgrade_paths").SetValue(new RoomType[2] { __instance.Bedroom, MoreRoomTypes.PrivateBedroom });
                //Traverse.Create(__instance.Bedroom).Property("upgrade_paths").SetValue(new RoomType[1] { MoreRoomTypes.PrivateBedroom });
                // TODO: Adjust bonuses for existing rooms
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            private static void Postfix()
            {
                var tagDictionary = new Dictionary<Tag, Tag>()
                {
                    { CookingStationConfig.ID, ConstraintTags.Grill },
                    { GourmetCookingStationConfig.ID, ConstraintTags.GasRange },
                    { ManualGeneratorConfig.ID, ConstraintTags.ManualGenerator },
                    { KilnConfig.ID, ConstraintTags.Kiln },
                    { GlassForgeConfig.ID, ConstraintTags.GlassForge },
                    { ClothingFabricatorConfig.ID, ConstraintTags.Loom },
                    { CanvasConfig.ID, ConstraintTags.Painting },
                    { CanvasTallConfig.ID, ConstraintTags.Painting },
                    { CanvasWideConfig.ID, ConstraintTags.Painting },
                    { IceSculptureConfig.ID, ConstraintTags.Sculpture },
                    { MarbleSculptureConfig.ID, ConstraintTags.Sculpture },
                    { MetalSculptureConfig.ID, ConstraintTags.Sculpture },
                    { SculptureConfig.ID, ConstraintTags.Sculpture },
                    { SmallSculptureConfig.ID, ConstraintTags.Sculpture },
                    { ItemPedestalConfig.ID, ConstraintTags.Pedestal },
                    { LiquidPumpingStationConfig.ID, ConstraintTags.PitcherPump },
                    { CompostConfig.ID, ConstraintTags.Compost },
                    { ResearchCenterConfig.ID, ConstraintTags.ResearchStation },
                    { AdvancedResearchCenterConfig.ID, ConstraintTags.SuperComputer },
                    { CosmicResearchCenterConfig.ID, ConstraintTags.Planetarium },
                    { TelescopeConfig.ID, ConstraintTags.Telescope },
                    { GraveConfig.ID, ConstraintTags.Grave },
                    { StorageLockerConfig.ID, ConstraintTags.StorageLocker },
                    { StorageLockerSmartConfig.ID, ConstraintTags.StorageLocker },
                    { SteamEngineConfig.ID, ConstraintTags.RocketPart },
                    { KeroseneEngineConfig.ID, ConstraintTags.RocketPart },
                    { HydrogenEngineConfig.ID, ConstraintTags.RocketPart },
                    { CrewCapsuleConfig.ID, ConstraintTags.RocketPart },
                    { CargoBayConfig.ID, ConstraintTags.RocketPart },
                    { CommandModuleConfig.ID, ConstraintTags.RocketPart },
                    { GasCargoBayConfig.ID, ConstraintTags.RocketPart },
                    { LiquidCargoBayConfig.ID, ConstraintTags.RocketPart },
                    { OxidizerTankConfig.ID, ConstraintTags.RocketPart },
                    { ResearchModuleConfig.ID, ConstraintTags.RocketPart },
                    { SolidBoosterConfig.ID, ConstraintTags.RocketPart },
                    { SpecialCargoBayConfig.ID, ConstraintTags.RocketPart },
                    { TouristModuleConfig.ID, ConstraintTags.RocketPart },
                };

                foreach(var pair in tagDictionary)
                    Assets.GetPrefab(pair.Key).GetComponent<KPrefabID>().AddTag(pair.Value, false);
            }
        }

        public static void Log(String msg)
        {
            if (DEBUG_MODE)
                Console.WriteLine("<MoreRooms> " + msg);
        }
    }
}
