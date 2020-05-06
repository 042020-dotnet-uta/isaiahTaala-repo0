using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using StoreApp.Models;

namespace StoreApp
{
    public class DataAccessLayer
    {
        private readonly DbContextClass db;

        public DataAccessLayer()
        {
            db = new DbContextClass();
        }

        public DataAccessLayer(DbContextClass dbContextClass)
        {
            db = dbContextClass;
        }

        public void Add(Customer customer)
        {
            db.Add(customer);
            db.SaveChanges();
        }

        public void Add(Order order)
        {
            db.Add(order);
            db.SaveChanges();
        }

        public void Add(ProductOrder productOrder)
        {
            db.Add(productOrder);
            db.SaveChanges();
        }

        public Order GetCustomerOrder(int orderID)
        {
            return db.Orders.Where(
                order => order.OrderID == orderID
                ).FirstOrDefault();
        }

        public List<ProductOrder> GetProductOrders(int orderID)
        {
            return db.ProductOrders.Where(
                productOrder => productOrder.Order.OrderID == orderID
                ).ToList();
        }

        public List<Order> GetCustomerOrderHistory(int customerID)
        {
            return db.Orders.Where(
                order => order.Customer.CustomerID == customerID
                ).ToList();
        }

        public int GetTotalCustomerOrders(int customerID)
        {
            return db.Orders.Where(
                order => order.Customer.CustomerID == customerID
                ).Count();
        }

        public List<Customer> GetCustomersBy(string firstName, string lastName)
        {
            return db.Customers.Where(
                c => c.FirstName == firstName
                && c.LastName == lastName
                ).ToList();
        }

        public List<Order> GetLocationOrderHistory(int locationID)
        {
            return db.Orders.Where(
                o => o.Location.LocationID == locationID
                ).ToList();
        }

        public List<Location> GetAllLocations()
        {
            return db.Locations.ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public bool CustomerInDB(Customer customer)
        {
            return db.Customers.Where(
                c => c.Email == customer.Email
                ).Any();
        }

        public Customer GetCustomer(Customer customer)
        {
            return db.Customers.Where(
                c => c.Email == customer.Email
                && c.Password == customer.Password
                ).FirstOrDefault();
        }

        public List<Inventory> GetInventory(Location location)
        {
            return db.Inventories.Where(
                i => i.Location.LocationID == location.LocationID
                ).ToList();
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProduct(int productID)
        {
            return db.Products.Where(
                p => p.ProductID == productID)
                .FirstOrDefault();
        }
    }
}
