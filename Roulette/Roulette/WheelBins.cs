using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Roulette
{
    public class WheelBins
    {
        public static int SpinTheWheel()
        {
            Random randomSpin = new Random();
            return randomSpin.Next(0, 38);
        }
    }
}
