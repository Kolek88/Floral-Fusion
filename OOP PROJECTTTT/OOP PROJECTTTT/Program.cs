using FloralFusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floral_Fusion
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Create a FlowerProductList to hold all the flowers available
            FlowerProductList productList = new FlowerProductList();
            // Add some initial flowers
            productList.AddFlowerProduct(new FlowerProduct(1, "Rose", 2.50));
            productList.AddFlowerProduct(new FlowerProduct(2, "Tulip", 1.50));
            productList.AddFlowerProduct(new FlowerProduct(3, "Daisy", 1.00));

            // Display available flowers
            Console.WriteLine("Available Flowers:");
            foreach (var product in productList.FlowerProducts)
            {
                Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: ${product.Price}");
            }

            // Create a customer
            Console.Write("\nEnter customer name: ");
            string customerName = Console.ReadLine();
            Customer customer = new Customer(1, customerName);

            // Create an order
            Order order = new Order(1, customer);

            // Allow the user to select flowers to add to the order
            while (true)
            {
                Console.Write("\nEnter Flower ID to add to the order (or 0 to finish): ");
                int flowerId = int.Parse(Console.ReadLine());

                if (flowerId == 0) break;  // Exit the loop when done

                // Find the flower in the list
                FlowerProduct selectedFlower = productList.FlowerProducts.Find(f => f.ProductID == flowerId);
                if (selectedFlower != null)
                {
                    order.AddFlowerProduct(selectedFlower);
                    Console.WriteLine($"{selectedFlower.Name} added to your order.");
                }
                else
                {
                    Console.WriteLine("Invalid Flower ID. Please try again.");
                }
            }

            // Display order summary
            Console.WriteLine($"\nOrder Summary for {customer.Name}:");
            foreach (var product in order.FlowerProducts)
            {
                Console.WriteLine($"- {product.Name}: ${product.Price}");
            }
            Console.WriteLine($"Total Price: ${order.CalculateTotal()}");

            // Complete the transaction
            Transaction transaction = new Transaction(1, order.CalculateTotal());
            Console.WriteLine($"Transaction Completed. Amount Charged: ${transaction.Amount}");
        }
    }
}

