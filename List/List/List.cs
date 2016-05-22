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
        int lastPosition = -1;
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
                return lastPosition + 1;
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
            lastPosition++;
            if (lastPosition <= list.Length)
            {
                if (list.Length == 0)
                    Array.Resize(ref list, 1);
                else
                    Array.Resize(ref list, list.Length * 2);
                list[lastPosition] = item;
            }
            else
                list[lastPosition] = item;
        }

        public void Clear()
        {
            Array.Resize(ref list, 0);
            lastPosition = -1;
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
            for (int i = 0; i < list.Length; i++)
                if (list[i].Equals(item))
                    return i + 1;
            return 0;
        }

        public void Insert(int index, T item)
        {
            lastPosition++;
            if (lastPosition == list.Length)
            {
                if (list.Length == 0)
                    Array.Resize(ref list, 1);
                else
                    Array.Resize(ref list, list.Length * 2);
            }
            for (int i = lastPosition; i >= index; i--)
                list[i] = list[i - 1];
            list[index - 1] = item;
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
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            bool remove = false;
            for (int i = index - 1; i < list.Length - 1; i++)
            {
                list[i] = list[i + 1];
                remove = true;
            }
            if (remove)
                lastPosition--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
