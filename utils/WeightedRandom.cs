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

        public List<Weight> randomList = new List<Weight>();

        private Random rnd = new Random();
        private List<T> randomPool;

        public WeightedRandom() {}

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

            for (int i = 0; i < randomList.Count; i++)
            {
                for (int j = 0; j < randomList[i].weight; j++)
                {
                    randomPool.Add(randomList[i].obj);
                }
            }
        }

        public void Add(T value, int w){
            if (w <= 0)
                return;

            Weight weight1;
            weight1.obj = value;
            weight1.weight = w;

            randomList.Add(weight1);
        }
    }
}