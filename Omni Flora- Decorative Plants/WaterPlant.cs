using System.Collections.Generic;
using UnityEngine;

namespace SharlesPlants
{
    class WaterPlant : SharlesPlant
    {
        public float preferredTemperature;
        public List<SimHashes> preferredElements;
        public List<SimHashes> toleratedElements;

        public override Condition GetCondition()
        {
            float temperature = smi.master.GetComponent<PrimaryElement>().Temperature;
            int cell = Grid.PosToCell(smi);
            SimHashes element = Grid.Element[cell].id;

            if (temperature > preferredTemperature && preferredElements.Contains(element))
                return Condition.Flourishing;
            if (preferredElements.Contains(element) || (toleratedElements.Contains(element) && temperature > preferredTemperature))
                return Condition.Mature;
            return Condition.Juvenile;
        }

        public override List<Descriptor> GetDescriptors(GameObject go)
        {
            List<Descriptor> descriptors = base.GetDescriptors(go);
            string desc = "Flourishes above " + GameUtil.GetFormattedTemperature(preferredTemperature) + " in:";
            foreach (SimHashes hash in preferredElements)
                desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            descriptors.Add(new Descriptor(desc, desc, Descriptor.DescriptorType.Effect, false));
            desc = "Tolerates: ";
            foreach (SimHashes hash in toleratedElements)
                desc += "\n    • " + ElementLoader.FindElementByHash(hash).name;
            descriptors.Add(new Descriptor(desc, desc, Descriptor.DescriptorType.Effect, false));
            return descriptors;
        }
    }
}