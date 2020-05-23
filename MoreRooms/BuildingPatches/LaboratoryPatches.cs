using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class LaboratoryPatches
    {
        class ResearchCenterPatches
        {
            [HarmonyPatch(typeof(ResearchCenter), "OnStartWork")]
            public class ResearchCenter_OnStartWork_Patch
            {
                private static void Postfix(ResearchCenter __instance, Worker worker)
                {
                    Log("ResearchCenter_OnStartWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Laboratory)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Laboratory, true);
                }
            }

            [HarmonyPatch(typeof(ResearchCenter), "OnStopWork")]
            public class ResearchCenter_OnStopWork_Patch
            {
                private static void Postfix(Worker worker)
                {
                    Log("ResearchCenter_OnStopWork_Patch Postfix");
                    worker?.GetComponent<Effects>().Remove(MoreRoomEffects.IDs.Laboratory);
                }
            }
        }
    }
}
