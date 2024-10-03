using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloralFusion
{
    public class FlowerProductList
    {
        public List<FlowerProduct> FlowerProducts { get; set; }

        public FlowerProductList()
        {
            FlowerProducts = new List<FlowerProduct>();
        }

        public void AddFlowerProduct(FlowerProduct flower)
        {
            FlowerProducts.Add(flower);
        }
    }
}