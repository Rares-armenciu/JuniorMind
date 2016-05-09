using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter
{
    class Service
    {
        private Client[] clientsList;
        
        public Service(Client[] clientsList)
        {
            this.clientsList = clientsList;
        }
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public int[] SortPriorityList()
        {
            int[] clientsOrder = new int[clientsList.Length];
            for (int i = 0; i < clientsList.Length; i++)
                clientsOrder[i] = i + 1;
            int counter = 0;
            do
            {
                counter = 0;
                for (int i = 0; i < clientsList.Length - 1; i++)
                {
                    if (!clientsList[i].ComparePriorities(clientsList[i + 1]))
                    {
                        Swap(ref clientsList[i], ref clientsList[i + 1]);
                        Swap(ref clientsOrder[i], ref clientsOrder[i + 1]);
                        counter++;
                    }
                }
            } while (counter != 0);
            return clientsOrder;
        }
    }
}
