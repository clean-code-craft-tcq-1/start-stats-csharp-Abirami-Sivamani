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
    
     public class StatsAlerter
    {
        private float threshold;
        private IAlerter[] alert;
        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            this.threshold = maxThreshold;
            this.alert = alerters;
        }
        public void checkAndAlert(List<float> numbers)
        {
            float max = 0.0F;
            foreach (float num in numbers)
            {
                max = Math.Max(max, num);
            }
            if (max > threshold)
            {
                foreach (var alt in alert)
                {
                    alt.RaiseAlert();
                }
            }
        }
    }

    public interface IAlerter
    {      
        void RaiseAlert();
    }

    public class EmailAlert : IAlerter
    {
        public bool emailSent;
        public void RaiseAlert()
        {
            emailSent = true;
        }
    }
    public class LEDAlert : IAlerter
    {
        public bool ledGlows;
        public void RaiseAlert()
        {
            ledGlows = true;
        }
    }
}
