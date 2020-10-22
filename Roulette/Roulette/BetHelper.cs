using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public static class BetHelper
    {
        public static void CalculateAndWriteWinningBets(int whichBin)
        {
            if (whichBin != 0 && whichBin != 37)
            {
                CheckAndWriteWinningBets(whichBin);
            }
            else if (whichBin == 37)
            {
                Console.WriteLine("00");
                Console.WriteLine("Better luck next time!");
            }
            else
            {
                Console.WriteLine("0");
                Console.WriteLine("Better luck next time!");
            }
        }

        public static void CheckAndWriteWinningBets(int whichBin)
        {
            Console.WriteLine($"The winning bin Number is {whichBin}\nOther winning bets would be:");
            Console.WriteLine(BinsToBets.EvenOrOdd(whichBin));
            Console.WriteLine(BinsToBets.RedOrBlack(whichBin));
            Console.WriteLine(BinsToBets.LowOrHigh(whichBin));
            Console.WriteLine(BinsToBets.WhichDozen(whichBin));
            Console.WriteLine(BinsToBets.Column(whichBin));
            BinsToBets.Street(whichBin);
            Console.WriteLine(BinsToBets.WhichDouble(whichBin));
            Console.WriteLine(BinsToBets.WhichSplit(whichBin));
            Console.WriteLine(BinsToBets.WhichCorner(whichBin));
        }
    }
}
