namespace AdventOfCode2017
{
    class Day01
    {
        public static int FindSumOfSequentialDigits(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (char.GetNumericValue(input[i]) == char.GetNumericValue(input[i + 1]))
                    sum += (int)char.GetNumericValue(input[i]);
            }
            if (char.GetNumericValue(input[input.Length - 1]) == char.GetNumericValue(input[0]))
                sum += (int)char.GetNumericValue(input[input.Length - 1]);
            return sum;
        }

        public static int FindSumOfMatchingDigits(string input)
        {
            int length = input.Length;
            int steps = input.Length / 2;
            input = input + input;
            int sum = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (char.GetNumericValue(input[i]) == char.GetNumericValue(input[i + steps]))
                    sum += (int)char.GetNumericValue(input[i]);
            }
            return sum;
        }
    }
}
