using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    class Day02
    {
        public static void PopulateLists(List<int> rowDifferences, List<int> rowDivisions)
        {
            using (StreamReader streamReader = new StreamReader(@"C:/Temp/input_2017_day2.txt"))
            {
                string row;
                while ((row = streamReader.ReadLine()) != null)
                {
                    List<int> numbers = new List<int>();
                    string[] numbersInRow = Regex.Replace(row, @"\s+", " ").Split(' ');
                    foreach (string number in numbersInRow)
                        numbers.Add(Convert.ToInt32(number));
                    numbers.Sort();
                    rowDifferences.Add(Day02.FindLargestDifference(numbers));
                    rowDivisions.Add(Day02.FindEvenDivision(numbers));
                }
            }
        }

        public static int FindLargestDifference(List<int> numbers)
        {
            return numbers.Last() - numbers.First();
        }

        public static int FindEvenDivision(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i != j && numbers[i] % numbers[j] == 0)
                        return numbers[i] / numbers[j];
                }
            }
            return 0;
        }
    }
}
