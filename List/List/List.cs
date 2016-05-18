using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class List<T> : IList<T>
    {
        int dimension = 0;
        T[] list = new T[0];
        public T this[int index]
        {
            get
            {
                return list[index];
            }

            set
            {
                list[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return dimension;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[dimension] = item;
            dimension++;
        }

        public void Clear()
        {
            Array.Resize(ref list, 0);
            dimension = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < list.Length; i++)
                if (list[i].Equals(item))
                    return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            bool check = false;
            for (int i = 0; i < list.Length - 1; i++)
            {
                if (list[i].Equals(item))
                    check = true;
                if (check)
                    list[i] = list[i + 1];
            }
            if (check || list[list.Length-1].Equals(item))
            {
                Array.Resize(ref list, list.Length - 1);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
