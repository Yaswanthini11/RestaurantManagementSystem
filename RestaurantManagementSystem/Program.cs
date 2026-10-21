
using System;
using RestaurantManagementSystem.Services;

namespace RestaurantManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonDataService jsonService = new JsonDataService();
            AppData data = jsonService.LoadData();

            CustomerService customerService = new CustomerService(data, jsonService);

            int choice = 0;

            do
            {
                Console.WriteLine("\n===== CUSTOMER MANAGEMENT =====");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Display Customers");
                Console.WriteLine("3. Search Customer");
                Console.WriteLine("4. Update Customer");
                Console.WriteLine("5. Delete Customer");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        customerService.AddCustomer();
                        break;

                    case 2:
                        customerService.DisplayCustomers();
                        break;

                    case 3:
                        customerService.SearchCustomer();
                        break;

                    case 4:
                        customerService.UpdateCustomer();
                        break;

                    case 5:
                        customerService.DeleteCustomer();
                        break;

                    case 0:
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
