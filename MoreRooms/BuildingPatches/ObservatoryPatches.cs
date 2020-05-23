using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class ObservatoryPatches
    {
        class TelescopePatches
        {
            [HarmonyPatch(typeof(Telescope), "OnWorkableEvent")]
            public class Telescope_OnWorkableEvent_Patch
            {
                private static void Postfix(Telescope __instance, Workable.WorkableEvent ev)
                {
                    Log("Telescope_OnWorkableEvent_Patch Postfix");
                    if (ev == Workable.WorkableEvent.WorkStopped)
                    {
                        Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                        if (room != null && room.roomType == MoreRoomTypes.Observatory)
                            __instance.worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Observatory, true);
                    }
                }
            }
        }
    }
}
