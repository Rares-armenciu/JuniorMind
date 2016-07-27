using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class DLList<T> : ICollection<T> , IEnumerable<T>
    {
        public int nodesCount = 0;
        Node<T> current;
        Node<T> sentinel = new Node<T>();



        public int Count
        {
            get
            {
                int count = 0;
                current = sentinel;
                while(current.nextNode!= sentinel)
                {
                    current = current.nextNode;
                    count++;
                }
                return count;
            }
        }

        public bool IsEmpty()
        {
            return (sentinel.nextNode.Equals(sentinel) && sentinel.previousNode.Equals(sentinel));
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
            AddLast(item);
        }
        public void AddLast(T item)
        {
            current = new Node<T>(sentinel.previousNode, item, sentinel);
            sentinel.previousNode.nextNode = current;
            sentinel.previousNode = current;
            nodesCount++;
        }
        public void AddFirst(T item)
        {
            current = new Node<T>(sentinel, item, sentinel.nextNode);
            sentinel.nextNode.previousNode = current;
            sentinel.nextNode = current;
            nodesCount++;
        }

        public void Clear()
        {
            sentinel.nextNode = sentinel;
            sentinel.previousNode = sentinel;

        }

        public bool Contains(T item)
        {
            if (nodesCount == 0)
                return false;
            else
            {
                current = sentinel;
                while(current.nextNode != sentinel)
                {
                    current = current.nextNode;
                    if (current.data.Equals(item))
                        return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            current = sentinel;
            while(current.nextNode != sentinel)
            {
                current = current.nextNode;
                yield return current.data;
            }
        }
        public bool Remove(T item)
        {
            if (Contains(item))
            {
                current = sentinel;
                while (current.nextNode != sentinel)
                {
                    current = current.nextNode;
                    if (current.data.Equals(item))
                    {
                        current.previousNode.nextNode = current.nextNode;
                        current.nextNode.previousNode = current.previousNode;
                        return true;
                    }
                }
                nodesCount--;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
