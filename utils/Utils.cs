using System.Collections.Generic;
using System;

namespace Anna
{
    public static class Utils {
        private static Random rng = new Random();  
        public static List<T> Shuffle<T>(this List<T> list) {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }
            return list;
        }
    }
}