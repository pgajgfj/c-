using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._01home
{
    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }

        public Employee(string fullName, string position, decimal salary, string email)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            Email = email;
        }

        public override string ToString()
        {
            return $"Full Name: {FullName}\nPosition: {Position}\nSalary: {Salary}\nEmail: {Email}";
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Update Employee Information");
                Console.WriteLine("4. Search Employees");
                Console.WriteLine("5. Sort Employees");
                Console.WriteLine("6. Display All Employees");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        RemoveEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        SearchEmployees();
                        break;
                    case 5:
                        SortEmployees();
                        break;
                    case 6:
                        DisplayAllEmployees();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 7.");
                        break;
                }
            }
        }

        static void RemoveEmployee()
        {
            Console.WriteLine("\nRemoving Employee");
            Console.Write("Enter Email of Employee to Remove: ");
            string email = Console.ReadLine();

            Employee employeeToRemove = employees.FirstOrDefault(e => e.Email == email);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                Console.WriteLine("Employee removed successfully!");
            }
            else
            {
                Console.WriteLine("Employee with specified email not found!");
            }
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("\nUpdating Employee Information");
            Console.Write("Enter Email of Employee to Update: ");
            string email = Console.ReadLine();

            Employee employeeToUpdate = employees.FirstOrDefault(e => e.Email == email);
            if (employeeToUpdate != null)
            {
                Console.Write("Enter New Full Name: ");
                employeeToUpdate.FullName = Console.ReadLine();
                Console.Write("Enter New Position: ");
                employeeToUpdate.Position = Console.ReadLine();
                Console.Write("Enter New Salary: ");
                employeeToUpdate.Salary = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Employee information updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee with specified email not found!");
            }
        }

        static void SearchEmployees()
        {
            Console.WriteLine("\nSearching Employees");
            Console.Write("Enter Search Keyword: ");
            string keyword = Console.ReadLine();

            var searchResults = employees.Where(e => e.FullName.Contains(keyword) || e.Position.Contains(keyword) || e.Email.Contains(keyword));
            if (searchResults.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var employee in searchResults)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("No employees found matching the search criteria.");
            }
        }

        static void SortEmployees()
        {
            Console.WriteLine("\nSorting Employees");
            Console.WriteLine("1. Sort by Full Name");
            Console.WriteLine("2. Sort by Position");
            Console.WriteLine("3. Sort by Salary");
            Console.WriteLine("4. Sort by Email");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    employees.Sort((emp1, emp2) => emp1.FullName.CompareTo(emp2.FullName));
                    break;
                case 2:
                    employees.Sort((emp1, emp2) => emp1.Position.CompareTo(emp2.Position));
                    break;
                case 3:
                    employees.Sort((emp1, emp2) => emp1.Salary.CompareTo(emp2.Salary));
                    break;
                case 4:
                    employees.Sort((emp1, emp2) => emp1.Email.CompareTo(emp2.Email));
                    break;
                default:
                    Console.WriteLine("Invalid choice! Sorting by Full Name.");
                    employees.Sort((emp1, emp2) => emp1.FullName.CompareTo(emp2.FullName));
                    break;
            }

            Console.WriteLine("Employees sorted successfully!");
        }

        static void DisplayAllEmployees()
        {
            Console.WriteLine("\nAll Employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
                Console.WriteLine();
            }
        }
        static void AddEmployee()
        {
            Console.WriteLine("\nAdding Employee");
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();
            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            employees.Add(new Employee(fullName, position, salary, email));
            Console.WriteLine("Employee added successfully!");
        }


    }
}
