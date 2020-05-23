using Harmony;
using Klei.AI;
using UnityEngine;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class MemorialPatches
    {
        class GravePatches
        {
            private static readonly EventSystem.IntraObjectHandler<Grave> TriggerRoomEffectsDelegate = new EventSystem.IntraObjectHandler<Grave>(
                (component, data) => Game.Instance.roomProber.GetRoomOfGameObject(component.gameObject)?.roomType.TriggerRoomEffects(component.gameObject.GetComponent<KPrefabID>(), ((GameObject) data).GetComponent<Effects>()));

            [HarmonyPatch(typeof(Grave), "OnPrefabInit")]
            public class Grave_OnPrefabInit_Patch
            {
                private static void Postfix(Painting __instance)
                {
                    Log("Grave_OnPrefabInit_Patch Postfix");
                    __instance.Subscribe((int) GameHashes.ChangeRoom, TriggerRoomEffectsDelegate);
                }
            }
        }
    }
}
