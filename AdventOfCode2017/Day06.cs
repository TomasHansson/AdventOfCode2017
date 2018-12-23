using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    class Day06
    {
        public static void CalulateCycles(int[] input, ref int numberOfCycles, ref int indexOfDuplication)
        {
            List<int[]> previousStates = new List<int[]>();
            previousStates.Add(input.ToArray());
            bool hasBeenSeen = false;
            while (!hasBeenSeen)
            {
                numberOfCycles++;
                int indexOfMax = Array.IndexOf(input, input.Max());
                int maxValue = input.Max();
                input[indexOfMax] = 0;
                indexOfMax++;
                while (maxValue > 0)
                {
                    if (indexOfMax == input.Length)
                        indexOfMax = 0;
                    input[indexOfMax++]++;
                    maxValue--;
                }
                hasBeenSeen = HasBeenSeen(previousStates, input, ref indexOfDuplication);
            }
        }

        static bool HasBeenSeen(List<int[]> previousStates, int[] currentState, ref int indexOfDuplication)
        {
            int currentArray = 0;
            foreach (int[] array in previousStates)
            {
                bool directCopy = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != currentState[i])
                        directCopy = false;
                }
                if (directCopy)
                {
                    indexOfDuplication = currentArray;
                    return true;
                }
                else
                    currentArray++;
            }
            previousStates.Add(currentState.ToArray());
            return false;
        }
    }
}
