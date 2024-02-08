using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._12home
{
    internal class Program
    {
        //метод для 1 
        static int[] CreateArr(int size)
        {
            int[] arr = new int[size];
            FillRandArr(arr);
            return arr;
        }

        static void FillRandArr(int[] arr, int left = 0, int right = 100)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(left, right + 1);
            }
        }

        static void PrintArray(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static void SwapElements(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                Swap(ref arr[i], ref arr[i + 1]);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int GetFirstPositive(int[] arr)
        {
            return Array.Find(arr, x => x > 0);
        }

        static int CountEvenElements(int[] arr)
        {
            return arr.Count(x => x % 2 == 0);
        }

        static int IndexOfMultipleOf7(int[] arr)
        {
            return Array.FindIndex(arr, x => x % 7 == 0);
        }

        // метод для  2
        static void RearrangeElements(int[] arr)
        {
            int[] negativeElements = Array.FindAll(arr, x => x < 0);
            int[] nonNegativeElements = arr.Except(negativeElements).ToArray();
            Array.Copy(negativeElements, arr, negativeElements.Length);
            Array.Copy(nonNegativeElements, 0, arr, negativeElements.Length, nonNegativeElements.Length);
        }

        // метод для 3
        static int CountOccurrences(int[] arr, int number)
        {
            return arr.Count(x => x == number);
        }
        static void Main(string[] args)
        {
            int size = 10; 

            int[] array = CreateArr(size);
            Console.WriteLine("Original Array:");
            PrintArray(array);

            // Вправа  1
            SwapElements(array);
            Console.WriteLine("Array after swapping elements:");
            PrintArray(array);

            int firstPositive = GetFirstPositive(array);
            Console.WriteLine($"First positive element in the array: {firstPositive}");

            int countEven = CountEvenElements(array);
            Console.WriteLine($"Number of even elements in the array: {countEven}");

            int indexMultipleOf7 = IndexOfMultipleOf7(array);
            Console.WriteLine($"Index of the first element multiple of 7: {indexMultipleOf7}");

            // Вправа 2
            Console.WriteLine("\nRearranging elements (negative first, non-negative last):");
            RearrangeElements(array);
            PrintArray(array);

            // Вправа 3
            Console.WriteLine("\nEnter a number to search in the array:");
            int searchNumber = int.Parse(Console.ReadLine());
            int occurrences = CountOccurrences(array, searchNumber);
            Console.WriteLine($"Number of occurrences of {searchNumber} in the array: {occurrences}");
        }
    }
}
