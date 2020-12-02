/*
	MIT License

	Copyright (c) 2020 Steven Brelsford (Versepelles)

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
 */

using System;
using System.Collections.Generic;
using Harmony;
using Klei.AI;
using UnityEngine;
using static RainbowFarts.RainbowFartsTuning;

namespace RainbowFarts
{
    public class RainbowFartsPatches
    {
		public static bool DebugMode = false;

		public static class Mod_OnLoad
		{
			public static void OnLoad(string modPath)
			{
				Log("RainbowFarts loaded.", true);
			}
		}
		
		// Add new Flatulence traits and remove default Flatulence trait
		[HarmonyPatch(typeof(ModifierSet), "LoadTraits")]
		public class ModifierSet_LoadTraits_Patch
		{
			public static void Prefix()
			{
				Log("ModifierSet_LoadTraits_Patch Prefix");
				TUNING.DUPLICANTSTATS.BADTRAITS.RemoveAll(t => t.id == "Flatulence");
				foreach(TraitInfo trait in FLATULENCE_TYPES)
					CreateComponentTrait(trait);
			}

			private static void CreateComponentTrait(TraitInfo info)
			{
				Trait trait = Db.Get().CreateTrait(info.id, info.name, info.tooltip, null, true, null, false, false);
				trait.OnAddTrait = go =>
				{
					var flatulence = go.FindOrAddUnityComponent<RainbowFlatulence>();
					flatulence.EmitElement = info.element;
				};
				Strings.Add("STRINGS.DUPLICANTS.TRAITS." + info.id.ToUpperInvariant() + ".SHORT_DESC", info.desc);
				Strings.Add("STRINGS.DUPLICANTS.TRAITS." + info.id.ToUpperInvariant() + ".SHORT_DESC_TOOLTIP", info.tooltip);
			}
		}

		// Add Flatulent trait to prospective duplicants
		[HarmonyPatch(typeof(MinionStartingStats), "GenerateTraits")]
		public class MinionStartingStats_GenerateTraits_Patch
		{
			public static void Postfix(MinionStartingStats __instance)
			{
				Log("MinionStartingStats_GenerateTraits_Patch Postfix");
				Trait trait = Db.Get().traits.TryGet(GetRandomFlatulence(true).id);
				__instance.Traits.Add(trait);
			}
		}

		// Trim minion selection panels and change Flatulence trait color
		[HarmonyPatch(typeof(CharacterContainer), "SetInfoText")]
		public class CharacterContainer_SetInfoText_Patch
		{
			public static void Postfix(ref LocText ___description, ref List<GameObject> ___traitEntries)
			{
				Log("CharacterContainer_SetInfoText_Patch Postfix");
				___description.text = ""; // Remove minion flavor text for spacing reasons
				foreach (var go in ___traitEntries)
				{
					var locText = go.GetComponent<LocText>();
					if (locText?.text != null && locText.text.Contains("Flatulence"))
						locText.color = FLATULENCE_TRAIT_COLOR;
				}
			}
		}

		public static void Log(string msg, bool force = false)
		{
			if (force || DebugMode)
				Console.WriteLine("<RainbowFarts> " + msg);
		}
	}
}
