using Klei.AI;
using RSTRINGS = MoreRooms.MoreRoomStrings.ROOMS.TYPES;

namespace MoreRooms
{
    class MoreRoomEffects
    {
        public static void CreateEffects(Db db)
        {
            // TODO: UI only for lingering effects
            const float OneDay = 600f;
            const float PercentPerCycle = 0.001666667f;
            Effect effect;
            string effectName;

            effectName = RSTRINGS.PRIVATEQUARTERS.EFFECT.NAME;
            effect = new Effect(IDs.PrivateQuarters, effectName, RSTRINGS.PRIVATEQUARTERS.EFFECT.DESCRIPTION, 1.1f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 3, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stamina.deltaAttribute.Id, -5f * PercentPerCycle, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.PARLOUR.EFFECT.NAME;
            effect = new Effect(IDs.Parlour, effectName, RSTRINGS.PARLOUR.EFFECT.DESCRIPTION, 0.5f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stress.deltaAttribute.Id, -5f * PercentPerCycle, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.GAMEROOM.EFFECT.NAME;
            effect = new Effect(IDs.GameRoom, effectName, RSTRINGS.GAMEROOM.EFFECT.DESCRIPTION, 4.0f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 2, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.GYM.EFFECT.NAME;
            effect = new Effect(IDs.Gym, effectName, RSTRINGS.GYM.EFFECT.DESCRIPTION, 0.75f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Learning.Id, 3, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stamina.deltaAttribute.Id, -20f * PercentPerCycle, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.SPA.EFFECT.NAME;
            effect = new Effect(IDs.Spa, effectName, RSTRINGS.SPA.EFFECT.DESCRIPTION, 4.0f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stress.deltaAttribute.Id, -10f * PercentPerCycle, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.SPAMASSAGE.EFFECT.NAME;
            effect = new Effect(IDs.SpaMassage, effectName, RSTRINGS.SPAMASSAGE.EFFECT.DESCRIPTION, OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Amounts.Stress.deltaAttribute.Id, -40f * PercentPerCycle, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.KITCHEN.EFFECT.NAME;
            effect = new Effect(IDs.Kitchen, effectName, RSTRINGS.KITCHEN.EFFECT.DESCRIPTION, 0.75f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Cooking.Id, 3, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.ARTISAN.EFFECT.NAME;
            effect = new Effect(IDs.Artisan, effectName, RSTRINGS.ARTISAN.EFFECT.DESCRIPTION, 2.0f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Decor.Id, 10, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Art.Id, 3, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.PETROPLANT.EFFECT.NAME;
            effect = new Effect(IDs.PetroPlant, effectName, RSTRINGS.PETROPLANT.EFFECT.DESCRIPTION, 3.0f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Decor.Id, -10, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Strength.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Machinery.Id, 2, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.NURSERY.EFFECT.NAME;
            effect = new Effect(IDs.Nursery, effectName, RSTRINGS.NURSERY.EFFECT.DESCRIPTION, 0.5f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 1, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stress.deltaAttribute.Id, -5f * PercentPerCycle, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.SHROOMFARM.EFFECT.NAME;
            effect = new Effect(IDs.ShroomFarm, effectName, RSTRINGS.SHROOMFARM.EFFECT.DESCRIPTION, 0.5f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stress.deltaAttribute.Id, -10f * PercentPerCycle, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Art.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Athletics.Id, -3, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.BLUEZOO.EFFECT.NAME;
            effect = new Effect(IDs.BlueZoo, effectName, RSTRINGS.BLUEZOO.EFFECT.DESCRIPTION, OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 1, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Digging.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Construction.Id, 2, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.SHINEBUGZOO.EFFECT.NAME;
            effect = new Effect(IDs.ShinebugZoo, effectName, RSTRINGS.SHINEBUGZOO.EFFECT.DESCRIPTION, OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 7, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Construction.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Machinery.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Cooking.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Botanist.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Ranching.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Caring.Id, 2, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Art.Id, 2, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.MOOZOO.EFFECT.NAME;
            effect = new Effect(IDs.MooZoo, effectName, RSTRINGS.MOOZOO.EFFECT.DESCRIPTION, OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 5, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.LABORATORY.EFFECT.NAME;
            effect = new Effect(IDs.Laboratory, effectName, RSTRINGS.LABORATORY.EFFECT.DESCRIPTION, 0.75f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Learning.Id, 2, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.OBSERVATORY.EFFECT.NAME;
            effect = new Effect(IDs.Observatory, effectName, RSTRINGS.OBSERVATORY.EFFECT.DESCRIPTION, OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Learning.Id, 3, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.GALLERY.EFFECT.NAME;
            effect = new Effect(IDs.Gallery, effectName, RSTRINGS.GALLERY.EFFECT.DESCRIPTION, 0.333f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 1, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.MUSEUM.EFFECT.NAME;
            effect = new Effect(IDs.Museum, effectName, RSTRINGS.MUSEUM.EFFECT.DESCRIPTION, 0.333f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.Learning.Id, 2, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.WINTER.EFFECT.NAME;
            effect = new Effect(IDs.WinterRoom, effectName, RSTRINGS.WINTER.EFFECT.DESCRIPTION, 0.333f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, 1, effectName));
            effect.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.INSULATION, 5, effectName));
            effect.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.THERMAL_CONDUCTIVITY_BARRIER, 0.05f, effectName));
            effect.Add(new AttributeModifier(db.Attributes.ScaldingThreshold.Id, 20f, effectName));
            db.effects.Add(effect);

            effectName = RSTRINGS.MEMORIAL.EFFECT.NAME;
            effect = new Effect(IDs.Memorial, effectName, RSTRINGS.MEMORIAL.EFFECT.DESCRIPTION, 0.75f * OneDay, true, false, false);
            effect.Add(new AttributeModifier(db.Attributes.QualityOfLife.Id, -1, effectName));
            effect.Add(new AttributeModifier(db.Amounts.Stress.deltaAttribute.Id, 25 * PercentPerCycle, effectName));
            effect.Add(new AttributeModifier(db.Attributes.Learning.Id, 2, effectName));
            db.effects.Add(effect);
        }

        public class IDs
        {
            public static readonly string PrivateQuarters = nameof(PrivateQuarters);
            public static readonly string Parlour = nameof(Parlour);
            public static readonly string GameRoom = nameof(GameRoom);
            public static readonly string Gym = nameof(Gym);
            public static readonly string Spa = nameof(Spa);
            public static readonly string SpaMassage = nameof(SpaMassage);
            public static readonly string Kitchen = nameof(Kitchen);
            public static readonly string Artisan = nameof(Artisan);
            public static readonly string PetroPlant = nameof(PetroPlant);
            public static readonly string Nursery = nameof(Nursery);
            public static readonly string ShroomFarm = nameof(ShroomFarm);
            public static readonly string BlueZoo = nameof(BlueZoo);
            public static readonly string ShinebugZoo = nameof(ShinebugZoo);
            public static readonly string MooZoo = nameof(MooZoo);
            public static readonly string Laboratory = nameof(Laboratory);
            public static readonly string Observatory = nameof(Observatory);
            public static readonly string Gallery = nameof(Gallery);
            public static readonly string Museum = nameof(Museum);
            public static readonly string WinterRoom = nameof(WinterRoom);
            public static readonly string Memorial = nameof(Memorial);
        }
    }
}
