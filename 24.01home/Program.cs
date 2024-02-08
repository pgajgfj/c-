using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._01home
{
    class AppSettingHelper
    {
        private string settingsFilePath;

        public AppSettingHelper(string filePath)
        {
            settingsFilePath = filePath;
        }

        public void SaveSettings(string consoleColor, string windowTitle, int windowWidth, int windowHeight)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(settingsFilePath, FileMode.Create)))
            {
                writer.Write(consoleColor);
                writer.Write(windowTitle);
                writer.Write(windowWidth);
                writer.Write(windowHeight);
            }
        }

        public (string, string, int, int) LoadSettings()
        {
            string consoleColor;
            string windowTitle;
            int windowWidth;
            int windowHeight;

            using (BinaryReader reader = new BinaryReader(File.Open(settingsFilePath, FileMode.Open)))
            {
                consoleColor = reader.ReadString();
                windowTitle = reader.ReadString();
                windowWidth = reader.ReadInt32();
                windowHeight = reader.ReadInt32();
            }

            return (consoleColor, windowTitle, windowWidth, windowHeight);
        }
    }

    // Завдання 1.2
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] Grades { get; set; }
        public string Specialization { get; set; }

        public Student(string firstName, string lastName, int[] grades, string specialization)
        {
            FirstName = firstName;
            LastName = lastName;
            Grades = grades;
            Specialization = specialization;
        }
    }

    class FileWorker
    {
        public static void SaveStudents(Student[] students, string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                writer.Write(students.Length);
                foreach (var student in students)
                {
                    writer.Write(student.FirstName);
                    writer.Write(student.LastName);
                    writer.Write(student.Grades.Length);
                    foreach (var grade in student.Grades)
                    {
                        writer.Write(grade);
                    }
                    writer.Write(student.Specialization);
                }
            }
        }

        public static Student[] LoadStudents(string filename)
        {
            List<Student> students = new List<Student>();
            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                int numStudents = reader.ReadInt32();
                for (int i = 0; i < numStudents; i++)
                {
                    string firstName = reader.ReadString();
                    string lastName = reader.ReadString();
                    int numGrades = reader.ReadInt32();
                    int[] grades = new int[numGrades];
                    for (int j = 0; j < numGrades; j++)
                    {
                        grades[j] = reader.ReadInt32();
                    }
                    string specialization = reader.ReadString();
                    students.Add(new Student(firstName, lastName, grades, specialization));
                }
            }
            return students.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1.1 - демонстрація роботи класу AppSettingHelper
            string settingsFilePath = "settings.dat";
            AppSettingHelper settingsHelper = new AppSettingHelper(settingsFilePath);
            settingsHelper.SaveSettings("Green", "My App", 800, 600);
            var settings = settingsHelper.LoadSettings();
            Console.WriteLine($"Console Color: {settings.Item1}");
            Console.WriteLine($"Window Title: {settings.Item2}");
            Console.WriteLine($"Window Width: {settings.Item3}");
            Console.WriteLine($"Window Height: {settings.Item4}");

            // Завдання 1.2 - демонстрація роботи класу FileWorker
            Student[] students = {
                new Student("John", "Doe", new int[] { 90, 85, 95 }, "Computer Science"),
                new Student("Jane", "Smith", new int[] { 80, 75, 85 }, "Mathematics")
            };
            string studentsFilePath = "students.dat";
            FileWorker.SaveStudents(students, studentsFilePath);
            var loadedStudents = FileWorker.LoadStudents(studentsFilePath);
            Console.WriteLine("\nLoaded Students:");
            foreach (var student in loadedStudents)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Specialization: {student.Specialization}");
                Console.Write("Grades: ");
                foreach (var grade in student.Grades)
                {
                    Console.Write($"{grade} ");
                }
                Console.WriteLine();
            }
        }
    }
}
