using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter
{
    class RepairOrder
    {
        private string[] repairPriorities;
        private int[] caseNumber = new int[0];
        private int[] prioritiesNumber = new int[0];
        public RepairOrder(string[] priorities)
        {
            repairPriorities = priorities;
            for (int i = 0; i < repairPriorities.Length; i++)
            {
                Array.Resize(ref caseNumber, caseNumber.Length + 1);
                caseNumber[i] = i+1;
                switch (repairPriorities[i])
                {
                    case "Low":
                        Array.Resize(ref prioritiesNumber, prioritiesNumber.Length + 1);
                        prioritiesNumber[i] = 1;
                        break;
                    case "Medium":
                        Array.Resize(ref prioritiesNumber, prioritiesNumber.Length + 1);
                        prioritiesNumber[i] = 2;
                        break;
                    case "High":
                        Array.Resize(ref prioritiesNumber, prioritiesNumber.Length + 1);
                        prioritiesNumber[i] = 3;
                        break;
                }
            }
        }
        public int[] SortPriorities()
        {
            int element, position, number;
            for(int i=1; i<prioritiesNumber.Length; i++)
            {
                element = prioritiesNumber[i];
                number = caseNumber[i];
                position = i;
                while(position>0 && prioritiesNumber[position-1]<element)
                {
                    prioritiesNumber[position] = prioritiesNumber[position - 1];
                    caseNumber[position] = caseNumber[position - 1];
                    position = position - 1;
                }
                prioritiesNumber[position] = element;
                caseNumber[position] = number;
            }
            return caseNumber;


        }
    }
}
