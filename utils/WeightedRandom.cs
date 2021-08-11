using System.Collections.Generic;
using System;

namespace Anna
{
    /// <summary>
    /// This script can be used to create weighted random lists.
    ///
    /// it's a weighted random shorthand.
    /// </summary>
    [Serializable]
    public class WeightedRandom<T> {
        [Serializable]
        public struct Weight {
            public T obj;
            public int weight;
        }

        public Weight[] randomList;

        private Random rnd = new Random();
        private List<T> randomPool;

        WeightedRandom() {}

        public T GetRandom(){
            SetupPool();
            randomPool.Shuffle();
            return randomPool[(rnd.Next()%randomPool.Count)];
        }

        public void SetupPool(){
            if(randomPool == null){
                randomPool = new List<T>();
            }

            randomPool.Clear();

            for (int i = 0; i < randomList.Length; i++)
            {
                for (int j = 0; j < randomList[i].weight; j++)
                {
                    randomPool.Add(randomList[i].obj);
                }
            }
        }
    }
}