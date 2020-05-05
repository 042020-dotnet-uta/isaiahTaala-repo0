using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class Customer
    {
		private int customerID;
		private string firstName;
		private string lastName;
		private string email;
		private string password;

		public int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

	}
}
