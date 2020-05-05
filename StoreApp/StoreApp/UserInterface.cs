using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using StoreApp.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace StoreApp
{
    public class UserInterface
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private DbContextClass db = new DbContextClass();

        public void Run()
        {
            PromptUserLogin();


        }

        public void PromptUserLogin()
        {
            //Console.WriteLine("Please enter first name: ");
            //FirstName = Console.ReadLine();

            //Console.WriteLine("Please enter last name: ");
            //LastName = Console.ReadLine();

            //Console.WriteLine("Please enter email: ");
            //Email = Console.ReadLine();

            //Console.WriteLine("Please enter password: ");
            //Password = Console.ReadLine();

            //Customer c = new Customer();
            //c.FirstName = FirstName;
            //c.LastName = LastName;
            //c.Email = Email;
            //c.Password = Password;

            //db.Add(c);
            //db.SaveChanges();

            ////verify the Db context is working.
            //var cust = db.Customers.Where(s => s.FirstName == "Isaiah").FirstOrDefault();
            ////var cust = db.Customers.Where(s => s.LastName == "Taala").FirstOrDefault();
            //Console.WriteLine($"first name {cust.FirstName}");
            //Console.WriteLine($"The player searched was...{cust.LastName}.");



        }

        public bool IsValidName(string name)
        {
            // if name is invalid (contains non alphabetical characters)
            return false;

            // else
            return true;
        }
    }
}
