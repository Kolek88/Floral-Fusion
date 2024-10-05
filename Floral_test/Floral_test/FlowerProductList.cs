using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class FlowerProductList
    {
        public List<FlowerProduct> FlowerProducts { get; set; }

        public FlowerProductList()
        {
            FlowerProducts = new List<FlowerProduct>();
        }

        public void AddFlowerProduct(FlowerProduct product)
        {
            FlowerProducts.Add(product);
        }

        public void RemoveFlowerProduct(FlowerProduct product)
        {
            FlowerProducts.Remove(product);
        }
    }
}
