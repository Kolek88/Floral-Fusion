using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var flowerSelector = new FlowerSelector();
            CustomerList customerList = new CustomerList("");
            //
            var order = new Order { Customer = Customer };

            while (true)
            {
                Console.WriteLine("Choose a bouquet size:");
                Console.WriteLine("1. Small (3 flowers)");
                Console.WriteLine("2. Medium (5 flowers)");
                Console.WriteLine("3. Large (10 flowers)");
                Console.WriteLine("4. Finish order");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    SizeFlower.Size size;
                    int flowerCount;

                    switch (choice)
                    {
                        case 1:
                            size = SizeFlower.Size.Small;
                            flowerCount = 3;
                            break;
                        case 2:
                            size = SizeFlower.Size.Medium;
                            flowerCount = 5;
                            break;
                        case 3:
                            size = SizeFlower.Size.Large;
                            flowerCount = 10;
                            break;
                        case 4:
                            goto FinishOrder;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            continue;
                    }

                    Console.WriteLine($"Creating a {size} bouquet. Please choose {flowerCount} flowers.");
                    var selectedFlowers = flowerSelector.SelectFlowers(flowerCount);
                    var arrangement = new SizeFlower(size, selectedFlowers);
                    order.AddArrangement(arrangement);
                    Console.WriteLine($"Added {size} bouquet to your order. Price: {arrangement.Price:C}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }

            FinishOrder:
            Console.WriteLine("\nOrder Details:");
            foreach (var arrangement in order.Arrangements)
            {
                Console.WriteLine($"- {arrangement.ArrangementSize} Arrangement: {arrangement.Price:C}");
                Console.WriteLine("  Flowers:");
                foreach (var flower in arrangement.Flowers)
                {
                    Console.WriteLine($"    {flower.Name}: {flower.Price:C}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Total Order Price: {order.CalculateTotal():C}");

            
           
        }
    }
}
