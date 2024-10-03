using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloralFusion
{
    public class FlowerProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public FlowerProduct(int productId, string name, double price)
        {
            ProductID = productId;
            Name = name;
            Price = price;
        }
    }
}