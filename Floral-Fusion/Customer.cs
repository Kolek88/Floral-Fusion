using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_Fusion
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }

        public Customer(int customerID, string name, string address, string telephoneNumber)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            TelephoneNumber = telephoneNumber;
        }
    }

}
