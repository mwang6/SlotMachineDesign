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
            bool isPlay = true;           
            while (isPlay)
            {
                isPlay = slot.Play();
                // jump out the loop when return flase
            }

            Console.ReadKey();
        }
       
    }
}
