using System;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer : Stats
    {
        public Stats CalculateStatistics(List<float> numbers) {
            Stats statsObj = new Stats();
            //Implement statistics here
            if (numbers.Count > 0)
            {
                float sum = 0.0F, maxValue = 0.0F, minValue = 9999.99F;
                foreach(float num in numbers)
                {
                    sum += num;
                    maxValue = Math.Max(maxValue, num);
                    minValue = Math.Min(minValue, num);
                }
                statsObj.average = sum / numbers.Count;
                statsObj.max = maxValue;
                statsObj.min = minValue;
                return statsObj;
            }
             return statsObj;   
        }
    }
    public class Stats
    {
        public double average = Double.NaN, max = Double.NaN, min = Double.NaN;
    }
}
