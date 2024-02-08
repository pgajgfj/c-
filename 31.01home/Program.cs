    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _31._01home
{
    class Program
    {
        static void Main()
        {
            // Завдання 1
            List<int> fourDigitNumbers = new List<int>();
            for (int i = 1000; i < 10000; i++)
            {
                fourDigitNumbers.Add(i);
            }
            foreach (int number in fourDigitNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Завдання 2
            List<string> validWords = new List<string>();
            string[] words = { "asd123zxc456", "bnm567hjk890", "abc123def456ghi" };
            foreach (string word in words)
            {
                if (Regex.IsMatch(word, @"(\D*\d\D*){2}"))
                {
                    validWords.Add(word);
                }
            }
            foreach (string validWord in validWords)
            {
                Console.WriteLine(validWord);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Завдання 3
            List<string> abbreviations = new List<string>();
            string text = "The WWW is a file format. RTF is Rich Text Format. PDF stands for Portable Document Format. BMP is a bitmap image.";
            MatchCollection matches = Regex.Matches(text, @"\b[A-Z]{3}\b");
            foreach (Match match in matches)
            {
                abbreviations.Add(match.Value);
            }
            foreach (string abbreviation in abbreviations)
            {
                Console.WriteLine(abbreviation);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Завдання 4
            List<int> years = new List<int>();
            for (int year = 1000; year < 3000; year++)
            {
                if (year >= 1900 && year <= 2099)
                {
                    years.Add(year);
                }
            }
            foreach (int year in years)
            {
                Console.WriteLine(year);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Завдання 5
            List<string> phoneNumbers = new List<string>();
            string[] directory = { "+38-099-1234567", "+38-067-9876543", "+38-050-1122334", "+38-093-0012300" };
            foreach (string phoneNumber in directory)
            {
                if (Regex.IsMatch(phoneNumber, @"\+38-0\d{2}-\d{7}"))
                {
                    phoneNumbers.Add(phoneNumber);
                }
            }
            foreach (string number in phoneNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
