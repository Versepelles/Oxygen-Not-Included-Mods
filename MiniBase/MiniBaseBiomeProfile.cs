using System.Collections.Generic;
using static MiniBase.MiniBaseConfig;

namespace MiniBase
{
    public class MiniBaseBiomeProfile
    {
        public string backgroundSubworld;
        public SimHashes defaultMaterial;
        public float defaultTemperature;
        public BandInfo[] bandProfile;
        public List<KeyValuePair<string, float>> startingItems;
        public Dictionary<string, float> spawnablesOnFloor;
        public Dictionary<string, float> spawnablesOnCeil;
        public Dictionary<string, float> spawnablesInGround;
        public Dictionary<string, float> spawnablesInLiquid;
        public Dictionary<string, float> spawnablesInAir;

        public MiniBaseBiomeProfile(
            string backgroundSubworld,
            SimHashes defaultMaterial,
            float defaultTemperature,
            BandInfo[] bandProfile,
            List<KeyValuePair<string, float>> startingItems = null,
            Dictionary<string, float> spawnablesOnFloor = null,
            Dictionary<string, float> spawnablesOnCeil = null,
            Dictionary<string, float> spawnablesInGround = null,
            Dictionary<string, float> spawnablesInLiquid = null,
            Dictionary<string, float> spawnablesInAir = null)
        {
            this.backgroundSubworld = backgroundSubworld;
            this.defaultMaterial = defaultMaterial;
            this.defaultTemperature = defaultTemperature;
            this.bandProfile = bandProfile;
            this.startingItems = startingItems ?? new List<KeyValuePair<string, float>>();
            this.spawnablesOnFloor = spawnablesOnFloor ?? new Dictionary<string, float>();
            this.spawnablesOnCeil = spawnablesOnCeil ?? new Dictionary<string, float>();
            this.spawnablesInGround = spawnablesInGround ?? new Dictionary<string, float>();
            this.spawnablesInLiquid = spawnablesInLiquid ?? new Dictionary<string, float>();
            this.spawnablesInAir = spawnablesInAir ?? new Dictionary<string, float>();
        }

        public Element DefaultElement() { return ElementLoader.FindElementByHash(defaultMaterial); }

        // Return the corresponding element band info from the float in [0.0, 1.0]
        public BandInfo GetBand(float f)
        {
            for (int i = 0; i < bandProfile.Length; i++)
                if (f < bandProfile[i].cumulativeWeight)
                    return bandProfile[i];
            return bandProfile[bandProfile.Length - 1];
        }
        
        public Sim.PhysicsData GetPhysicsData(BandInfo band, float modifier = 1f)
        {
            float temperature = (band.temperature < 0 && defaultTemperature > 0) ? defaultTemperature : band.temperature;
            return MiniBaseWorldGen.GetPhysicsData(band.GetElement(), modifier * band.density, temperature);
        }
    }

    public struct BandInfo
    {
        public float cumulativeWeight;
        public SimHashes elementId;
        public float temperature;
        public float density;
        public DiseaseID disease;

        public BandInfo(float cumulativeWeight, SimHashes elementId, float temperature = -1f, float density = 1f, DiseaseID disease = DiseaseID.NONE)
        {
            this.cumulativeWeight = cumulativeWeight;
            this.elementId = elementId;
            this.temperature = temperature;
            this.density = density;
            this.disease = disease;
        }

        public Element GetElement() { return ElementLoader.FindElementByHash(elementId); }
    }
}
