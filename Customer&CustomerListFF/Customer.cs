using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Customer_CustomerListFF
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public Customer(string name, string email, string address, string phone)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;


        }
    }
}
