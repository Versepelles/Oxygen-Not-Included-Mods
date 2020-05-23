using Harmony;
using Klei.AI;
using UnityEngine;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class GalleryMuseumPatches
    {
        class MarbleSculpturePatches
        {
            [HarmonyPatch(typeof(MarbleSculptureConfig), "ConfigureBuildingTemplate")]
            public class MarbleSculptureConfig_ConfigureBuildingTemplate_Patch
            {
                private static void Postfix(GameObject go)
                {
                    Log("MarbleSculptureConfig_ConfigureBuildingTemplate_Patch Postfix");
                    go.AddOrGet<MarbleSculpture>();
                }
            }

            public class MarbleSculpture : KMonoBehaviour
            {
                private static readonly EventSystem.IntraObjectHandler<MarbleSculpture> TriggerRoomEffectsDelegate = new EventSystem.IntraObjectHandler<MarbleSculpture>(
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
