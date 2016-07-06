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
                return false;
            }
        }

        public void Add(T item)
        {
            ResizeList();
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
            for (int i = 0; i < lastPosition; i++)
                array[i + arrayIndex] = list[i];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0; i<lastPosition++; i++)
                yield return list[i];
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
            CheckForArgumentException(index);
            ResizeList();
            for (int i = lastPosition; i >= index; i--)
                list[i] = list[i - 1];
            list[index - 1] = item;
        }

        private void CheckForArgumentException(int index)
        {
            if (index > lastPosition || index < 0)
                throw new ArgumentException();
        }

        public bool Remove(T item)
        {
            if(Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            CheckForArgumentException(index);
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
            return GetEnumerator();
        }
        private void ResizeList()
        {
            lastPosition++;
            if (lastPosition == list.Length)
            {
                if (list.Length == 0)
                    Array.Resize(ref list, 1);
                else
                    Array.Resize(ref list, list.Length * 2);
            }
        }
    }
}
