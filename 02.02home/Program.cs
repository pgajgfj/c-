using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DictionaryApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, Dictionary<string, string>> englishUkrainianDictionary;
        private Dictionary<string, Dictionary<string, string>> polishUkrainianDictionary;

        public MainForm()
        {
            InitializeComponent();

            // Initialize dictionaries
            englishUkrainianDictionary = new Dictionary<string, Dictionary<string, string>>();
            polishUkrainianDictionary = new Dictionary<string, Dictionary<string, string>>();
        }

        // Method to add or edit word and translations
        private void AddOrEditWord(string dictionaryType)
        {
            string word = txtWord.Text.Trim();
            string translationsText = txtTranslations.Text.Trim();

            // Check if the word and translations are provided
            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(translationsText))
            {
                MessageBox.Show("Please enter word and translations.");
                return;
            }

            // Split translations by comma and create a dictionary of translations
            var translations = translationsText.Split(',')
                .Select(t => t.Trim().Split('='))
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim());

            // Update the dictionary with the new or edited word and translations
            if (dictionaryType == "English-Ukrainian")
            {
                englishUkrainianDictionary[word] = translations;
            }
            else if (dictionaryType == "Polish-Ukrainian")
            {
                polishUkrainianDictionary[word] = translations;
            }

            MessageBox.Show("Word and translations saved successfully.");
        }

        
        private void DeleteWord(string dictionaryType)
        {
            string word = txtWord.Text.Trim();

            // Check if the word is provided
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Please enter a word.");
                return;
            }

            // Delete the word from the dictionary
            if (dictionaryType == "English-Ukrainian")
            {
                if (englishUkrainianDictionary.Remove(word))
                {
                    MessageBox.Show("Word and translations deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Word not found in the dictionary.");
                }
            }
            else if (dictionaryType == "Polish-Ukrainian")
            {
                if (polishUkrainianDictionary.Remove(word))
                {
                    MessageBox.Show("Word and translations deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Word not found in the dictionary.");
                }
            }
        }

       
        private void SearchTranslations(string dictionaryType)
        {
            string word = txtWord.Text.Trim();

            // Check if the word is provided
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Please enter a word to search translations.");
                return;
            }

            
            Dictionary<string, string> translations = null;
            if (dictionaryType == "English-Ukrainian")
            {
                englishUkrainianDictionary.TryGetValue(word, out translations);
            }
            else if (dictionaryType == "Polish-Ukrainian")
            {
                polishUkrainianDictionary.TryGetValue(word, out translations);
            }

           
            if (translations != null)
            {
                string translationsText = string.Join(Environment.NewLine,
                    translations.Select(t => $"{t.Key}: {t.Value}"));
                MessageBox.Show($"Translations for '{word}':{Environment.NewLine}{translationsText}");
            }
            else
            {
                MessageBox.Show($"Translations for '{word}' not found in the dictionary.");
            }
        }

        private void btnAddOrEditWord_Click(object sender, EventArgs e)
        {
            string dictionaryType = cmbDictionaryType.SelectedItem.ToString();
            AddOrEditWord(dictionaryType);
        }

        private void btnDeleteWord_Click(object sender, EventArgs e)
        {
            string dictionaryType = cmbDictionaryType.SelectedItem.ToString();
            DeleteWord(dictionaryType);
        }

        private void btnSearchTranslations_Click(object sender, EventArgs e)
        {
            string dictionaryType = cmbDictionaryType.SelectedItem.ToString();
            SearchTranslations(dictionaryType);
        }
    }
}