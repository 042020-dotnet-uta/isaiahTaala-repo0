using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using StoreApp.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore.Sqlite.Query.Internal;

namespace StoreApp
{
    public class UserInterface
    {
        private DataAccessLayer Dal { get; } = new DataAccessLayer();
        private Customer CurrentUser { get; set; }
        private string[] MenuOptions = {
            "Place order for customer",
            "Add a new customer",
            "Search customers by name",
            "Display details of a customer's order",
            "Display all order history of a store location",
            "Display all order history of a customer",
            "Display inventory of location",
            "Quit"
        };

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Menu Options");
                Console.WriteLine();

                for (int i = 0; i < MenuOptions.Length; ++i)
                    Console.WriteLine($"{i}: {MenuOptions[i]}");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Command required ");
                int command = GetInt(
                    $"Please enter a command number (0 - {MenuOptions.Length - 1}): "
                    , 0, MenuOptions.Length-1);

                switch (command)
                {
                    case 0: PlaceOrder(); break;
                    case 1: AddCustomer(); break;
                    case 2: SearchCustomerByName(); break;
                    case 3: DisplayCustomerOrder(); break;
                    case 4: DisplayStoreOrders(); break;
                    case 5: DisplayCustomerOrders(); break;
                    case 6: DisplayLocationInventory(); break;
                    case 7: Console.WriteLine("Quitting now"); return;
                    default: Console.WriteLine("Command not recognized"); break;
                }
            }
        }

        private void PlaceOrder() {
            Console.WriteLine("Place order for customer");
            Customer customer = GetCustomer();
            Location location = GetLocation();

            Order order = GetOrder( customer );
            Dal.Add(order);
            GetProductOrders(customer, location, order);
        }

        private Order GetOrder(Customer customer)
        {
            Order order = new Order();
            order.TimeStamp = DateTime.Now.ToString();
            order.Customer.CustomerID = customer.CustomerID;
            return order;
        }

        private void GetProductOrders(Customer customer, Location location, Order order)
        { 
            List<Inventory> inventory = Dal.GetInventory(location);
            List<Product> products = Dal.GetProducts();

            bool customerIsOrdering = true;
            int maxOrderLimit = 5;
            while (customerIsOrdering)
            {
                ProductOrder po = new ProductOrder();
                po.Order = order;
                Console.WriteLine($"Products in {location.City}");
                for (int i = 0; i < products.Count; ++i)
                {
                    Console.Write($"{i}: ");
                    Console.Write($"Product = {inventory[i].Product.Name} ");
                    Console.Write($"Quantity = {inventory[i].Quantity} ");
                    Console.WriteLine($"Price = {inventory[i].Product.Price}");
                    Console.WriteLine();
                }

                int productSelected = GetInt($"Enter a product by number (0 - {products.Count - 1})", 0, products.Count - 1);
                if (inventory[productSelected].Quantity == 0)
                    Console.WriteLine($"{inventory[productSelected].Product.Name} is out of stock");
                else
                {
                    int currentQuantity = inventory[productSelected].Quantity;
                    int lowestAmount = (maxOrderLimit > currentQuantity) ? currentQuantity : maxOrderLimit;
                    int quantitySelected = GetInt($"Enter a quantity (up to {lowestAmount})", 1, lowestAmount);

                    po.Product = products[productSelected];
                    po.Quantity = quantitySelected;
                    Dal.Add(po);
                    Console.WriteLine("Product added to order");
                }
                customerIsOrdering = GetBool("Would you like to order something else?");
            }
        }

        private bool GetBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                Console.WriteLine(" (Enter y or n): ");
                string choice = Console.ReadLine();
                if (choice == "y")
                    return true;
                else if (choice == "n")
                    return false;
                else
                    Console.WriteLine($"{choice} not recognized");
            }
        }

        private void AddCustomer()
        {
            Console.WriteLine("Add a new customer");
            Console.WriteLine("Please provide customer details");

            Customer customer = new Customer();

            customer.FirstName = GetName("First name: ");
            customer.LastName = GetName("Last name: ");

            Console.Write("Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Password: ");
            customer.Password = Console.ReadLine();

            if (!Dal.CustomerInDB(customer))
            {
                Dal.Add(customer);
                Console.WriteLine($"Customer {customer.FirstName} added");
            }
            else
            {
                Console.WriteLine($"Customer {customer.FirstName} already exists in database, add canceled");
            }
        }

        private void SearchCustomerByName()
        {
            Console.WriteLine("Search customers by name");
            string firstName = GetName("First name: ");
            string lastName = GetName("Last name: ");

            List<Customer> customers = Dal.GetCustomersBy(firstName, lastName);
            if (customers.Count == 0)
                Console.WriteLine($"No customers by {firstName} {lastName} found");
            else
            {
                Console.WriteLine($"Customers by {firstName} {lastName} found");
                foreach (Customer c in customers)
                {
                    Console.Write($"id = {c.CustomerID} ");
                    Console.Write($"email = {c.Email} ");
                    // Console.Write($"password = {c.Password}");
                    Console.WriteLine();
                }
            }
        }

        private void DisplayCustomerOrder()
        {
            Console.WriteLine("Display details of a customer's order");
            Customer customer = GetCustomer();
            int orderID = GetOrderID(customer);
            Order order = Dal.GetCustomerOrder(orderID);

            Console.WriteLine($"Order {orderID}");
            Console.WriteLine($"Customer = {customer.FirstName} {customer.LastName} {customer.Email} ");
            Console.WriteLine($"Location = {order.Location.Address}, {order.Location.City}, {order.Location.State}");
            Console.WriteLine($"TimeStamp = {order.TimeStamp}");
            DisplayProductOrders(orderID);
        }

        private void DisplayProductOrders(int orderID)
        {
            List<ProductOrder> productOrders = Dal.GetProductOrders(orderID);

            Console.WriteLine("Product");
            Console.WriteLine();

            int total = 0;
            foreach (ProductOrder po in productOrders)
            {
                int poPrice = po.Product.Price * po.Quantity;
                total += poPrice;

                Console.Write($"Product = {po.Product.Name}, ");
                Console.Write($"Quantity = {po.Quantity}");
                Console.Write($"Price = {poPrice}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total = {total}");
            Console.WriteLine();
        }

        private void DisplayStoreOrders()
        {
            Console.WriteLine("Display all order history of a story location");
            Location location = GetLocation();

            OrdersFrom( location );
        }

        private void OrdersFrom(Location location)
        {
            string fullAddress = $"{location.Address}, {location.City}, {location.State}";
            Console.WriteLine($"Order history from {fullAddress}");
            Console.WriteLine();

            List<Order> orders = Dal.GetLocationOrderHistory(location.LocationID);
            foreach(Order o in orders)
            {
                Console.Write($"OrderID = {o.OrderID} ");
                Console.Write($"CustomerID = {o.Customer.CustomerID} ");
                Console.Write($"TimeStamp = {o.TimeStamp} ");
                DisplayProductOrders(o.OrderID);
                Console.WriteLine();
            }
        }

        private void DisplayCustomerOrders()
        {
            Console.WriteLine("Display all order history of a customer");
            
            List<Customer> customers = Dal.GetAllCustomers();
            for (int i = 0; i < customers.Count; ++i)
            {
                string customerRecord = $"{customers[i].FirstName} {customers[i].LastName} {customers[i].Email}";
                Console.WriteLine($"{i}: {customerRecord} ");
            }
            int customerSelection = GetInt($"Enter customer by number (0 - {customers.Count-1}): ", 0, customers.Count-1);

            OrdersFrom(customers[customerSelection]);
        }

        private void OrdersFrom( Customer customer)
        {
            string customerRecord = $"{customer.FirstName} {customer.LastName} {customer.Email}";
            Console.WriteLine($"Order history from {customerRecord}");

            List<Order> orders = Dal.GetCustomerOrderHistory(customer.CustomerID);
            foreach (Order o in orders)
            {
                string fullAddress = $"{o.Location.Address}, {o.Location.City}, {o.Location.State}";

                Console.Write($"OrderID = {o.OrderID} ");
                Console.Write($"Location = {fullAddress} ");
                Console.Write($"TimeStamp = {o.TimeStamp} ");
                DisplayProductOrders(o.OrderID);
                Console.WriteLine();
            }
        }

        private void DisplayLocationInventory()
        {
            Console.WriteLine("Display inventory of location");
            Location location = GetLocation();

            InventoryOf(location);
        }

        private Location GetLocation()
        {
            List<Location> locations = Dal.GetAllLocations();

            for (int i = 0; i < locations.Count; ++i)
            {
                string fullAddress = $"{locations[i].Address}, {locations[i].City}, {locations[i].State}";
                Console.WriteLine($"{i}: {fullAddress}");
            }
            int locationSelection = GetInt($"Enter location by number (0 - {locations.Count-1}): ", 0, locations.Count-1);
            return locations[locationSelection];
        }

        private Customer GetCustomer()
        {
            List<Customer> customers = Dal.GetAllCustomers();

            for (int i = 0; i < customers.Count; ++i)
            {
                string customerRecord = $"{customers[i].FirstName} {customers[i].LastName} {customers[i].Email}";
                Console.WriteLine($"{i}: {customerRecord}");
            }
            int customerSelection = GetInt($"Enter customer by number (0 - {customers.Count-1}): ", 0, customers.Count-1 );
            return customers[customerSelection];
        }

        private int GetOrderID(Customer customer)
        {
            int totalCustomerOrders = Dal.GetTotalCustomerOrders(customer.CustomerID);
            return GetInt($"Enter an OrderID by number (0 - {totalCustomerOrders})", 0, totalCustomerOrders-1);
        }

        private void InventoryOf(Location location)
        {
            Console.WriteLine($"Inventory of {location.City}");
            List<Inventory> inventory = Dal.GetInventory(location);
            foreach(Inventory i in inventory)
            {
                Console.Write($"Product = {i.Product.ProductID} ");
                Console.Write($"Quantity = {i.Quantity} ");
                Console.WriteLine();
            }
        }

        //private void PromptUserLogin()
        //{
        //    Customer customer = new Customer();
        //    while (CurrentUser == null)
        //    {
        //        Console.WriteLine("\nLogin\n");

        //        customer.FirstName = GetUserName("Please enter first name: ");
        //        customer.LastName = GetUserName("Please enter last name: ");

        //        Console.Write("Please enter email: ");
        //        customer.Email = Console.ReadLine();

        //        Console.Write("Please enter password: ");
        //        customer.Password = Console.ReadLine();

        //        LoginUser(customer);

        //    }
        //}

        //private void LoginUser( Customer customer )
        //{
        //    if (Dal.CustomerInDB(customer))
        //    {
        //        CurrentUser = Dal.GetCustomer(customer);
        //        if(CurrentUser == null)
        //            Console.WriteLine("Password is incorrect");
        //    }
        //    else
        //    {
        //        CurrentUser = customer;
        //        Dal.Add(customer);
        //    }
        //}   

        private bool NameIsValid(string name)
        {
            int max = 35;

            if (name.Length == 0)
            {
                Console.WriteLine("Name must not be empty");
                return false;
            }
            else if (name.Length > max)
            {
                Console.WriteLine($"Name must not exceed {max} characters");
                return false;
            }
            // to find out if name is only letters, answered by Muhammad Hasan Khan on stackoverflow
            // https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp
            else if (!name.All(Char.IsLetter))
            {
                Console.WriteLine($"Name can only contain letters");
                return false;
            }

            return true;
        }

        private string GetName(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string name = Console.ReadLine();

                if (NameIsValid(name))
                    return name;
            }
        }

        //private bool EmailIsValid(string name)
        //{

        //}

        private int GetInt(string prompt)
        {
            int validNumber = 0;
            bool isValid = false;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out validNumber);

                if (!isValid)
                    Console.WriteLine($"invalid, must be number");

            } while (!isValid);
            return validNumber;
        }

        private int GetInt(string prompt, int min, int max)
        {
            while (true)
            {
                int validNumber = GetInt(prompt);
                if (validNumber > max || validNumber < min)
                    Console.WriteLine($"invalid, number must be between {min} and {max}");
                else
                    return validNumber;
            }
        }
    }
}
