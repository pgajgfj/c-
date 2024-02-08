using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._12home
{
    using System;

    interface IInputValidator
    {
        void ValidateInput(string input);
    }

    class Account : IInputValidator
    {
        private string email;
        private string password;

        public string Email
        {
            get { return email; }
            set
            {
                ValidateInput(value);
                email = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                ValidateInput(value);
                password = value;
            }
        }

        public void ValidateInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Value cannot be null or whitespace.");

            if (this.GetType() == typeof(Account))
            {
                if (this.email == null)
                {
                    
                    if (!input.Contains('@') || input.Length < 4 || input.Length > 50 || !IsValidEmail(input))
                        throw new ArgumentException("Invalid email address.");
                }
                else
                {
                    
                    if (input.Length < 6 || !ContainsLetterAndDigit(input))
                        throw new ArgumentException("Invalid password.");
                }
            }
            else if (this.GetType() == typeof(CreditCard))
            {
                
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Value cannot be null or whitespace.");
            }
        }

        private bool IsValidEmail(string email)
        {
            foreach (char c in email)
            {
                if (!char.IsLetterOrDigit(c) && c != '@' && c != '_')
                    return false;
            }
            return true;
        }

        private bool ContainsLetterAndDigit(string input)
        {
            bool containsLetter = false;
            bool containsDigit = false;
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    containsLetter = true;
                else if (char.IsDigit(c))
                    containsDigit = true;
            }
            return containsLetter && containsDigit;
        }
    }

    class CreditCard : Account
    {
        private string name;
        private string number;
        private string expirationDate;
        private string cvv;

        public string Name
        {
            get { return name; }
            set
            {
                ValidateInput(value);
                name = value;
            }
        }

        public string Number
        {
            get { return number; }
            set
            {
                ValidateInput(value);
                number = value;
            }
        }

        public string ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                ValidateInput(value);
                expirationDate = value;
            }
        }

        public string CVV
        {
            get { return cvv; }
            set
            {
                ValidateInput(value);
                cvv = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Приклад
            Account account = new Account();
            Console.WriteLine("Enter email:");
            account.Email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            account.Password = Console.ReadLine();

            CreditCard creditCard = new CreditCard();
            Console.WriteLine("Enter credit card name:");
            creditCard.Name = Console.ReadLine();

            Console.WriteLine("Enter credit card number:");
            creditCard.Number = Console.ReadLine();

            Console.WriteLine("Enter credit card expiration date:");
            creditCard.ExpirationDate = Console.ReadLine();

            Console.WriteLine("Enter credit card CVV:");
            creditCard.CVV = Console.ReadLine();
        }
    }

}
