﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopLibrary
{
	public class FlowerArrangement
	{
		public Size Size { get; set; }
		public List<FlowerProduct> Flowers { get; set; }

		public FlowerArrangement(Size size)
		{
			Size = size;
			Flowers = new List<FlowerProduct>();
		}

        public void AddFlower(FlowerProduct flower)
        {
            if (flower == null)
            {
                throw new ArgumentNullException(nameof(flower), "Flower cannot be null.");
            }
            if (Flowers.Count < (int)Size)
            {
                Flowers.Add(flower);
            }
            else
            {
                throw new InvalidOperationException($"Cannot add more flowers. Maximum capacity ({(int)Size}) reached.");
            }
        }



        public decimal CalculateTotal()
		{
			decimal total = 0;
			foreach (var flower in Flowers)
			{
				total += flower.Price;
			}
			return total;
		}
	}
}
