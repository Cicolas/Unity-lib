using UnityEngine;

namespace Anna.utils
{
    /// <summary>
    /// This script can be used to mange and create minValues and maxValues.
    /// it's a range shorthand.
    /// </summary>
    public class MinMaxRange {
        public float minVal;
        public float maxVal;

        public MinMaxRange(float min, float max){
            this.maxVal = max;
            
            if (min < max)
            {
                this.minVal = min;
                return;
            }
            Debug.LogError("Min Value of a MinMaxRange cannot be higher or equal than the Max Value");
        }

        public float GetRandomValueBetween(){
            return Random.value*(maxVal-minVal)+minVal;
        }
    }
}