
using System;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class CustomerService
    {
        private AppData data;
        private JsonDataService jsonService;

        public CustomerService(AppData data, JsonDataService jsonService)
        {
            this.data = data;
            this.jsonService = jsonService;
        }

        public void AddCustomer()
        {
            Customer cus = new Customer();

            Console.Write("Enter Customer id: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid id");
                return;
            }

            foreach (Customer c in data.Customers)
            {
                if (c.CustomerId == id)
                {
                    Console.WriteLine("already exists");
                    return;
                }
            }

            cus.CustomerId = id;

            Console.Write("Enter Name: ");
            cus.FullName = Console.ReadLine() ?? "";

            Console.Write("Enter Phone: ");
            cus.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Enter Email: ");
            cus.Email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cus.FullName) ||
                string.IsNullOrWhiteSpace(cus.PhoneNumber))
            {
                Console.WriteLine("Name and ph no cannot be empty");
                return;
            }

            data.Customers.Add(cus);
            jsonService.SaveData(data);

            Console.WriteLine("Customer added.");
        }

        public void DisplayCustomers()
        {
            foreach (Customer c in data.Customers)
            {
                Console.WriteLine("ID: " + c.CustomerId);
                Console.WriteLine("Name: " + c.FullName);
                Console.WriteLine("Phone: " + c.PhoneNumber);
                Console.WriteLine("Email: " + c.Email);
                Console.WriteLine();
            }
        }

        public void SearchCustomer()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine() ?? "";
            bool found = false;

            foreach (Customer c in data.Customers)
            {
                if (c.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(c.CustomerId + " " + c.FullName + " " + c.PhoneNumber);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            foreach (Customer c in data.Customers)
            {
                if (c.CustomerId == id)
                {
                    Console.Write("Enter new name: ");
                    c.FullName = Console.ReadLine() ?? "";

                    Console.Write("Enter new phone: ");
                    c.PhoneNumber = Console.ReadLine() ?? "";

                    Console.Write("Enter new email: ");
                    c.Email = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(c.FullName) ||
                        string.IsNullOrWhiteSpace(c.PhoneNumber))
                    {
                        Console.WriteLine("Name and phone cannot be empty.");
                        return;
                    }

                    jsonService.SaveData(data);
                    Console.WriteLine("Customer updated.");
                    return;
                }
            }

            Console.WriteLine("Customer not found.");
        }

        public void DeleteCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            foreach (Order order in data.Orders)
            {
                if (order.CustomerId == id)
                {
                    Console.WriteLine("Customer has order history. Cannot delete.");
                    return;
                }
            }

            Customer fc = null;

            foreach (Customer c in data.Customers)
            {
                if (c.CustomerId == id)
                {
                    fc = c;
                    break;
                }
            }

            if (fc == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            data.Customers.Remove(fc);
            jsonService.SaveData(data);

            Console.WriteLine("Customer deleted.");
        }
    }
}
