using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DictionariesApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, List<string>> engUkrDictionary = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> plUkrDictionary = new Dictionary<string, List<string>>();
        private TextBox txtWordPlUkr;
        private TextBox txtTranslationsPlUkr;
        private TextBox txtWordEngUkr;
        private TextBox txtTranslationsEngUkr;
        private TextBox txtSearchPlUkr;
        private TextBox txtSearchEngUkr;
        private TextBox txtFilePathPlUkr;
        private TextBox txtFilePathEngUkr;
        private TextBox txtTranslation;
        private TextBox txtTranslationInput;
        private TextBox txtTranslationPlUkrInput;
        private TextBox txtWordPlUkrInput;

        public MainForm()
        {
            this.BackColor = Color.Black;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            
            txtWordPlUkr = CreateTextBox("");
            txtTranslationsPlUkr = CreateTextBox("");
            txtWordEngUkr = CreateTextBox("");
            txtTranslationsEngUkr = CreateTextBox("");
            txtSearchPlUkr = CreateTextBox("");
            txtSearchEngUkr = CreateTextBox("");
            txtFilePathPlUkr = CreateTextBox("");
            txtFilePathEngUkr = CreateTextBox("");
            txtTranslation = CreateTextBox("");
            txtTranslationInput = CreateTextBox("");
            txtWordPlUkrInput = CreateTextBox("");
            txtTranslationPlUkrInput = CreateTextBox("");

            Controls.Add(txtWordPlUkr);
            Controls.Add(txtTranslationsPlUkr);
            Controls.Add(txtWordEngUkr);
            Controls.Add(txtTranslationsEngUkr);
            Controls.Add(txtSearchPlUkr);
            Controls.Add(txtSearchEngUkr);
            Controls.Add(txtFilePathPlUkr);
            Controls.Add(txtFilePathEngUkr);
            Controls.Add(txtTranslation);

            
            Button btnAddEngUkr = CreateButton("Add Eng-Ukr Word", btnAddEngUkr_Click);
            Button btnEditEngUkr = CreateButton("Edit Eng-Ukr Word", btnEditEngUkr_Click);
            Button btnDeleteEngUkr = CreateButton("Delete Eng-Ukr Word", btnDeleteEngUkr_Click);
            Button btnSearchEngUkr = CreateButton("Search Eng-Ukr Word", btnSearchEngUkr_Click);
            Button btnSaveEngUkr = CreateButton("Save Eng-Ukr Dictionary", btnSaveEngUkr_Click);
            Button btnLoadEngUkr = CreateButton("Load Eng-Ukr Dictionary", btnLoadEngUkr_Click);
            Button btnAddPlUkr = CreateButton("Add Pl-Ukr Word", btnAddPlUkr_Click);
            Button btnEditPlUkr = CreateButton("Edit Pl-Ukr Word", btnEditPlUkr_Click);
            Button btnDeletePlUkr = CreateButton("Delete Pl-Ukr Word", btnDeletePlUkr_Click);
            Button btnSearchPlUkr = CreateButton("Search Pl-Ukr Word", btnSearchPlUkr_Click);
            Button btnSavePlUkr = CreateButton("Save Pl-Ukr Dictionary", btnSavePlUkr_Click);
            Button btnLoadPlUkr = CreateButton("Load Pl-Ukr Dictionary", btnLoadPlUkr_Click);

           
            btnAddEngUkr.Location = new Point(250, 5);
            btnEditEngUkr.Location = new Point(250, 38);
            btnDeleteEngUkr.Location = new Point(250, 64);
            btnSearchEngUkr.Location = new Point(250, 90);
            btnSaveEngUkr.Location = new Point(250, 116);
            btnLoadEngUkr.Location = new Point(250, 142);
            btnAddPlUkr.Location = new Point(250, 168);
            btnEditPlUkr.Location = new Point(250, 194);
            btnDeletePlUkr.Location = new Point(250, 220);
            btnSearchPlUkr.Location = new Point(250, 246);
            btnSavePlUkr.Location = new Point(250, 272);
            btnLoadPlUkr.Location = new Point(250, 298);

            // Add buttons to the form
            Controls.Add(btnAddEngUkr);
            Controls.Add(btnEditEngUkr);
            Controls.Add(btnDeleteEngUkr);
            Controls.Add(btnSearchEngUkr);
            Controls.Add(btnSaveEngUkr);
            Controls.Add(btnLoadEngUkr);
            Controls.Add(btnAddPlUkr);
            Controls.Add(btnEditPlUkr);
            Controls.Add(btnDeletePlUkr);
            Controls.Add(btnSearchPlUkr);
            Controls.Add(btnSavePlUkr);
            Controls.Add(btnLoadPlUkr);

            // Add dictionary name label
            Label lblDictionaryName = new Label();
            lblDictionaryName.Text = "Dictionary by me";
            lblDictionaryName.Font = new Font(lblDictionaryName.Font.FontFamily, 14, FontStyle.Bold);
            lblDictionaryName.ForeColor = Color.White;
            lblDictionaryName.AutoSize = true;
            lblDictionaryName.Location = new Point((this.ClientSize.Width - lblDictionaryName.Width) / 2, 350);
            Controls.Add(lblDictionaryName);

            txtTranslationInput = CreateTextBox("");
            txtTranslationInput.Location = new Point(0, 26);
            Controls.Add(txtTranslationInput);

            txtWordPlUkrInput = CreateTextBox("Enter word:");
            txtWordPlUkrInput.Location = new Point(0, 58);
            Controls.Add(txtWordPlUkrInput);

            txtTranslationPlUkrInput = CreateTextBox("");
            txtTranslationPlUkrInput.Location = new Point(0, 84);
            Controls.Add(txtTranslationPlUkrInput);
        }

        private Button CreateButton(string text, EventHandler handler)
        {
            Button button = new Button();
            button.Text = text;
            button.BackColor = Color.FromArgb(66, 133, 244); 
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.AutoSize = true;
            button.Padding = new Padding(10);
            button.Click += handler;
            return button;
        }

        private TextBox CreateTextBox(string description)
        {
            TextBox textBox = new TextBox();
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Width = 200;
            textBox.Text = description;
            return textBox;
        }

        // Event handlers for Eng-Ukr dictionary buttons
        private void btnAddEngUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordEngUkr.Text;
            string translation = txtTranslationInput.Text;

            if (!engUkrDictionary.ContainsKey(word))
            {
                List<string> translations = new List<string>();
                translations.Add(translation);
                engUkrDictionary[word] = translations;
                MessageBox.Show("The word has been added to the English-Ukrainian dictionary.");
            }
            else
            {
                engUkrDictionary[word].Add(translation);
                MessageBox.Show("The translation has been added to the existing word in the English-Ukrainian dictionary.");
            }
        }

        private void btnEditEngUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordEngUkr.Text;
            string translation = txtTranslationInput.Text;

            if (engUkrDictionary.ContainsKey(word))
            {
                engUkrDictionary[word].Clear();
                engUkrDictionary[word].Add(translation);
                MessageBox.Show("The translation for the word in the English-Ukrainian dictionary has been edited.");
            }
            else
            {
                MessageBox.Show("The word was not found in the English-Ukrainian dictionary.");
            }
        }

        private void btnDeleteEngUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordEngUkr.Text;

            if (engUkrDictionary.ContainsKey(word))
            {
                engUkrDictionary.Remove(word);
                MessageBox.Show("The word has been deleted from the English-Ukrainian dictionary.");
            }
            else
            {
                MessageBox.Show("The word was not found in the English-Ukrainian dictionary.");
            }
        }

        private void btnSearchEngUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordPlUkrInput.Text.Trim();

            if (engUkrDictionary.ContainsKey(word))
            {
                MessageBox.Show($"Translation(s) of the word '{word}': {string.Join(", ", engUkrDictionary[word])}");
            }
            else
            {
                MessageBox.Show("The word was not found in the English-Ukrainian dictionary.");
            }
        }

        private void btnSaveEngUkr_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePathEngUkr.Text;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in engUkrDictionary)
                {
                    writer.WriteLine($"{entry.Key}:{string.Join(",", entry.Value)}");
                }
            }

            MessageBox.Show("The English-Ukrainian dictionary has been saved to a file.");
        }

        private void btnLoadEngUkr_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePathEngUkr.Text;

            engUkrDictionary.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string word = parts[0];
                    List<string> translations = new List<string>(parts[1].Split(','));
                    engUkrDictionary[word] = translations;
                }
            }

            MessageBox.Show("The English-Ukrainian dictionary has been loaded from a file.");
        }

        // Event handlers for Pl-Ukr dictionary buttons
        private void btnAddPlUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordPlUkrInput.Text;
            string translation = txtTranslationPlUkrInput.Text;

            if (!plUkrDictionary.ContainsKey(word))
            {
                List<string> translations = new List<string>();
                translations.Add(translation);
                plUkrDictionary[word] = translations;
                MessageBox.Show("The word has been added to the Polish-Ukrainian dictionary.");
            }
            else
            {
                plUkrDictionary[word].Add(translation);
                MessageBox.Show("The translation has been added to the existing word in the Polish-Ukrainian dictionary.");
            }
        }

        private void btnEditPlUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordPlUkrInput.Text;
            string translation = txtTranslationPlUkrInput.Text;

            if (plUkrDictionary.ContainsKey(word))
            {
                plUkrDictionary[word].Clear();
                plUkrDictionary[word].Add(translation);
                MessageBox.Show("The translation for the word in the Polish-Ukrainian dictionary has been edited.");
            }
            else
            {
                MessageBox.Show("The word was not found in the Polish-Ukrainian dictionary.");
            }
        }

        private void btnDeletePlUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordPlUkrInput.Text;

            if (plUkrDictionary.ContainsKey(word))
            {
                plUkrDictionary.Remove(word);
                MessageBox.Show("The word has been deleted from the Polish-Ukrainian dictionary.");
            }
            else
            {
                MessageBox.Show("The word was not found in the Polish-Ukrainian dictionary.");
            }
        }

        private void btnSearchPlUkr_Click(object sender, EventArgs e)
        {
            string word = txtWordPlUkrInput.Text.Trim();

            if (plUkrDictionary.ContainsKey(word))
            {
                MessageBox.Show($"Translation(s) of the word '{word}': {string.Join(", ", plUkrDictionary[word])}");
            }
            else
            {
                MessageBox.Show($"The word '{word}' was not found in the Polish-Ukrainian dictionary.");
            }
        }

        private void btnSavePlUkr_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePathPlUkr.Text;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in plUkrDictionary)
                {
                    writer.WriteLine($"{entry.Key}:{string.Join(",", entry.Value)}");
                }
            }

            MessageBox.Show("The Polish-Ukrainian dictionary has been saved to a file.");
        }

        private void btnLoadPlUkr_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePathPlUkr.Text;

            plUkrDictionary.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string word = parts[0];
                    List<string> translations = new List<string>(parts[1].Split(','));
                    plUkrDictionary[word] = translations;
                }
            }

            MessageBox.Show("The Polish-Ukrainian dictionary has been loaded from a file.");
        }

        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
