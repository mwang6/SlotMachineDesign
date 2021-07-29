using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIInterview
{
    // play 3 rolls
    // 3 rolls random give numbers from 1-5
   
    public class SlotMachine
    {
        Random rnd = new Random();
        
        private static int roll1;
        private static int roll2;
        private static int roll3;

        private static int won;
        private static int coins;

        private static int maxPlay;
        //private static int totalScore;
        public SlotMachine()
        {
            coins = 3;
            maxPlay = 0;
        }


        // play - generate 3 number;
        // compare if same numbers
        // calculate conis;
        public int Play()
        {
            // before the roll check maxplay numbers reached 10
            // check the coins
           
            if(maxPlay == 10 || coins ==0)
            {
                //promote user end game;
                Console.WriteLine("You have finished game.");
            }
            else
            {
                // play the rolls
                // before roll
                Console.WriteLine("Before the play, your total coins are " + coins);
                int lastConis = coins;
                
                roll1 = rnd.Next(1, 5);
                roll2 = rnd.Next(1, 5);
                roll3 = rnd.Next(1, 5);
                // call method to get the coins
                coins = CalculateCoins(roll1, roll2, roll3, ref won);
                // play times +1
                maxPlay++;
                
                //after roll
                Console.WriteLine("The roll numbers are: " + roll1 + " " + roll2 + " " + roll3);
                //int won = coins - lastConis > 0 ? coins - lastConis : 0;
                Console.WriteLine("Won coins: " + won);
                coins--;
                Console.WriteLine("After this play, your total coins are: " + coins);
            }

            return coins;
            
        }

        private int CalculateCoins(int r1, int r2, int r3, ref int won)
        {
            // all three numbers are same
            // earn coins
            if (roll1 == roll2 && roll2 == roll3)
            {
                won = roll1 * 6;
                coins = coins + won;
            }
            // two of them are same
            else if (roll1 == roll2 || roll2 == roll3 || roll1 == roll3)
            {
                if(roll1 == roll2)
                {
                    won = roll1 * 2;

                    coins = coins + won;
                }
                else if(roll2 == roll3)
                {
                    won = roll2 * 2;

                    coins = coins + won;
                }
                else if (roll1 == roll3)
                {
                    won = roll1 * 2;

                    coins = coins + won;
                }

            }
            else
            {
                won = 0;
            }
            // cost one coin play
           

            return coins;
        }
       
    }
}
