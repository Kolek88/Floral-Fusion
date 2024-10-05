using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<FlowerArrangement> Arrangements { get; set; }
        public DateTime OrderDate { get; set; }

        public Order()
        {
            Arrangements = new List<FlowerArrangement>();
            OrderDate = DateTime.Now;
        }

        public void AddArrangement(FlowerArrangement arrangement)
        {
            Arrangements.Add(arrangement);
        }

        public decimal CalculateTotal()
        {
            return Arrangements.Sum(a => a.Price);
        }
    }
}
