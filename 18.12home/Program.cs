using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._12home
{
    class Website
    {
        private string name;
        private string url;
        private string description;
        private string ipAddress;

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetUrl(string url)
        {
            this.url = url;
        }

        public string GetUrl()
        {
            return url;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetIpAddress(string ipAddress)
        {
            this.ipAddress = ipAddress;
        }

        public string GetIpAddress()
        {
            return ipAddress;
        }

        public void InputData()
        {
            Console.WriteLine("Enter website name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter website URL:");
            url = Console.ReadLine();
            Console.WriteLine("Enter website description:");
            description = Console.ReadLine();
            Console.WriteLine("Enter website IP address:");
            ipAddress = Console.ReadLine();
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"IP Address: {ipAddress}");
        }
    }

    class Magazine
    {
        private string name;
        private int foundingYear;
        private string description;
        private string contactPhone;
        private string email;

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetFoundingYear(int foundingYear)
        {
            this.foundingYear = foundingYear;
        }

        public int GetFoundingYear()
        {
            return foundingYear;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetContactPhone(string contactPhone)
        {
            this.contactPhone = contactPhone;
        }

        public string GetContactPhone()
        {
            return contactPhone;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void InputData()
        {
            Console.WriteLine("Enter magazine name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter founding year:");
            foundingYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter magazine description:");
            description = Console.ReadLine();
            Console.WriteLine("Enter contact phone:");
            contactPhone = Console.ReadLine();
            Console.WriteLine("Enter email:");
            email = Console.ReadLine();
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Founding Year: {foundingYear}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Contact Phone: {contactPhone}");
            Console.WriteLine($"Email: {email}");
        }
    }

    class Store
    {
        private string name;
        private string address;
        private string profileDescription;
        private string contactPhone;
        private string email;

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetProfileDescription(string profileDescription)
        {
            this.profileDescription = profileDescription;
        }

        public string GetProfileDescription()
        {
            return profileDescription;
        }

        public void SetContactPhone(string contactPhone)
        {
            this.contactPhone = contactPhone;
        }

        public string GetContactPhone()
        {
            return contactPhone;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void InputData()
        {
            Console.WriteLine("Enter store name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter store address:");
            address = Console.ReadLine();
            Console.WriteLine("Enter store profile description:");
            profileDescription = Console.ReadLine();
            Console.WriteLine("Enter contact phone:");
            contactPhone = Console.ReadLine();
            Console.WriteLine("Enter email:");
            email = Console.ReadLine();
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Profile Description: {profileDescription}");
            Console.WriteLine($"Contact Phone: {contactPhone}");
            Console.WriteLine($"Email: {email}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Website website = new Website();
            website.InputData();
            Console.WriteLine("\nWebsite Data:");
            website.DisplayData();

            Magazine magazine = new Magazine();
            magazine.InputData();
            Console.WriteLine("\nMagazine Data:");
            magazine.DisplayData();

            Store store = new Store();
            store.InputData();
            Console.WriteLine("\nStore Data:");
            store.DisplayData();
        }
    }
}
