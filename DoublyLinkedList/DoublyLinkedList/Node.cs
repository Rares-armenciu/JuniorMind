using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Node<T>
    {
        public T data;
        public Node<T> previousNode;
        public Node<T> nextNode;

        public Node(T data)
        {
            this.data = data;
        }
    }
}
