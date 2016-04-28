using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryDraw
{
    public partial class BubbleSort : Component
    {
        private int[] numbersToSort;
        public BubbleSort(int[] numberList)
        {
            numbersToSort = numberList;
        }
        
        public int[] SortNumbers()
        {
            bool swap = true;
            int auxiliary;
            while(swap==true)
            {
                swap = false;
                for (int i = 0; i < numbersToSort.Length - 1; i++)
                    if (numbersToSort[i] > numbersToSort[i + 1])
                    {
                        auxiliary = numbersToSort[i];
                        numbersToSort[i] = numbersToSort[i + 1];
                        numbersToSort[i + 1] = auxiliary;
                        swap = true;
                    }
            }
            return numbersToSort;
            
        }
    }
}
