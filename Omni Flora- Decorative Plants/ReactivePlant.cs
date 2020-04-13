using System.Collections.Generic;
using UnityEngine;
using STRINGS;

namespace SharlesPlants
{
    class ReactivePlant : SharlesPlant
    {
        public float requiredTemperature;
        public List<SimHashes> reactiveElements;

        public override Condition GetCondition()
        {
            float temperature = smi.master.GetComponent<PrimaryElement>().Temperature;
            int cell = Grid.PosToCell(smi);
            SimHashes element = Grid.Element[cell].id;

            if (temperature > requiredTemperature && reactiveElements.Contains(element))
                    return Condition.Flourishing;
            if (temperature > requiredTemperature || reactiveElements.Contains(element))
                return Condition.Mature;
            return Condition.Juvenile;
        }

        public override List<Descriptor> GetDescriptors(GameObject go)
        {
            List<Descriptor> descriptors = base.GetDescriptors(go);
            string desc = "Reacts above " + GameUtil.GetFormattedTemperature(requiredTemperature) + " with:";
            foreach (SimHashes hash in reactiveElements)
                desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            descriptors.Add(new Descriptor(desc, desc, Descriptor.DescriptorType.Effect, false));
            return descriptors;
        }
    }
}