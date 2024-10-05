using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class CustomerList
    {
        private List<Customer> customers;

        public CustomerList(string v)
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void DisplayCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers to display.");
                return;
            }

            // Update the header to include all fields: Name, Email, Address, Phone
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("{0,-20} {1,-30} {2,-40} {3,-15}", "Name", "Email", "Address", "Phone Number");
            Console.WriteLine(new string('-', 105));

            // Print each customer's details in the same format
            foreach (var customer in customers)
            {
                Console.WriteLine("{0,-20} {1,-30} {2,-40} {3,-15}", customer.Name, customer.Email, customer.Address, customer.Phone);
            }
        }
    }
}
