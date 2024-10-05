using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    public class FlowerSelector
    {
        private List<FlowerProduct> availableFlowers;

        public FlowerSelector()
        {
            availableFlowers = new List<FlowerProduct>
        {
            new FlowerProduct { Name = "Rose", Price = 5.99m, ProductID = "F001" },
            new FlowerProduct { Name = "Tulip", Price = 4.99m, ProductID = "F002" },
            new FlowerProduct { Name = "Lily", Price = 6.99m, ProductID = "F003" },
            new FlowerProduct { Name = "Daisy", Price = 3.99m, ProductID = "F004" },
            new FlowerProduct { Name = "Sunflower", Price = 5.49m, ProductID = "F005" },
            new FlowerProduct { Name = "Carnation", Price = 4.49m, ProductID = "F006" },
            new FlowerProduct { Name = "Orchid", Price = 7.99m, ProductID = "F007" },
            new FlowerProduct { Name = "Chrysanthemum", Price = 4.79m, ProductID = "F008" }
        };
        }

        public void DisplayAvailableFlowers()
        {
            Console.WriteLine("Available Flowers:");
            for (int i = 0; i < availableFlowers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableFlowers[i].Name} - {availableFlowers[i].Price:C}");
            }
        }

        public List<FlowerProduct> SelectFlowers(int count)
        {
            List<FlowerProduct> selectedFlowers = new List<FlowerProduct>();

            for (int i = 0; i < count; i++)
            {
                DisplayAvailableFlowers();
                Console.Write($"Choose flower {i + 1} (enter the number): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= availableFlowers.Count)
                {
                    selectedFlowers.Add(availableFlowers[choice - 1]);
                    Console.WriteLine($"Added {availableFlowers[choice - 1].Name} to your bouquet.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    i--; // Decrement to retry this selection
                }
                Console.WriteLine();
            }

            return selectedFlowers;
        }
    }
}

