using System;
using UnityEngine;

namespace Anna
{
    /// <summary>
    /// This script can be used to mange and create minValues and maxValues.
    /// it's a range shorthand.
    /// </summary>
    [Serializable]
    public class MinMaxRange {
        public float min;
        public float max;

        public MinMaxRange(){}

        public MinMaxRange(float min, float max){
            this.max = max;
            
            if (min < max)
            {
                this.min = min;
                return;
            }
            Debug.LogError("Min Value of a MinMaxRange cannot be higher or equal than the Max Value");
        }

        public bool InRange(float number){
            if (number > min && number < max)
                return true;
            return false;
        }

        public float GetRandomValueBetween(){
            return UnityEngine.Random.value*(max-min)+min;
        }

        public float range{get{return max-min;}}
    }
}