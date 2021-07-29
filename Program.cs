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
            // cannot continue the game when return flase
            // either coins 0 or rounds max to 10
            while (isPlay)
            {
                isPlay = slot.Play();
            }
            
            Console.ReadKey();
        }
       
    }
}
