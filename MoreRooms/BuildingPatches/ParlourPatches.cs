using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class ParlourPatches
    {
        class EspressoMachinePatches
        {
            [HarmonyPatch(typeof(EspressoMachineWorkable), "OnCompleteWork")]
            public class EspressoMachineWorkable_OnCompleteWork_Patch
            {
                private static void Postfix(Telescope __instance, Worker worker)
                {
                    Log("EspressoMachineWorkable_OnCompleteWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.Parlour)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Parlour, true);
                }
            }
        }
    }
}
