using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._01home
{
    class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1
            Console.WriteLine("Завдання 1:");
            DrawDelegate squareDelegate = DrawSquare;
            DrawDelegate triangleDelegate = DrawTriangle;

            squareDelegate(5, ConsoleColor.Green, '*');
            triangleDelegate(5, ConsoleColor.Blue, '*');

            DrawDelegate multiDelegate = DrawSquare;
            multiDelegate += DrawTriangle;

            Console.WriteLine("\nМультиделегат:");
            multiDelegate(5, ConsoleColor.Yellow, '*');

            // Завдання 2
            Console.WriteLine("\nЗавдання 2:");
            Calculator calculator = new Calculator();
            calculator.SetOperation(Operation.Plus);
            Console.WriteLine($"5 + 3 = {calculator.Calculate(5, 3)}");

            calculator.SetOperation(Operation.Minus);
            Console.WriteLine($"5 - 3 = {calculator.Calculate(5, 3)}");

            // Завдання 3
            Console.WriteLine("\nЗавдання 3:");

            string[] strings = { "aaa", "bb", "cccccc", "d" };
            Sort(strings, (x, y) => x.Length.CompareTo(y.Length));
            Console.WriteLine("Відсортований масив рядків за зростанням довжин:");
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }

            Product[] products = {
                new Product("Product1", 15),
                new Product("Product2", 5),
                new Product("Product3", 10)
            };
            Sort(products, (x, y) => x.Price.CompareTo(y.Price));
            Console.WriteLine("\nВідсортований масив продуктів за ціною:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        // Завдання 1
        delegate void DrawDelegate(uint height, ConsoleColor color, char symbol);

        static void DrawSquare(uint height, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void DrawTriangle(uint height, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;
            for (int i = 1; i <= height; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        // Завдання 2
        enum Operation { Plus, Minus }

        class Calculator
        {
            Func<double, double, double> func;

            public void SetOperation(Operation op)
            {
                if (op == Operation.Plus)
                    func = (x, y) => x + y;
                else if (op == Operation.Minus)
                    func = (x, y) => x - y;
            }

            public double Calculate(double one, double two)
            {
                return func(one, two);
            }
        }

        // Завдання 3
        static void Sort<T>(T[] arr, Comparison<T> comp)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (comp(arr[j], arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public Product(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Name}: {Price}";
            }
        }
    }
}
