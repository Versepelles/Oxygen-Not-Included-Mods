using Harmony;
using System.Collections.Generic;
using static MoreRooms.MoreRoomPatches;

namespace MoreRooms.BuildingPatches
{
    class PrivateQuartersPatches
    {
        class BedPatches
        {
            [HarmonyPatch(typeof(Bed), "OnSpawn")]
            public class Bed_OnSpawn_Patch
            {
                private static void Postfix(Dictionary<string, string> ___roomSleepingEffects)
                {
                    Log("Bed_OnSpawn_Patch Postfix");
                    ___roomSleepingEffects[MoreRoomStrings.ROOMS.TYPES.PRIVATEQUARTERS.ID] = "BedroomStamina";
                }
            }
        }
    }
}
