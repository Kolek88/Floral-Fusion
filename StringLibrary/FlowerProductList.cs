using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLibrary
{
    public class FlowerProductList
    {
        public List<FlowerProduct> AvailableFlowers { get; private set; }

        public FlowerProductList()
        {
            AvailableFlowers = new List<FlowerProduct>
        {
            new FlowerProduct("Rose", 5.99m, 1),
            new FlowerProduct("Tulip", 4.99m, 2),
            new FlowerProduct("Sunflower", 3.99m, 3),
            new FlowerProduct("Lily", 6.99m, 4),
            new FlowerProduct("Daisy", 3.49m, 5),
            new FlowerProduct("Orchid", 8.99m, 6),
            new FlowerProduct("Carnation", 4.49m, 7),
            new FlowerProduct("Peony", 7.99m, 8),
            new FlowerProduct("Hydrangea", 6.49m, 9),
            new FlowerProduct("Chrysanthemum", 4.99m, 10),
            new FlowerProduct("Gerbera", 5.49m, 11),
            new FlowerProduct("Lavender", 3.99m, 12)
        };
        }

        public FlowerProduct GetFlowerProduct(int productID)
        {
            return AvailableFlowers.Find(p => p.ProductID == productID);
        }
    }
}
