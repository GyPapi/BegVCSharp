﻿using System;
using System.Collections.Generic;
// Diagnostics need to be included to use Debug and Trace functions.
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch07Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9 };
            int[] maxValIndices;
            int maxVal = Maxima(testArray, out maxValIndices);

            WriteLine($"Maximum value {maxVal} found at element indices:");
            foreach (int index in maxValIndices)
            {
                WriteLine(index);
            }
            ReadKey();
        }

        static int Maxima(int[] integers, out int[] indices)
        {
            Debug.WriteLine("Maximum value search started.");
            indices = new int[1];
            int maxVal = integers[0];
            indices[0] = 0;
            int count = 1;
            // Debug.WriteLine() only accepts a string, and an optional category, so it doesn't
            // allow you to insert variables in the string using the {} syntax like we do with
            // the Console.WriteLine(). We're using the string class to do that, then pass its
            // output to the WriteLine().
            Debug.WriteLine(string.Format($"Maximum value initialized to {maxVal}, at element index 0."));

            for (int i = 1; i < integers.Length; i++)
            {
                Debug.WriteLine(string.Format($"Now looking at element at index {i}."));
                if (integers[i] > maxVal)
                {
                    maxVal = integers[i];
                    count = 1;
                    indices = new int[1];
                    indices[0] = i;
                    Debug.WriteLine(string.Format($"New maximum found. New value is {maxVal}, at element index {i}."));
                }
                else if (integers[i] == maxVal)
                {
                    count++;
                    int[] oldIndices = indices;
                    indices = new int[count];
                    oldIndices.CopyTo(indices, 0);
                    indices[count - 1] = i;
                    Debug.WriteLine(string.Format($"Duplicate maximum found at element index {i}."));
                }
            }

            Trace.WriteLine(string.Format($"Maximum value {maxVal} found, with {count} occurrences."));
            Debug.WriteLine("Maximum value search completed.");

            return maxVal;
        }
    }
}
