using Customer_CustomerListFF;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        CustomerList customerList = new CustomerList();

        // Get user input to add customers
        while (true)
        {
            Console.Write("Enter customer name (or type 'exit' to finish): ");
            string name = Console.ReadLine();
            if (name.ToLower() == "exit")
                break;

            Console.Write("Enter customer email: ");
            string email = Console.ReadLine();

            Console.Write("Enter customer address: ");
            string address = Console.ReadLine();

            Console.Write("Enter customer phone: ");
            string phone = Console.ReadLine();

            // Add the customer with name, email, address, and phone
            customerList.AddCustomer(new Customer(name, email, address, phone));
        }

        // Display the customer details
        customerList.DisplayCustomers();
    }
}
