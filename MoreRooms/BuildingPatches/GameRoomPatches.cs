using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class GameRoomPatches
    {
        class ArcadePatches
        {
            [HarmonyPatch(typeof(ArcadeMachineWorkable), "OnCompleteWork")]
            public class ArcadeMachineWorkable_OnCompleteWork_Patch
            {
                private static void Postfix(ArcadeMachineWorkable __instance, Worker worker)
                {
                    Log("ArcadeMachineWorkable_OnCompleteWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.GameRoom)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.GameRoom, true);
                }
            }
        }
    }
}
