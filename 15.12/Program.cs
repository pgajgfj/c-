using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._12
{
    internal class Program
    {
        static void FillRandom(int[][] matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = rand.Next(1, 100); 
                }
            }
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                foreach (int num in row)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ShiftRowsUp(int[][] matrix, int rowsToShift)
        {
            for (int i = 0; i < rowsToShift; i++)
            {
                int[] temp = matrix[0];
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    matrix[j] = matrix[j + 1];
                }
                matrix[matrix.Length - 1] = temp;
            }
        }

        static void AddRow(ref int[][] matrix, int[] newRow)
        {
            Array.Resize(ref matrix, matrix.Length + 1);
            matrix[matrix.Length - 1] = newRow;
        }

        static void RemoveRow(ref int[][] matrix, int index)
        {
            if (index >= 0 && index < matrix.Length)
            {
                for (int i = index; i < matrix.Length - 1; i++)
                {
                    matrix[i] = matrix[i + 1];
                }
                Array.Resize(ref matrix, matrix.Length - 1);
            }
        }
        static void FillArray(int[,,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rand.Next(1, 100); 
                    }
                }
            }
        }

        static void PrintArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static void CalculateSubarraySums(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        sum += array[i, j, k];
                    }
                }
                Console.WriteLine($"Сума елементів підмасиву {i + 1}: {sum}");
            }
        }
        static void FindMinMax(int[][] matrix, out int min, out int max)
        {
            min = int.MaxValue;
            max = int.MinValue;
            foreach (int[] row in matrix)
            {
                foreach (int num in row)
                {
                    if (num < min)
                        min = num;
                    if (num > max)
                        max = num;
                }
            }
        }
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 4, 5, 6 };
            matrix[2] = new int[] { 7, 8, 9 };

            FillRandom(matrix);
            PrintMatrix(matrix);
            ShiftRowsUp(matrix, 1);
            PrintMatrix(matrix);
            
            int[] newRow = new int[] { 10, 11, 12 };
            AddRow(ref matrix, newRow);
            PrintMatrix(matrix);
            
            RemoveRow(ref matrix, 1);
            PrintMatrix(matrix);

            int[,,] threeDimensionalArray = new int[3, 3, 3]; 
            FillArray(threeDimensionalArray);
            PrintArray(threeDimensionalArray);
            CalculateSubarraySums(threeDimensionalArray);
        }
    }
}
