using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._12home
{
    class Matrix
    {
        private int[,] data;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            data = new int[rows, cols];
        }

        public int this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Matrices must have the same dimensions.");

            Matrix result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Matrices must have the same dimensions.");

            Matrix result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, int scalar)
        {
            Matrix result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result[i, j] = a[i, j] * scalar;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
                throw new ArgumentException("Number of columns in first matrix must be equal to the number of rows in the second matrix.");

            Matrix result = new Matrix(a.Rows, b.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    for (int k = 0; k < a.Cols; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public int Max()
        {
            int max = data[0, 0];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (data[i, j] > max)
                        max = data[i, j];
                }
            }
            return max;
        }

        public int Min()
        {
            int min = data[0, 0];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (data[i, j] < min)
                        min = data[i, j];
                }
            }
            return min;
        }

        public bool Equals(Matrix other)
        {
            if (other == null)
                return false;

            if (this.Rows != other.Rows || this.Cols != other.Cols)
                return false;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (this[i, j] != other[i, j])
                        return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix);
        }

        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        public void InputData()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"Enter element [{i},{j}]: ");
                    data[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Приклад
            Matrix matrix1 = new Matrix(2, 2);
            matrix1.InputData();
            Console.WriteLine("Matrix 1:");
            matrix1.Print();

            Matrix matrix2 = new Matrix(2, 2);
            matrix2.InputData();
            Console.WriteLine("Matrix 2:");
            matrix2.Print();

            Matrix sum = matrix1 + matrix2;
            Console.WriteLine("Sum:");
            sum.Print();

            Matrix difference = matrix1 - matrix2;
            Console.WriteLine("Difference:");
            difference.Print();

            Matrix product = matrix1 * matrix2;
            Console.WriteLine("Product:");
            product.Print();

            Console.WriteLine("Max of Matrix 1: " + matrix1.Max());
            Console.WriteLine("Min of Matrix 1: " + matrix1.Min());

            Console.WriteLine("Are Matrix 1 and Matrix 2 equal? " + matrix1.Equals(matrix2));
        }
    }
}
