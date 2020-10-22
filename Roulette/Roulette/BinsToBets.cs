using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Roulette
{
    public class BinsToBets
    {
        //I worked with Melinda on this and she helped with some of it.
        //need to figure out if bin is even or odd
        public static string EvenOrOdd(int whichBin)
        {
            if (whichBin % 2 == 0)
            {
                return "Even";
            }
            else return "Odd";
        }

        // need to figure out if it's red or black
        public static int[] redNumbers = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        // all the other numbers would return "black"

        // need to return whether it's red or black now
        public static string RedOrBlack(int whichBin)
        {
            if (redNumbers.Contains(whichBin))
            {
                return "Red";
            }
            else return "Black";
        }

        // need to figure out if low or high
        public static string LowOrHigh(int whichBin)
        {
            if (whichBin <= 18)
            {
                return "Low";
            }
            else return "High";
        }

        // need to figure out which dozen bin 
        public static string WhichDozen(int whichBin)
        {
            if (whichBin <= 12)
            {
                return "1st Dozen";
            }
            else if (whichBin > 24)
            {
                return "3rd Dozen";
            }
            else return "2nd Dozen";
        }

        // assign numbers to the right column
        public static string FirstColumn = "First Column";
        public static string SecondColumn = "Second Column";
        public static string ThirdColumn = "Third Column";
        public static string Column(int whichBin)
        {
            // use modulus to separate all numbers into three columns
            if (whichBin % 3 == 0) { return ThirdColumn; }
            if (whichBin % 3 == 2) { return SecondColumn; }
            else return FirstColumn;
        }

        // figure out which street
        public static int streetBin1;
        public static int streetBin2;
        public static int streetBin3;

        public static void Street(int whichBin)
        {
            if (Column(whichBin) == FirstColumn)
            {
                streetBin1 = whichBin;
                streetBin2 = whichBin + 1;
                streetBin3 = whichBin + 2;
            }

            if (Column(whichBin) == SecondColumn)
            {
                streetBin1 = whichBin - 1;
                streetBin2 = whichBin;
                streetBin3 = whichBin + 1;
            }

            else
            {
                streetBin1 = whichBin - 2;
                streetBin2 = whichBin - 1;
                streetBin3 = whichBin;
            }

            Console.WriteLine($"Street: {streetBin1}, {streetBin2}, {streetBin3}");
        }

        // figure out the double rows that win
        // Create a multidimensional array to iterate through for final tests
        public static int[,] Board = new int[12, 3]
        {
            {1, 2, 3 }
            ,{4, 5, 6 }
            ,{7, 8, 9 }
            ,{10, 11, 12}
            ,{13, 14, 15}
            ,{16, 17, 18}
            ,{19, 20, 21}
            ,{22, 23, 24 }
            ,{25, 26, 27}
            ,{28, 29, 30}
            ,{31, 32, 33}
            ,{34, 35, 36}
        };


        public static string WhichDouble(int whichBin)
        {
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (whichBin == Board[i, j] )
                    {
                        if (i == 0)
                        {
                            return $"Winning bets are contained in rows 1 and 2";
                        }
                        else if (i == 11)
                        {
                            return $"Winning bets are contained in rows 11 and 12";
                        }
                        else return $"Winning bets are contained in double rows {i + 1} and {i} or {i + 1} and {i + 2}";
                    }
                }
            }
            return "Make sure you keep playing.";
        }

        public static string WhichSplit(int whichBin)
        {
            // going to initialize a bin number now and reassign it to the winning number inside the loop
            int binNumber = whichBin;
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //binNumber = (3 * i) + j + 1;
                    if (binNumber == Board[i, j])
                    {
                        if (j == 0)
                        {
                            if (i == 0)
                            {
                                return $"Winning splits are {binNumber}/{binNumber+1}, and {binNumber}/{binNumber+3}";
                            }
                            else if (i == 11)
                            {
                                return $"Winning splits are {binNumber}/{binNumber + 1}, and {binNumber}/{binNumber -3}";
                            }
                            else return $"Winning splits are {binNumber}/{binNumber + 1}, {binNumber}/{binNumber -3}, and {binNumber}/{binNumber + 3}";
                        }
                        else if (j == 2)
                        {
                            if (i == 0)
                            {
                                return $"Winning splits are {binNumber}/{binNumber - 1}, and {binNumber}/{binNumber + 3}";
                            }
                            else if (i == 11)
                            {
                                return $"Winning splits are {binNumber}/{binNumber - 1}, and {binNumber}/{binNumber - 3}";
                            }
                            else return $"Winning splits are {binNumber}/{binNumber - 1}, {binNumber}/{binNumber - 3}, and {binNumber}/{binNumber + 3}";
                        }
                        else return $"Winning splits are {binNumber}/{binNumber - 1}, {binNumber}/{binNumber + 1}, {binNumber}/{binNumber - 3}, and {binNumber}/{binNumber + 3}";
                    }
                }
            }
            return "You picked a number. Check to see if it was a winning double bet.";
        }

        public static string WhichCorner(int whichBin)
        {
            int binNumber = whichBin;
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (binNumber == Board[i, j])
                    {
                        if (j == 0)
                        {
                            if (i == 0)
                            {
                                return $"Winning corner is 1/2/4/5.";
                            }
                            else if (i == 11)
                            {
                                return $"Winning corner is 31/32/34/35.";
                            }
                            else return $"Winning corners are {binNumber}/{binNumber + 1}/{binNumber + 3}/{binNumber + 4} and {binNumber - 3}/{binNumber - 2}/{binNumber}/{binNumber + 1}";
                        }
                        else if (j == 2)
                        {
                            if (i == 0)
                            {
                                return $"Winning corner is 2/3/5/6.";
                            }
                            else if (i == 11)
                            {
                                return $"Winning corner is 32/33/35/36.";
                            }
                            else return $"Winning corners are {binNumber - 4}/{binNumber - 3}/{binNumber - 1}/{binNumber} and {binNumber - 1}/{binNumber}/{binNumber + 2}/{binNumber + 3}";
                        }
                        else { 
                            if (i == 0)
                            {
                                return $"Winning corners are 1/2/4/5 and 2/3/5/6.";
                            }
                            else if (i == 11)
                            {
                                return $"Winning corners are 31/32/34/35 and 32/33/35/36.";
                            }
                            else return $"Winning corners are { binNumber}/{ binNumber + 1}/{ binNumber + 3}/{ binNumber + 4}, " +
                                    $"{ binNumber - 3}/{ binNumber - 2}/{ binNumber}/{ binNumber + 1}, " +
                                    $"{ binNumber - 4}/{ binNumber - 3}/{ binNumber - 1}/{ binNumber}, and " +
                                    $"{ binNumber - 1}/{ binNumber}/{ binNumber + 2}/{ binNumber + 3}";
                        }
                    }
                }
            }
            return "Thanks for playing roulette with Jason.";
        }
    }
}
