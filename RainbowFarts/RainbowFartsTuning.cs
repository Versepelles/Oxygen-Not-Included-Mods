using System;
using UnityEngine;

namespace RainbowFarts
{
    public class RainbowFartsTuning
    {
        private static System.Random random = new System.Random();
        public const int RAINBOW = -1;
        public static readonly Color FLATULENCE_TRAIT_COLOR = new Color(163/255f, 64/255f, 223/255f);

        public static TraitInfo HYDROGEN_FLATULENCE = new TraitInfo("flatulence_h2", "Floaty Flatulence", "Farts hydrogen frequently", "This dupe might just float away\n• Farts " + STRINGS.ELEMENTS.HYDROGEN.NAME, SimHashes.Hydrogen);
        public static TraitInfo CHLORINE_FLATULENCE = new TraitInfo("flatulence_cl", "Clean Flatulence", "Farts chlorine frequently", "This dupe's behind is sqeaky clean\n• Farts " + STRINGS.ELEMENTS.CHLORINEGAS.NAME, SimHashes.ChlorineGas);
        public static TraitInfo OXYGEN_FLATULENCE = new TraitInfo("flatulence_o2", "Airy Flatulence", "Farts oxygen frequently", "This dupe just swallowed a lot of air\n• Farts " + STRINGS.ELEMENTS.OXYGEN.NAME, SimHashes.Oxygen);
        public static TraitInfo POLLUTED_OXYGEN_FLATULENCE = new TraitInfo("flatulence_po2", "Smelly Flatulence", "Farts polluted oxygen frequently", "This dupe has terrible indigestion\n• Farts " + STRINGS.ELEMENTS.CONTAMINATEDOXYGEN.NAME, SimHashes.ContaminatedOxygen);
        public static TraitInfo CARBON_DIOXIDE_FLATULENCE = new TraitInfo("flatulence_co2", "Heavy Flatulence", "Farts carbon dioxide frequently", "This dupe could make diamonds if they tried\n• Farts " + STRINGS.ELEMENTS.CARBONDIOXIDE.NAME, SimHashes.CarbonDioxide);
        public static TraitInfo METHANE_FLATULENCE = new TraitInfo("flatulence_meth", "Normal Flatulence", "Farts natural gas frequently", "This dupe is actually normal\n• Farts " + STRINGS.ELEMENTS.METHANE.NAME, SimHashes.Methane);
        public static TraitInfo SOUR_GAS_FLATULENCE = new TraitInfo("flatulence_sour", "Sour Flatulence", "Farts sour gas frequently", "Something horrible has happened in this dupe's intestines\n• Farts " + STRINGS.ELEMENTS.SOURGAS.NAME, SimHashes.SourGas);
        public static TraitInfo RAINBOW_FLATULENCE = new TraitInfo("flatulence_rainbow", "Rainbow Flatulence", "Farts a variety of elements", "This dupe farts the entire smellable spectrum", (SimHashes) RAINBOW);
        
        public static TraitInfo[] FLATULENCE_TYPES = new TraitInfo[8]
        {
            HYDROGEN_FLATULENCE,
            CHLORINE_FLATULENCE,
            OXYGEN_FLATULENCE,
            POLLUTED_OXYGEN_FLATULENCE,
            CARBON_DIOXIDE_FLATULENCE,
            METHANE_FLATULENCE,
            SOUR_GAS_FLATULENCE,
            RAINBOW_FLATULENCE
        };

        public static TraitInfo GetRandomFlatulence(bool includeRainbow = false)
        {
            return FLATULENCE_TYPES[random.Next(0, FLATULENCE_TYPES.Length - (includeRainbow ? 0 : 1))];
        }

        public struct TraitInfo
        {
            public string id;
            public string name;
            public string desc;
            public string tooltip;
            public SimHashes element;

            public TraitInfo(string id, string name, string desc, string tooltip, SimHashes element)
            {
                this.id = id;
                this.name = name;
                this.desc = desc;
                this.tooltip = tooltip;
                this.element = element;
            }
        }
    }
}
