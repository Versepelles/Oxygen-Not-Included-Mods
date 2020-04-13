using System.Collections.Generic;
using UnityEngine;

namespace SharlesPlants
{
    class ColdLovingPlant : SharlesPlant
    {
        public float lowTransition;
        public float highTransition;

        public override Condition GetCondition()
        {
            float temperature = smi.master.GetComponent<PrimaryElement>().Temperature;

            if (temperature <= lowTransition)
                return Condition.Flourishing;
            if (temperature >= highTransition)
                return Condition.Juvenile;
            return Condition.Mature;
        }

        public override List<Descriptor> GetDescriptors(GameObject go)
        {
            List<Descriptor> descriptors = base.GetDescriptors(go);
            string desc = "Matures below " + GameUtil.GetFormattedTemperature(highTransition);
            descriptors.Add(new Descriptor(desc, desc, Descriptor.DescriptorType.Effect, false));
            desc = "Flourishes below " + GameUtil.GetFormattedTemperature(lowTransition);
            descriptors.Add(new Descriptor(desc, desc, Descriptor.DescriptorType.Effect, false));
            return descriptors;
        }
    }
}