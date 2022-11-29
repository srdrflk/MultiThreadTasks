/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<int[]> taskA = Task.Run(() => CreateIntArray());

            taskA.ContinueWith(arr => MultiplyArray(arr.Result))
                .ContinueWith(arr => SortArray(arr.Result))
                .ContinueWith(arr => Console.WriteLine("Average is : " + CalculateAverage(arr.Result)));

            Console.ReadLine();
        }

        public static int[] CreateIntArray()
        {
            Random random = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }
            return array;
        }

        public static int[] MultiplyArray(int[] array)
        {
            int[] newArray = CreateIntArray();
            array = array.Concat(newArray).ToArray();
            return array;
        }

        public static int[] SortArray(int[] array)
        {
            var sortedArray = array.OrderBy(x => x).ToArray();
            return sortedArray;
        }

        public static int CalculateAverage(int[] array)
        {
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total += array[i];
            }
            return total / array.Length;
        }
    }
}
