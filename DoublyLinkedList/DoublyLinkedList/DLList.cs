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
        static Node<T> root;
        static Node<T> current;

        public int Count
        {
            get
            {
                return nodesCount;
            }
        }

        public bool IsEmpty()
        {
            return (nodesCount == 0);
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
            if (root == null)
            {
                root = new Node<T>(null, item, null);
            }
            else
            {
                current = root;
                while (current.nextNode != null)
                    current = current.nextNode;
                Node<T> node = new Node<T>(current, item, null);
                current.nextNode = node;
            }
            nodesCount++;
        }
        public void AddFirst(T item)
        {
            if (root == null)
            {
                root = new Node<T>(null, item, null);
            }
            else
            {
                Node<T> node = new Node<T>(null, item, root);
                root.previousNode = node;
                root = node;
            }
            nodesCount++;
        }

        public void Clear()
        {
            root = null;
            nodesCount = 0;
        }

        public bool Contains(T item)
        {
            if (root == null)
                return false;
            else
            {
                current = root;
                while(current.nextNode != null)
                {
                    current = current.nextNode;
                    if (current.data.Equals(item))
                        return true;
                }
            }
            return root.data.Equals(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            current = root;
            while(current != null)
            {
                yield return current.data;
                current = current.nextNode;
            }
        }
        public bool Remove(T item)
        {
            if (Contains(item))
            {
                nodesCount--;
                current = root;
                if (current.data.Equals(item))
                {

                    current.nextNode.previousNode = null;
                    root = current.nextNode;
                    return true;
                }
                while (current.nextNode != null && !current.data.Equals(item))
                {
                    current = current.nextNode;
                }
                current.previousNode.nextNode = current.nextNode;
                if (current.nextNode == null)
                    return true;
                else
                {
                    current.nextNode.previousNode = current.previousNode;
                    return true;
                }
                

            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
