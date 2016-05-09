using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Priority
{
    Low = 1,
    Medium = 2,
    High = 3
}
namespace ServiceCenter
{
    class Client
    {
        private Priority repairPriority;
        public Client(Priority repairPriority)
        {
            this.repairPriority = repairPriority;
        }
        public bool ComparePriorities(Client nextClient)
        {
            return repairPriority >= nextClient.repairPriority;
        }
    }
}
