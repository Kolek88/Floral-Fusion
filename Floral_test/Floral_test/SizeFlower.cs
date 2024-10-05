using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class FlowerArrangement
    {
        public enum Size { Small, Medium, Large }

        public Size ArrangementSize { get; set; }
        public List<FlowerProduct> Flowers { get; set; }
        public decimal Price { get; set; }

        public FlowerArrangement(Size size, List<FlowerProduct> flowers)
        {
            ArrangementSize = size;
            Flowers = flowers;
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            decimal basePrice;
            switch (ArrangementSize)
            {
                case Size.Small:
                    basePrice = 10;
                    break;
                case Size.Medium:
                    basePrice = 15;
                    break;
                case Size.Large:
                    basePrice = 20;
                    break;
                default:
                    basePrice = 0;
                    break;
            }
            Price = basePrice + Flowers.Sum(f => f.Price);
        }
    }
}
