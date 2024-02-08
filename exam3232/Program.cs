using System;
using System.Collections.Generic;
using System.IO;

namespace DictionariesApp
{
    // Class for representing a dictionary
    class Dictionary
    {
        private Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

        // Adding a word and its translations to the dictionary
        public void AddWord(string word, List<string> translations)
        {
            words[word] = translations;
        }

        // Editing translations of a word in the dictionary
        public void EditWord(string word, List<string> translations)
        {
            if (words.ContainsKey(word))
            {
                words[word] = translations;
            }
            else
            {
                Console.WriteLine("Word not found in the dictionary.");
            }
        }

        // Deleting a word from the dictionary
        public void DeleteWord(string word)
        {
            if (words.ContainsKey(word))
            {
                words.Remove(word);
            }
            else
            {
                Console.WriteLine("Word not found in the dictionary.");
            }
        }

        // Searching for translations of a word in the dictionary
        public List<string> SearchWord(string word)
        {
            if (words.ContainsKey(word))
            {
                return words[word];
            }
            else
            {
                Console.WriteLine("Word not found in the dictionary.");
                return new List<string>();
            }
        }

        // Saving the dictionary to a file
        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in words)
                {
                    writer.WriteLine($"{entry.Key}:{string.Join(",", entry.Value)}");
                }
            }
        }

        // Loading the dictionary from a file
        public void LoadFromFile(string filePath)
        {
            words.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string word = parts[0];
                    List<string> translations = new List<string>(parts[1].Split(','));
                    words[word] = translations;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary engUkrDictionary = new Dictionary();
            Dictionary plUkrDictionary = new Dictionary();

            // Menu for interacting with the program
            while (true)
            {
                Console.WriteLine("1. English-Ukrainian Dictionary");
                Console.WriteLine("2. Polish-Ukrainian Dictionary");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Working with the English-Ukrainian dictionary
                        EngUkrMenu(engUkrDictionary);
                        break;
                    case "2":
                        // Working with the Polish-Ukrainian dictionary
                        PlUkrMenu(plUkrDictionary);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Menu for working with the English-Ukrainian dictionary
        static void EngUkrMenu(Dictionary engUkrDictionary)
        {
            while (true)
            {
                Console.WriteLine("\nEnglish-Ukrainian Dictionary Menu:");
                Console.WriteLine("1. Add a word");
                Console.WriteLine("2. Edit a word");
                Console.WriteLine("3. Delete a word");
                Console.WriteLine("4. Search for a translation");
                Console.WriteLine("5. Save the dictionary to a file");
                Console.WriteLine("6. Load the dictionary from a file");
                Console.WriteLine("7. Return to the main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWordToDictionary(engUkrDictionary);
                        break;
                    case "2":
                        EditWordInDictionary(engUkrDictionary);
                        break;
                    case "3":
                        DeleteWordFromDictionary(engUkrDictionary);
                        break;
                    case "4":
                        SearchWordInDictionary(engUkrDictionary);
                        break;
                    case "5":
                        SaveDictionaryToFile(engUkrDictionary);
                        break;
                    case "6":
                        LoadDictionaryFromFile(engUkrDictionary);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Menu for working with the Polish-Ukrainian dictionary
        static void PlUkrMenu(Dictionary plUkrDictionary)
        {
            while (true)
            {
                Console.WriteLine("\nPolish-Ukrainian Dictionary Menu:");
                Console.WriteLine("1. Add a word");
                Console.WriteLine("2. Edit a word");
                Console.WriteLine("3. Delete a word");
                Console.WriteLine("4. Search for a translation");
                Console.WriteLine("5. Save the dictionary to a file");
                Console.WriteLine("6. Load the dictionary from a file");
                Console.WriteLine("7. Return to the main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWordToDictionary(plUkrDictionary);
                        break;
                    case "2":
                        EditWordInDictionary(plUkrDictionary);
                        break;
                    case "3":
                        DeleteWordFromDictionary(plUkrDictionary);
                        break;
                    case "4":
                        SearchWordInDictionary(plUkrDictionary);
                        break;
                    case "5":
                        SaveDictionaryToFile(plUkrDictionary);
                        break;
                    case "6":
                        LoadDictionaryFromFile(plUkrDictionary);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        
        static void AddWordToDictionary(Dictionary dictionary)
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            Console.Write("Enter translation(s), separated by commas: ");
            List<string> translations = new List<string>(Console.ReadLine().Split(','));

            dictionary.AddWord(word, translations);
            Console.WriteLine("The word has been added to the dictionary.");
        }

        static void EditWordInDictionary(Dictionary dictionary)
        {
            Console.Write("Enter the word to edit: ");
            string word = Console.ReadLine();
            Console.Write("Enter new translation(s), separated by commas: ");
            List<string> translations = new List<string>(Console.ReadLine().Split(','));

            dictionary.EditWord(word, translations);
            Console.WriteLine("The word in the dictionary has been edited.");
        }

        
        static void DeleteWordFromDictionary(Dictionary dictionary)
        {
            Console.Write("Enter the word to delete: ");
            string word = Console.ReadLine();

            dictionary.DeleteWord(word);
            Console.WriteLine("The word has been deleted from the dictionary.");
        }


        static void SearchWordInDictionary(Dictionary dictionary)
        {
            Console.Write("Enter the word to search for translation: ");
            string word = Console.ReadLine();

            List<string> translations = dictionary.SearchWord(word);
            Console.WriteLine($"Translation(s) of the word '{word}': {string.Join(", ", translations)}");
        }

       
        static void SaveDictionaryToFile(Dictionary dictionary)
        {
            Console.Write("Enter the file path to save: ");
            string filePath = Console.ReadLine();

            dictionary.SaveToFile(filePath);
            Console.WriteLine("The dictionary has been saved to the file.");
        }

        
        static void LoadDictionaryFromFile(Dictionary dictionary)
        {
            Console.Write("Enter the file path to load: ");
            string filePath = Console.ReadLine();

            dictionary.LoadFromFile(filePath);
            Console.WriteLine("The dictionary has been loaded from the file.");
        }
    }
}
