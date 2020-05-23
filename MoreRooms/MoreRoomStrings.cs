using STRINGS;
using BUILDINGS = STRINGS.BUILDINGS.PREFABS;

namespace MoreRooms
{
    public class MoreRoomStrings
    {
        public class ROOMS
        {
            public class CATEGORIES
            {
                public class ANIMAL
                {
                    public static string NAME = "Zoology";
                    public static string DESCRIPTION = NAME;
                }

                public class RESEARCH
                {
                    public static string NAME = "Research";
                    public static string DESCRIPTION = NAME;
                }

                public class ART
                {
                    public static string NAME = "Art";
                    public static string DESCRIPTION = NAME;
                }

                public class Utility
                {
                    public static string NAME = "Utility";
                    public static string DESCRIPTION = NAME;
                }

                public class MEMORIAL
                {
                    public static string NAME = "Memorial";
                    public static string DESCRIPTION = NAME;
                }
            }

            public class TYPES
            {
                public class PRIVATEQUARTERS
                {
                    public static string ID = "PrivateBedroom";
                    public static string NAME = "Private Quarters";
                    public static string DESCRIPTION = "- Morale, stamina bonus";
                    public static string TOOLTIP = "Sleeping in their Private Quarters will improve a Duplicant's Morale.";
                    public class EFFECT
                    {
                        public static string NAME = "Slept in Private Quarters";
                        public static string DESCRIPTION = "This Duplicant recently slept in their Private Quarters";
                    }
                }

                public class PARLOUR
                {
                    public static string NAME = "Parlour";
                    public static string DESCRIPTION = "- Morale bonus, stress reduction";
                    public static string TOOLTIP = "Sipping a warm drink in a Parlour will improve Duplicants' morale.";
                    public class EFFECT
                    {
                        public static string NAME = "Parlour Drink";
                        public static string DESCRIPTION = "This Duplicant recently enjoyed a warm beverage in a Parlour";
                    }
                }

                public class GAMEROOM
                {
                    public static string NAME = "Game Room";
                    public static string DESCRIPTION = "- Morale bonus";
                    public static string TOOLTIP = "Gaming with dedicated RGB backlights will assuredly improve Duplicants' morale.";
                    public class EFFECT
                    {
                        public static string NAME = "Gamer";
                        public static string DESCRIPTION = "This Duplicant recently abused Mountain Dew in a Game Room";
                    }
                }

                public class GYM
                {
                    public static string NAME = "Training Room";
                    public static string DESCRIPTION = "- Skill gain bonus";
                    public static string TOOLTIP = "Working out on specialized equipment speeds Duplicant training.";
                    public class EFFECT
                    {
                        public static string NAME = "Training";
                        public static string DESCRIPTION = "This Duplicant is working out in a Training Room";
                    }
                }

                public class SPA
                {
                    public static string NAME = "Spa";
                    public static string DESCRIPTION = "- Morale bonus, stress reduction";
                    public static string TOOLTIP = "Relaxing at a Spa bestows lingering therapeutic benefits.";
                    public class EFFECT
                    {
                        public static string NAME = "Spa Day";
                        public static string DESCRIPTION = "This Duplicant found some tranquility at a Spa";
                    }
                }

                public class SPAMASSAGE
                {
                    public static string NAME = "Spa Massage";
                    public static string DESCRIPTION = SPA.DESCRIPTION;
                    public static string TOOLTIP = SPA.TOOLTIP;
                    public class EFFECT
                    {
                        public static string NAME = "Spa Massage";
                        public static string DESCRIPTION = "A massage at a spa is forcibly alleviating this Duplicant's tension";
                    }
                }

                public class KITCHEN
                {
                    public static string NAME = "Kitchen";
                    public static string DESCRIPTION = "- Cooking bonus";
                    public static string TOOLTIP = "Chefs are more productive with the right tools in a Kitchen.";
                    public class EFFECT
                    {
                        public static string NAME = "Kitchen";
                        public static string DESCRIPTION = "This Duplicant is cooking up a storm in a Kitchen";
                    }
                }

                public class ARTISAN
                {
                    public static string NAME = "Artisan Hall";
                    public static string DESCRIPTION = "- Creativity, decor bonuses";
                    public static string TOOLTIP = "Crafting in an Artisan Hall inspires creativity and leaves some residual glitter stuck to Duplicants.";
                    public class EFFECT
                    {
                        public static string NAME = "Favor of the Muses";
                        public static string DESCRIPTION = "Artistic inspiration remains with this Duplicant after crafting in an Artisan Hall";
                    }
                }

                public class PETROPLANT
                {
                    public static string NAME = "Petroleum Plant";
                    public static string DESCRIPTION = "- Physical bonus, decor penalty";
                    public static string TOOLTIP = "Drilling for crude invigorates Duplicants' raw brawn, but the black stains don't wash out easily.";
                    public class EFFECT
                    {
                        public static string NAME = "Texas Tea";
                        public static string DESCRIPTION = "This Duplicant is greasy from working a Petroleum Plant";
                    }
                }

                public class NURSERY
                {
                    public static string NAME = "Botanical Nursery";
                    public static string DESCRIPTION = "- Morale bonus, stress reduction";
                    public static string TOOLTIP = "The earthy smell of of a Nursery soothes Duplicants.";
                    public class EFFECT
                    {
                        public static string NAME = "Earthy Scent";
                        public static string DESCRIPTION = "This Duplicant recently sniffed flowers at a Botanical Nursery";
                    }
                }

                public class SHROOMFARM
                {
                    public static string NAME = "Shroom Farm";
                    public static string DESCRIPTION = "- Attitude bonus, athletics penalty";
                    public static string TOOLTIP = "Partaking in an experience at a Shroom Farm will cause Duplicants to slow down and enjoy existence.";
                    public class EFFECT
                    {
                        public static string NAME = "Far Out";
                        public static string DESCRIPTION = "This Duplicant recently expanded their mind at a Shroom Farm";
                    }
                }

                public class BLUEZOO
                {
                    public static string NAME = "Menagerie";
                    public static string DESCRIPTION = "- Digging, construction bonus";
                    public static string TOOLTIP = "Duplicants observing native creatures build nests will gather new architectural ideas.";
                    public class EFFECT
                    {
                        public static string NAME = "Native Observation";
                        public static string DESCRIPTION = "Native creatures have inspired this Duplicant's engineering paradigms";
                    }
                }

                public class SHINEBUGZOO
                {
                    public static string NAME = "Prismatic Circus";
                    public static string DESCRIPTION = "- Morale, attribute bonus";
                    public static string TOOLTIP = "The rainbow hues of dancing Shinebugs exhilarate and enliven Duplicants.";
                    public class EFFECT
                    {
                        public static string NAME = "Prismatic";
                        public static string DESCRIPTION = "Rainbows still dance through this Duplicant's mind";
                    }
                }

                public class MOOZOO
                {
                    public static string NAME = "Moo Zoo";
                    public static string DESCRIPTION = "- Morale bonus";
                    public static string TOOLTIP = "Watching silly Moos laze about will improve Duplicants' morale.";
                    public class EFFECT
                    {
                        public static string NAME = "Moo Zoo";
                        public static string DESCRIPTION = "This Duplicant fondly recalls the antics of Gassy Moos";

                    }
                }

                public class LABORATORY
                {
                    public static string NAME = "Laboratory";
                    public static string DESCRIPTION = "- Science bonus";
                    public static string TOOLTIP = "Concentrated analysis equipment will increase Duplicants' researching speed.";
                    public class EFFECT
                    {
                        public static string NAME = "Lab Equipment";
                        public static string DESCRIPTION = "This Duplicant is conducting experiments in a Laboratory";
                    }
                }

                public class OBSERVATORY
                {
                    public static string NAME = "Observatory";
                    public static string DESCRIPTION = "- Science bonus";
                    public static string TOOLTIP = "Duplicants gain a lingering aptitude for science after gazing at the stars through a Telescope.";
                    public class EFFECT
                    {
                        public static string NAME = "Stargazed";
                        public static string DESCRIPTION = "The stars recently gazed back at this Duplicant";
                    }
                }

                public class GALLERY
                {
                    public static string NAME = "Gallery";
                    public static string DESCRIPTION = "- Morale bonus";
                    public static string TOOLTIP = "Passing through a Gallery will improve Duplicants' morale for a short while.";
                    public class EFFECT
                    {
                        public static string NAME = "Art Appreciation";
                        public static string DESCRIPTION = "This Duplicant recently ambled past an evocative display in a Gallery";
                    }
                }

                public class MUSEUM
                {
                    public static string NAME = "Museum";
                    public static string DESCRIPTION = "- Science bonus";
                    public static string TOOLTIP = "Passing through a Museum will increase Duplicants' science for a short while.";
                    public class EFFECT
                    {
                        public static string NAME = "Artifact Interest";
                        public static string DESCRIPTION = "This Duplicant recently sauntered past a curious display in a Museum";
                    }
                }

                public class WINTER
                {
                    public static string NAME = "Winter Statuary";
                    public static string DESCRIPTION = "- Temperature resistance";
                    public static string TOOLTIP = "Icy thoughts help Duplicants steel themselves for harsh environments.";
                    public class EFFECT
                    {
                        public static string NAME = "Winter's Embrace";
                        public static string DESCRIPTION = "This Duplicant's mind is numbed to the elements";
                    }
                }

                public class MEMORIAL
                {
                    public static string NAME = "Memorial Chamber";
                    public static string DESCRIPTION = "- Science bonus, attitude penalties";
                    public static string TOOLTIP = "Passing through a Memorial Chamber gives Duplicants a moment of clarity and shadows under their eyes.";
                    public class EFFECT
                    {
                        public static string NAME = "Memento Mori";
                        public static string DESCRIPTION = "This Duplicant was reminded of their fragile mortality in a Memorial Chamber";
                    }
                }

                public class STORAGE
                {
                    public static string NAME = "Storage Room";
                    public static string DESCRIPTION = "- No effect";
                    public static string TOOLTIP = "A Storage Room keeps the colony organized.";
                }
            }

            public class CRITERIA
            {
                public class PRIVATEQUARTERS
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.LUXURYBED.NAME) + ": Exactly 1";
                    public static string DESCRIPTION = NAME;
                }
                
                public class GRILL
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.COOKINGSTATION.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class GASRANGE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.GOURMETCOOKINGSTATION.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class COFFEE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.ESPRESSOMACHINE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class ARCADE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.ARCADEMACHINE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class MANUALGENERATOR
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.MANUALGENERATOR.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class HOTTUB
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.HOTTUB.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class SAUNA
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.SAUNA.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class KILN
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.KILN.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class GLASSFORGE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.GLASSFORGE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class LOOM
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.CLOTHINGFABRICATOR.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class OILWELL
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.OILWELLCAP.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class OILREFINERY
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.OILREFINERY.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class MARBLESCULTPURE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.MARBLESCULPTURE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class PAINTINGS
                {
                    public static int COUNT = 4;
                    public static string NAME = "Paintings: " + COUNT;
                    public static string DESCRIPTION = NAME;
                }

                public class PEDESTALs
                {
                    public static int COUNT = 4;
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.ITEMPEDESTAL.NAME) + ": " + COUNT;
                    public static string DESCRIPTION = NAME;
                }

                public class ICESCULPTURE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.ICESCULPTURE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class WHEEZEWORT
                {
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.COLDBREATHER.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class SHROOMS
                {
                    public static int COUNT = 5;
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.MUSHROOMPLANT.NAME) + ": " + COUNT;
                    public static string DESCRIPTION = NAME;
                }

                public class PITCHERPUMP
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.LIQUIDPUMPINGSTATION.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class COMPOST
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.COMPOST.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class PLANTS
                {
                    public static int COUNT = 4;
                    public static string NAME = "Plants: " + COUNT;
                    public static string DESCRIPTION = NAME;
                }

                public class SMOOTHHATCH
                {
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.HATCH.VARIANT_METAL.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class GLOSSYDRECKO
                {
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.DRECKO.VARIANT_PLASTIC.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class LONGHAIRSLICKSTER
                {
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.OILFLOATER.VARIANT_DECOR.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class SHINEBUGS
                {
                    public static string NAME = "Shinebugs: All";
                    public static string DESCRIPTION = NAME;
                }

                public class GASSYMOO
                {
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.MOO.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class GASGRASS
                {
                    public static string NAME = UI.StripLinkFormatting(CREATURES.SPECIES.GASGRASS.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class RESEARCHSTATIONS
                {
                    public static int COUNT = 2;
                    public static string NAME = "Any Research Stations: " + COUNT;
                    public static string DESCRIPTION = NAME;
                }

                public class PLANETARIUM
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.COSMICRESEARCHCENTER.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class TELESCOPE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.TELESCOPE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class GRAVE
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.GRAVE.NAME);
                    public static string DESCRIPTION = NAME;
                }

                public class STORAGELOCKERS
                {
                    public static int COUNT = 5;
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.STORAGELOCKER.NAME) + ": " + COUNT;
                    public static string DESCRIPTION = NAME;
                }

                public class SMARTSTORAGELOCKER
                {
                    public static string NAME = UI.StripLinkFormatting(BUILDINGS.STORAGELOCKERSMART.NAME);
                    public static string DESCRIPTION = NAME;
                }
            }
        }
    }
}
