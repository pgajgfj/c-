using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._12home
{
    internal class Program
    {
        static string GetSeason(int month)
        {
            if (month >= 1 && month <= 2 || month == 12)
                return "Winter";
            else if (month >= 3 && month <= 5)
                return "Spring";
            else if (month >= 6 && month <= 8)
                return "Summer";
            else
                return "Autumn";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: Enter a number between 1 and 100:");
            int number1 = int.Parse(Console.ReadLine());

            if (number1 >= 1 && number1 <= 100)
            {
                if (number1 % 3 == 0 && number1 % 5 == 0)
                    Console.WriteLine("Fizz Buzz");
                else if (number1 % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (number1 % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(number1);
            }
            else
            {
                Console.WriteLine("Error: The entered number is not within the range of 1 to 100.");
            }
            // Task 2
            Console.WriteLine("\nTask 2: Enter two numbers:");
            double value = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double result = (percentage / 100) * value;
            Console.WriteLine($"Result: {result}");

            // Task 3
            Console.WriteLine("\nTask 3: Enter four digits:");
            int digit1 = int.Parse(Console.ReadLine());
            int digit2 = int.Parse(Console.ReadLine());
            int digit3 = int.Parse(Console.ReadLine());
            int digit4 = int.Parse(Console.ReadLine());


            int formedNumber = digit1 * 1000 + digit2 * 100 + digit3 * 10 + digit4;
            Console.WriteLine($"Formed number: {formedNumber}");

            // Task 4
            Console.WriteLine("\nTask 4: Enter a six-digit number and positions to swap:");
            int sixDigitNumber = int.Parse(Console.ReadLine());
            int position1 = int.Parse(Console.ReadLine());
            int position2 = int.Parse(Console.ReadLine());

            if (sixDigitNumber >= 100000 && sixDigitNumber <= 999999)
            {
                int[] digits = sixDigitNumber.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

                int temp = digits[position1 - 1];
                digits[position1 - 1] = digits[position2 - 1];
                digits[position2 - 1] = temp;

                int resultNumber = int.Parse(string.Join("", digits));
                Console.WriteLine($"Result: {resultNumber}");
            }
            else
            {
                Console.WriteLine("Error: The entered number is not six-digit.");
            }

            // Task 5
            Console.WriteLine("\nTask 5: Enter a date in the format dd.mm.yyyy:");
            DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            string season = GetSeason(inputDate.Month);
            string dayOfWeek = inputDate.ToString("dddd");

            Console.WriteLine($"{season} {dayOfWeek}");
        }


    }
}

