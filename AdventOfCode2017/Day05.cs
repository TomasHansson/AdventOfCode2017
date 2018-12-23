using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    class Day05
    {
        public static int NumberOfMovesToEscapse(List<int> instructions)
        {
            int currentPosition = 0;
            int numberOfMoves = 0;
            while (currentPosition >= 0 && currentPosition < instructions.Count())
            {
                currentPosition += instructions[currentPosition]++;
                numberOfMoves++;
            }
            return numberOfMoves;
        }

        public static int MovesToEscapseWithAddedRule(List<int> instructions)
        {
            int currentPosition = 0;
            int numberOfMoves = 0;
            while (currentPosition >= 0 && currentPosition < instructions.Count())
            {
                if (instructions[currentPosition] < 3)
                    currentPosition += instructions[currentPosition]++;
                else
                    currentPosition += instructions[currentPosition]--;
                numberOfMoves++;
            }
            return numberOfMoves;
        }
    }
}
