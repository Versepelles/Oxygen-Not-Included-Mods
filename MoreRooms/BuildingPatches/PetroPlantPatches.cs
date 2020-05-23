using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class PetroPlantPatches
    {
        class OilRefineryPatches
        {
            [HarmonyPatch(typeof(OilRefinery.WorkableTarget), "OnStartWork")]
            public class OilRefinery_WorkableTarget_OnStartWork_Patch
            {
                private static void Postfix(OilRefinery.WorkableTarget __instance, Worker worker)
                {
                    Log("OilRefinery_WorkableTarget_OnStartWork_Patch Postfix");
                    Room room = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
                    if (room != null && room.roomType == MoreRoomTypes.PetroPlant)
                        worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.PetroPlant, true);
                }
            }
        }
    }
}
