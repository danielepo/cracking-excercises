using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class SimpleHashTable<T>
    {
        HashSet<T> set = new HashSet<T>();
        
        public void Add(T item)
        {
            set.Add(item);
        }
        public bool HasItem(T item)
        {
            return set.Contains(item);
        }
    }
}