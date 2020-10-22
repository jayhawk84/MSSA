using System;
using System.Security.Cryptography.X509Certificates;

namespace Roulette
{
    class Program
    {
        public static int whichBin = WheelBins.SpinTheWheel();
        public static void doStuff()
        {
            BetHelper.CalculateAndWriteWinningBets(whichBin);
        }
        static void Main(string[] args)
        {
            doStuff();
        }
    }
}
