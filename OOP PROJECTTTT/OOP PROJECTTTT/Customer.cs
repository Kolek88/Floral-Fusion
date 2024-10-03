using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FloralFusion
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(int customerId, string name)
        {
            CustomerID = customerId;
            Name = name;
            Orders = new List<Order>();
        }
    }
}