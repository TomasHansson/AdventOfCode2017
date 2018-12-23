using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 01
            string inputDay01;
            using (StreamReader streamReader = new StreamReader(@"C:/Temp/input_2017_day1.txt"))
                inputDay01 = streamReader.ReadLine();
            Console.WriteLine("The total sum of digits matching the following digit is: " + Day01.FindSumOfSequentialDigits(inputDay01));
            Console.WriteLine("The total sum of digits matching the number halfway through the list is: " + Day01.FindSumOfMatchingDigits(inputDay01));
            Console.WriteLine();

            // Day 02
            List<int> rowDifferences = new List<int>();
            List<int> rowDivisions = new List<int>();
            Day02.PopulateLists(rowDifferences, rowDivisions);
            Console.WriteLine("The checksum is: " + rowDifferences.Sum());
            Console.WriteLine("The sum of all even divisions is: " + rowDivisions.Sum());
            Console.WriteLine();

            // Day 03
            int inputDay03 = 361527;
            Console.WriteLine("The distance between the first and last point is: " + Day03.FindDistance(inputDay03));
            Console.WriteLine("The first number that is larger than the input is: " + Day03.FindFirstLarger(inputDay03));
            Console.WriteLine();

            // Day 04
            int numberOfValidPassphrases = 0;
            int numberOfNonAnaghramPhrases = 0;
            Day04.FindValidPhrases(ref numberOfValidPassphrases, ref numberOfNonAnaghramPhrases);
            Console.WriteLine("The number of valid passphrases is: " + numberOfValidPassphrases);
            Console.WriteLine("The number of valid passphrases without anaghrams is: " + numberOfNonAnaghramPhrases);
            Console.WriteLine();

            // Day 05
            List<int> listOfInstructions = new List<int>();
            using (StreamReader streamReader = new StreamReader(@"C:/Temp/input_2017_day5.txt"))
            {
                string row;
                while ((row = streamReader.ReadLine()) != null)
                    listOfInstructions.Add(Convert.ToInt32(row));
            }
            Console.WriteLine("Number of moves to escape (Part 1): " + Day05.NumberOfMovesToEscapse(new List<int>(listOfInstructions)));
            Console.WriteLine("Number of moves to escape (Part 2): " + Day05.MovesToEscapseWithAddedRule(listOfInstructions));
            Console.WriteLine();

            // Day 06
            int[] input = { 10, 3, 15, 10, 5, 15, 5, 15, 9, 2, 5, 8, 5, 2, 3, 6 };
            int numberOfCycles = 0;
            int indexOfDuplication = 0;
            Day06.CalulateCycles(input, ref numberOfCycles, ref indexOfDuplication);
            Console.WriteLine("The numbers of cycles that ran before a duplication was seen: " + numberOfCycles);
            Console.WriteLine("The numbers of loops between the duplications was: " + (numberOfCycles - indexOfDuplication));
            Console.WriteLine();

            // Day 07 (Only Part 1 as of now)
            string nameOfRootNode = Day07.FindNameOfRootNode();
            Console.WriteLine("The name of the bottom program is: " + nameOfRootNode);
            Console.WriteLine();
        }
    }
}
