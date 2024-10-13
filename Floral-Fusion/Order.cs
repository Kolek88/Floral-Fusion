using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_Fusion
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<FlowerArrangement> Arrangements { get; set; }
        public int OrderID { get; set; }
        public Message PersonalizedMessage { get; set; }
        public OrderStatus Status { get; set; }

        public Order(Customer customer, int orderID)
        {
            Customer = customer;
            OrderID = orderID;
            Arrangements = new List<FlowerArrangement>();
            Status = OrderStatus.Pending; // Default status
        }

        public void AddArrangement(FlowerArrangement arrangement)
        {
            Arrangements.Add(arrangement);
        }

        public void AddPersonalizedMessage(string messageContent)
        {
            PersonalizedMessage = new Message(messageContent);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var arrangement in Arrangements)
            {
                total += arrangement.CalculateTotal();
            }
            return total;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}

