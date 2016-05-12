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
        private int[] clientsOrder;

        public Service(Client[] clientsList)
        {
            this.clientsList = clientsList;
            clientsOrder = new int[clientsList.Length];
            SortPriorityList();
        }
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        private void SortPriorityList()
        {
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
        }
        public int GetNextCase(int position)
        {
            return clientsOrder[position];
        }
    }
}
