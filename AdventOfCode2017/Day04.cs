using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    class Day04
    {
        public static void FindValidPhrases(ref int numberOfValidPassphrases, ref int numberOfNonAnaghramPhrases)
        {
            using (StreamReader streamReader = new StreamReader(@"C:/Temp/input_2017_day4.txt"))
            {
                string row;
                while ((row = streamReader.ReadLine()) != null)
                {
                    string[] wordsInRow = row.Split(' ');
                    if (wordsInRow.Distinct().Count() == wordsInRow.Count())
                    {
                        numberOfValidPassphrases++;
                        for (int i = 0; i < wordsInRow.Length; i++)
                            wordsInRow[i] = SortString(wordsInRow[i]);
                        if (wordsInRow.Distinct().Count() == wordsInRow.Count())
                            numberOfNonAnaghramPhrases++;
                    }
                }
            }
        }

        public static string SortString(string input)
        {
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
