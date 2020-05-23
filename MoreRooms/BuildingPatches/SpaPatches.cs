using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class SpaPatches
    {
        class MassageTablePatches
        {
            [HarmonyPatch(typeof(RelaxationPoint), "OnStartWork")]
            public class RelaxationPoint_OnStartWork_Patch
            {
                private static void Postfix(RelaxationPoint __instance, Worker worker)
                {
                    Log("RelaxationPoint_OnStartWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Spa)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.SpaMassage, true);
                }
            }

            [HarmonyPatch(typeof(RelaxationPoint), "OnStopWork")]
            public class RelaxationPoint_OnStopWork_Patch
            {
                private static void Postfix(RelaxationPoint __instance, Worker worker)
                {
                    Log("RelaxationPoint_OnStopWork_Patch Postfix");
                    worker?.GetComponent<Effects>().Remove(MoreRoomEffects.IDs.SpaMassage);

                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Spa)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Spa, true);
                }
            }
        }

        class HotTubPatches
        {
            [HarmonyPatch(typeof(HotTubWorkable), "OnCompleteWork")]
            public class HotTubWorkable_OnCompleteWork_Patch
            {
                private static void Postfix(HotTubWorkable __instance, Worker worker)
                {
                    Log("HotTubWorkable_OnCompleteWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Spa)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Spa, true);
                }
            }
        }

        class SaunaPatches
        {
            [HarmonyPatch(typeof(SaunaWorkable), "OnCompleteWork")]
            public class SaunaWorkable_OnCompleteWork_Patch
            {
                private static void Postfix(HotTubWorkable __instance, Worker worker)
                {
                    Log("SaunaWorkable_OnCompleteWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Spa)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Spa, true);
                }
            }
        }
    }
}
