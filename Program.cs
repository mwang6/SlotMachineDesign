using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            SlotMachine slot = new SlotMachine();
            for(int i=0; i<10; i++)
            {
                int coins = slot.Play();
                if (coins == 0) break;
            }

            Console.ReadKey();
        }
    }
}
