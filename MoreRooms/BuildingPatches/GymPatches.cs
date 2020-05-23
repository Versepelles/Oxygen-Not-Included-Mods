using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class GymPatches
    {
        class ManualGeneratorPatches
        {
            [HarmonyPatch(typeof(ManualGenerator), "OnStartWork")]
            public class ManualGenerator_OnStartWork_Patch
            {
                private static void Postfix(ManualGenerator __instance, Worker worker)
                {
                    Log("ManualGenerator_OnStartWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Gym)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Gym, true);
                }
            }

            [HarmonyPatch(typeof(ManualGenerator), "OnStopWork")]
            public class ManualGenerator_OnStopWork_Patch
            {
                private static void Postfix(Worker worker)
                {
                    Log("ManualGenerator_OnStopWork_Patch Postfix");
                    worker?.GetComponent<Effects>().Remove(MoreRoomEffects.IDs.Gym);
                }
            }
        }
    }
}
