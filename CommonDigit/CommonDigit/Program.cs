using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CommonDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            string userInput;
            int[] intArray;
            Dictionary<int, int> DigOccDict = new Dictionary<int, int>();

            Console.WriteLine("Provide number of integers that you want to check:");
            userInput = Console.ReadLine();
            N = ToInt32(userInput);
            intArray = new int[N];

            if (N >= 2 && N <= 20 )
            {
                    Console.WriteLine("Please provide N numbers, accordingly to the input above. Put spaces in between.");
                    userInput = Console.ReadLine();
                    intArray = StringConvertToSortedArr(userInput);
            }
            else
            {
                Console.WriteLine("N has to be in range of 2-20.");
            }

            if (intArray.Length == N)
            {
                string result = string.Join("", intArray);
                int resultNumber = int.Parse(result);
                int commonDigit = MaxOccurring(resultNumber);
                Console.WriteLine(commonDigit);
            }
            else
            {
                Console.WriteLine("Amount of numbers has to match the N value.");
            }
            Console.ReadKey();

        }

        // Method which changes string into int32. 
        private static int ToInt32(string value)
        {
            if (value == null)
                return 0;
            return Int32.Parse(value, CultureInfo.CurrentCulture);
        }

        // Method which turns string into a sorted array.
        private static int[] StringConvertToSortedArr(string s)
        {
            string[] StringArray = s.Split(' ');
            int[] asIntegers = StringArray.Select(token => int.Parse(token)).ToArray();
            Array.Sort(asIntegers);
            return asIntegers;
        }

        // Method which counts occurences of particular elements. 
        static int CountOccurrences(int x, int d)
        {
            int count = 0;

            while (x > 0)
            {
                if (x % 10 == d)
                    count++;
                x = x / 10;
            }
            return count;
        }

        // Method which returns most occuring int element.
        static int MaxOccurring(int x)
        {
            if (x < 0)
                x = -x;

            int result = 0;
            int max_count = 1;

            for (int d = 0; d <= 9; d++)
            {
                int count = CountOccurrences(x, d);

                if (count >= max_count)
                {
                    max_count = count;
                    result = d;
                }
            }
            return result;
        }
    }
}

// I would recommend switching integers to another type (like 'long' for example), but I've kept the variable types accordingly to the task requirements. 
