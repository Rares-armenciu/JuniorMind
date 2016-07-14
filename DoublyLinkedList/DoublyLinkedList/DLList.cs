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
        static Node<T> temp;
        static Node<T> current;

        public int Count
        {
            get
            {
                return nodesCount;
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
            Node<T> node = new Node<T>(item);
            if(root == null)
            {
                root = node;
                root.previousNode = null;
                root.nextNode = null;
                nodesCount++;
            }
            else
            {
                current = root;
                while(current.nextNode != null)
                    current = current.nextNode;
                node.previousNode = current;
                node.nextNode = null;
                current.nextNode = node;
            }
        }
        public void AddLast(T item)
        {

        }
        public void AddFirst(T item)
        {

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
