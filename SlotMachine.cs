using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIInterview
{
    /*
     * Slot Machine Game
     * Game intially assigns 3 coins
     * The game randomly generates 3 rolls (numbers) for each round
     * Game has total 10 rounds
     * 
     * If all 3 rolls are equals - won is roll*6 coins
     * If 2 of the rolls are equals - won is roll*2 coins
     * If none of them are equals - won is 0 coin
     * Each round costs 1 coin
     * 
     * ************ Output **************
     * Display conis before the play round
     * Display generated 3 rolls
     * Display won coins
     * Display coins after the play round
     *    
     */

    public class SlotMachine
    {
        Random rnd = new Random();
                
        private int coins;
        private int playRounds;
        public SlotMachine()
        {
            coins = 3;
            playRounds = 0;
        }

        /*
        * @param 
        * @return true - if continue play
        *         false - reach the max 10 rounds or 0 coins left
        */
        public bool Play()
        {          
            // check the coins         
            if(coins ==0 || playRounds == 10)
            {
                Console.WriteLine("You have finished game.");
                return false;
            }
            else
            {               
                Console.WriteLine("Before the play, your total coins are: " + coins);

                Dictionary<int, int> rolls = new Dictionary<int, int>();
                rolls.Add(0, rnd.Next(1, 6));
                rolls.Add(1, rnd.Next(1, 6));
                rolls.Add(2, rnd.Next(1, 6));

                // get the won coins
                int wonCoins = CalculateWon(rolls);
                // update coins - total coins after this play round
                coins = CalculateCoins(wonCoins, coins);

                //after play rounds output 
                Console.WriteLine("The roll numbers are: " + rolls[0] + " " + rolls[1] + " " + rolls[2]);
                Console.WriteLine("Won coins: " + wonCoins);                
                Console.WriteLine("After this play, your total coins are: " + coins);

                Console.WriteLine("---------------------------------------------------------------");

                playRounds++;
                return true;
            }
            
        }

        /*
        * @param currentRoll - current 3 rolls (random numbers saved in Dictionary)
        * @return won coins     
        */
        private int CalculateWon(Dictionary<int,int> currentRoll)
        {
            // by default, roll value 0, no repeat numbers
            int rollValue = 0;

            // find duplicated values from current three rolls dictionary            
            // looking for 3 repeat numbers first
            rollValue = FindRepeatNumber(3, currentRoll);
            if(rollValue != 0)
            {                
                return rollValue * 6;
            }
            // else no three numbers are same, check if two numbers
            else
            {
                // looking for 2 same numbers
                rollValue = FindRepeatNumber(2, currentRoll);
                // if 2 numbers are equal
                if(rollValue != 0)
                {
                    return rollValue * 2;
                }
                else
                {
                    //no repeat numbers, return default 0
                    return rollValue;
                }

            }
            
        }

        /*
         * @param   wonCoins - won coins from this play round
         * @param   currentRoll - coins before this play round
         * @return  totalCoins - coins after this play round
         */
        private int CalculateCoins(int wonCoins, int currentCoins)
        {
            int totalCoins = currentCoins - 1 + wonCoins;
            return totalCoins;
        }

        /*
         * @param   number - possible repeat numbers
         * @param   currentRoll - current 3 rolls (random numbers saved in Dictionary)
         * @return  duplicated number or 0 is no duplicated
         */
        private int FindRepeatNumber(int number, Dictionary<int,int> currentRoll)
        {
            // group dictionary where count == 2 or count ===3 return the first or default;
            var roll = currentRoll.GroupBy(r => r.Value).Where(c => c.Count() == number).FirstOrDefault();

            if (roll == null) return 0;
            
            return roll.Key;
        }
        
    }
}
