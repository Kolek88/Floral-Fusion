using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloralFusion
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public List<FlowerProduct> FlowerProducts { get; set; }

        public Order(int orderId, Customer customer)
        {
            OrderID = orderId;
            Customer = customer;
            FlowerProducts = new List<FlowerProduct>();
        }

        public void AddFlowerProduct(FlowerProduct flower)
        {
            FlowerProducts.Add(flower);
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var product in FlowerProducts)
            {
                total += product.Price;
            }
            return total;
        }
    }
}