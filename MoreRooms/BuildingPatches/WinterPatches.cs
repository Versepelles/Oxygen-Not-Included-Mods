using Harmony;
using Klei.AI;
using UnityEngine;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class WinterPatches
    {
        class IceSculpturePatches
        { 
            [HarmonyPatch(typeof(IceSculptureConfig), "ConfigureBuildingTemplate")]
            public class IceSculptureConfig_ConfigureBuildingTemplate_Patch
            {
                private static void Postfix(GameObject go)
                {
                    Log("IceSculptureConfig_ConfigureBuildingTemplate_Patch Postfix");
                    go.AddOrGet<IceSculpture>();
                }
            }

            public class IceSculpture : KMonoBehaviour
            {
                private static readonly EventSystem.IntraObjectHandler<IceSculpture> TriggerRoomEffectsDelegate = new EventSystem.IntraObjectHandler<IceSculpture>(
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
