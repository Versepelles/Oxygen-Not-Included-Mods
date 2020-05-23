using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class KitchenPatches
    {
        class ComplexFabricatorWorkablePatches
        {
            [HarmonyPatch(typeof(ComplexFabricatorWorkable), "OnStartWork")]
            public class ComplexFabricatorWorkable_OnStartWork_Patch
            {
                private static void Postfix(Worker worker, ComplexFabricator ___fabricator)
                {
                    Log("ComplexFabricatorWorkable_OnStartWork_Patch Postfix");
                    if (___fabricator != null && ___fabricator.gameObject.PrefabID() == CookingStationConfig.ID || ___fabricator.gameObject.PrefabID() == GourmetCookingStationConfig.ID)
                    {
                        Room room = Game.Instance.roomProber.GetRoomOfGameObject(___fabricator.gameObject);
                        if (room != null && room.roomType == MoreRoomTypes.Kitchen)
                            worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Kitchen, true);
                    }
                }
            }
        }
    }
}
