using System;
using System.Collections.Generic;
using System.Linq;

namespace Dickery
{
    public class Lictionary<TKey, TValue> where TValue : IEquatable<TValue>
    {
        private readonly Dictionary<TKey, List<TValue>> innerDictionary = new Dictionary<TKey, List<TValue>>();

        public void Add(TKey key, TValue value)
        {
            List<TValue> valueList;
            if (innerDictionary.TryGetValue(key, out valueList))
            {
                if (valueList.Count > 0 && !valueList.Contains(value))
                {
                    valueList.Add(value);
                }
            }
            else
            {
                innerDictionary.Add(key, new List<TValue> { value });
            }
        }

        public List<TValue> GetValues(TKey key)
        {
            List<TValue> valueList;
            if (innerDictionary.TryGetValue(key, out valueList))
            {
                return valueList;
            }

            return new List<TValue>();
        }

        public void RemoveValueFromKey(TKey key, TValue value)
        {
            List<TValue> valueList;
            if (innerDictionary.TryGetValue(key, out valueList))
            {
                if (valueList.Count > 0 && valueList.Contains(value))
                {
                    valueList.Remove(value);
                }
            }
        }

        public void RemoveKey(TKey key)
        {
            innerDictionary.Remove(key);
        }
    }
}
