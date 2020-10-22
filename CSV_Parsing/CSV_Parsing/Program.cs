using System;
using System.Collections.Generic;

namespace CSV_Parsing
{
    class Program
    {
        static List<string> getCSV(string givenList)
        {
            List<string> result = new List<string>();
            string[] words = givenList.Split("\"");
            string temp = "";

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                for (int j = 0; j < word.Length; j++)
                {
                    if (j > 0 && word[j] == ',' && word[j - 1] == 'N')
                    {
                        result.Add(temp);
                        temp = "";
                        j++;
                    }

                    if (j == 0 && word[j] == ',' || j == word.Length - 1 && word[j] == ',') temp = temp;
                    else temp += word[j];
                }

                if (temp != "") result.Add(temp);
                temp = "";
            }
            return result;
        }

        static void Main(string[] args)
        {
            /*************************
            * read CSV with embedded commas
            * parse CSV into separate fields and
            * ignore commas within quoted string
            * ***********************/
            Console.WriteLine("Reading CSV with embedded commas");
            List<string> myList = new List<string>();
            string input1 = "\"a,b\",c";
            myList.Add(input1);
            string input2 = "\"Obama, Barack\",\"August 4, 1961\",\"Washington, D.C.\"";
            myList.Add(input2);
            string input3 = "\"Ft. Benning, Georgia\",32.3632N,84.9493W," +
            "\"Ft. Stewart, Georgia\",31.8691N,81.6090W," +
            "\"Ft. Gordon, Georgia\",33.4302N,82.1267W";
            myList.Add(input3);
            foreach (string s in myList)
            {
                Console.WriteLine($"Current input is {s}");
                List<string> output = getCSV(s);
                int len = output.Count;
                Console.WriteLine($"This line has {len} fields. They are:");
                foreach (string s1 in output)
                    Console.WriteLine(s1);
            }
        }
    }
}
