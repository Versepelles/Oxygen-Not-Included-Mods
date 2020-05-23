using Harmony;
using Klei.AI;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class ArtisanPatches
    {
        class GlassForgePatches
        {
            [HarmonyPatch(typeof(ComplexFabricatorWorkable), "OnCompleteWork")]
            public class ComplexFabricatorWorkable_OnCompleteWork_Patch
            {
                private static void Postfix(Worker worker, ComplexFabricator ___fabricator)
                {
                    Log("ComplexFabricatorWorkable_OnCompleteWork_Patch Postfix");
                    if(___fabricator != null && ___fabricator.gameObject.PrefabID() == GlassForgeConfig.ID || ___fabricator.gameObject.PrefabID() == ClothingFabricatorConfig.ID)
                    {
                        Room room = Game.Instance.roomProber.GetRoomOfGameObject(___fabricator.gameObject);
                        if (room != null && room.roomType == MoreRoomTypes.Artisan)
                            worker?.GetComponent<Effects>().Add(MoreRoomEffects.IDs.Artisan, true);
                    }
                }
            }
        }
    }
}
