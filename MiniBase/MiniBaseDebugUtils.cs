using System;
using UnityEngine;
using static MiniBase.MiniBaseConfig;

namespace MiniBase
{
    class MiniBaseDebugUtils
    {
        public static void Log(String msg)
        {
            if (DEBUG_MODE)
                Console.WriteLine("<MiniBase> " + msg);
        }

        public static void TestNoiseMaps()
        {
            int NumTests = 20;
            System.Random random = new System.Random();
            for (int i = 0; i < NumTests; i++)
                PrintNoiseMapBuckets(MiniBaseWorldGen.GenerateNoiseMap(random, MiniBaseWorldGen.Width(), MiniBaseWorldGen.Height()), 20);
        }

        // Debug util method to visualize noisemap
        public static void PrintNoiseMapBuckets(float[,] map, int numBuckets)
        {
            float[] buckets = new float[numBuckets];
            float total = 0f;
            int outliersLow = 0;
            int outliersHigh = 0;
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    float f = Mathf.Clamp(map[i, j], 0f, 1f);
                    if (f <= 0)
                        outliersLow++;
                    else if (f >= 1)
                        outliersHigh++;
                    int index = Math.Max(0, Math.Min(numBuckets - 1, (int) (f * numBuckets))); // Clamp
                    buckets[index]++;
                    total += f;
                }
            string div = "\n----------------------------------------------------------------------------------------\n";
            string str = div + $"NoiseMap   average: {total / map.Length}   low: {outliersLow}   high: {outliersHigh}\n";
            for (int i = 0; i < numBuckets; i++)
                str += (int) Mathf.RoundToInt(buckets[i] * 100f / map.Length) + (i == numBuckets / 2 ? "*" : "") + " ";
            str += div;
            Log(str);
        }
    }
}
