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
                
        private int coins;
        private int playRounds;
        public SlotMachine()
        {
            coins = 3;
            playRounds = 0;
        }

        // play - generate 3 number;
        // compare if same numbers
        // calculate conis;
        public bool Play()
        {          
            // check the coins         
            if(coins ==0 || playRounds == 10)
            {
                //promote user end game;
                Console.WriteLine("You have finished game.");
                return false;
            }
            else
            {
                //int lastConis = coins;
                // play the rolls
                // before roll
                Console.WriteLine("Before the play, your total coins are: " + coins);

                Dictionary<int, int> rolls = new Dictionary<int, int>();
                rolls.Add(0, rnd.Next(1, 6));
                rolls.Add(1, rnd.Next(1, 6));
                rolls.Add(2, rnd.Next(1, 6));

                // call method to get the coins
                int wonCoins = CalculateWon(rolls);
                // update coins for current round
                coins = CalculateCoins(wonCoins, coins);

                //after roll
                Console.WriteLine("The roll numbers are: " + rolls[0] + " " + rolls[1] + " " + rolls[2]);
                Console.WriteLine("Won coins: " + wonCoins);                
                Console.WriteLine("After this play, your total coins are: " + coins);

                Console.WriteLine("---------------------------------------------------------------");

                playRounds++;
                return true;
            }

            
            
        }

        private int CalculateWon(Dictionary<int,int> currentRoll)
        {
            // by defaul, roll value 0, no repeat numbers
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
                if(rollValue != 0)
                {
                    return rollValue * 2;
                }
                else
                {
                    //no repeat numbers, defaul 0
                    return rollValue;
                }

            }
            
        }

        private int CalculateCoins(int wonCoins, int currentCoins)
        {
            int totalCoins = currentCoins - 1 + wonCoins;
            return totalCoins;
        }

        private int FindRepeatNumber(int number, Dictionary<int,int> currentRoll)
        {
            // group dictionary where count == 2 or count ===3 return the first or default;
            var roll = currentRoll.GroupBy(r => r.Value).Where(c => c.Count() == number).FirstOrDefault();

            if (roll == null) return 0;
            
            return roll.Key;
        }
        
    }
}
