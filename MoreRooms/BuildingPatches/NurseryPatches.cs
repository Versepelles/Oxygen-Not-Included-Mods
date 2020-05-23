using Harmony;
using Klei.AI;
using UnityEngine;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class NurseryPatches
    {
        class PitcherPumpPatches
        {
            [HarmonyPatch(typeof(LiquidPumpingStationConfig), "ConfigureBuildingTemplate")]
            public class LiquidPumpingStationConfig_ConfigureBuildingTemplate_Patch
            {
                private static void Postfix(GameObject go)
                {
                    Log("LiquidPumpingStationConfig_ConfigureBuildingTemplate_Patch Postfix");
                    go.AddOrGet<PitcherPump>();
                }
            }

            public class PitcherPump : KMonoBehaviour
            {
                private static readonly EventSystem.IntraObjectHandler<PitcherPump> TriggerRoomEffectsDelegate = new EventSystem.IntraObjectHandler<PitcherPump>(
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
