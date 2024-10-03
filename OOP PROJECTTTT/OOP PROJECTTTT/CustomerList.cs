using FloralFusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFc_fw
{
    internal class CustomerList
    {
        public List<Customer> Customers { get; set; }

        public CustomerList()
        {
            Customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public Customer GetCustomer(int customerId)
        {
            return Customers.Find(c => c.CustomerID == customerId);
        }
    }
}
