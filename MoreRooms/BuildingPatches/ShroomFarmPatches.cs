using Harmony;
using Klei.AI;
using UnityEngine;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class ShroomFarmPatchesPatches
    {
        class FarmStationPatches
        {
            [HarmonyPatch(typeof(FarmStationConfig), "ConfigureBuildingTemplate")]
            public class FarmStationConfig_ConfigureBuildingTemplate_Patch
            {
                private static void Postfix(GameObject go)
                {
                    Log("FarmStationConfig_ConfigureBuildingTemplate_Patch Postfix");
                    go.AddOrGet<FarmStation>();
                }
            }

            public class FarmStation : KMonoBehaviour
            {
                private static readonly EventSystem.IntraObjectHandler<FarmStation> TriggerRoomEffectsDelegate = new EventSystem.IntraObjectHandler<FarmStation>(
                    (component, data) => Game.Instance.roomProber.GetRoomOfGameObject(component.gameObject)?.roomType.TriggerRoomEffects(component.gameObject.GetComponent<KPrefabID>(), ((GameObject) data).GetComponent<Effects>()));

                protected override void OnPrefabInit()
                {
                    base.OnPrefabInit();
                    Subscribe((int) GameHashes.ChangeRoom, TriggerRoomEffectsDelegate);
                }
            }
        }
    }
}
