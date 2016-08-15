using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Hashtable<TKey, TValue> : IDictionary<TKey, TValue>
    {
        int[] buckets;
        Element[] elements;
        int count = 0;
        int previous = 0;
        public Hashtable()
        {
            buckets = new int[10];
            elements = new Element[10];
        }
        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(TKey key, TValue value)
        {
            int hash = GetHash(key);
            previous = buckets[hash];
            elements[count] = new Element(key, value, count-1);
            elements[count + 1].previous = count;
            count++;
            buckets[hash] = count;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool ContainsKey(TKey key)
        {
            if (buckets[GetHash(key)] > 0)
            {
                for (int i = buckets[GetHash(key)]; i != -1; i = elements[i].previous)
                {
                    if (elements[i].key.Equals(key)) return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool Remove(TKey key)
        {
            int hash = GetHash(key);
            if (ContainsKey(key))
            {
                for (int i = buckets[hash]; i != -1; i = elements[i].previous)
                {
                    if(elements[i].key.Equals(key))
                    {
                        elements[i] = default(Element);
                        count--;
                    }
                }
                buckets[hash] = 0;
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private int GetHash(TKey hashCode)
        {
            return hashCode.GetHashCode() % buckets.Length;
        }

        public struct Element
        {
            public TKey key;
            public TValue value;
            public int previous;

            public Element(TKey key, TValue value, int previous)
            {
                this.key = key;
                this.value = value;
                this.previous = previous;
            }
        }
    }
}
