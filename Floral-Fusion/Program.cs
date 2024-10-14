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
            FlowerProductList productList = new FlowerProductList();
            CustomerList customerList = new CustomerList();
            OrderList orderList = new OrderList();

            while (true)
            {
                Console.WriteLine("\nWelcome to the Flower Customization System!");
                Console.WriteLine("1. Create a new order");
                Console.WriteLine("2. View pending orders");
                Console.WriteLine("3. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewOrder(productList, customerList, orderList);
                        break;
                    case "2":
                        ViewPendingOrders(orderList);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateNewOrder(FlowerProductList productList, CustomerList customerList, OrderList orderList)
        {
            // Get customer details
            Console.WriteLine("\nEnter customer details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Telephone number: ");
            string telephoneNumber = Console.ReadLine();

            int customerID = customerList.GetCustomerCount() + 1;
            Customer customer = new Customer(customerID, name, address, telephoneNumber);
            customerList.AddCustomer(customer);

            // Create order
            int orderID = orderList.GetOrderCount() + 1;
            Order order = new Order(customer, orderID);

            // Choose bouquet size
            Console.WriteLine("\nChoose bouquet size:");
            Console.WriteLine("1. Small (3 flowers)");
            Console.WriteLine("2. Medium (5 flowers)");
            Console.WriteLine("3. Large (10 flowers)");
            Console.Write("Enter your choice (1-3): ");
            int sizeChoice = int.Parse(Console.ReadLine());
            Size size = (Size)((sizeChoice - 1) * 2 + 3);

            FlowerArrangement arrangement = new FlowerArrangement(size);

            // Pick flowers
            Console.WriteLine("\nAvailable flowers:");
            foreach (var flower in productList.AvailableFlowers)
            {
                Console.WriteLine($"{flower.ProductID}. {flower.Name} - {flower.GetFormattedPrice()}");
            }

            for (int i = 0; i < (int)size; i++)
            {
                Console.Write($"Choose flower {i + 1} (enter product ID): ");
                int flowerChoice = int.Parse(Console.ReadLine());
                FlowerProduct chosenFlower = productList.GetFlowerProduct(flowerChoice);
                arrangement.AddFlower(chosenFlower);
            }

            order.AddArrangement(arrangement);

            // Add personalized message
            Console.Write("\nEnter a personalized message for the bouquet: ");
            string message = Console.ReadLine();
            order.AddPersonalizedMessage(message);

            // Add order to the list
            orderList.AddOrder(order);

            Console.WriteLine($"\nOrder created successfully. Order ID: {order.OrderID}");
            Console.WriteLine($"Total: RM{order.CalculateTotal():F2}");
        }

        static void ViewPendingOrders(OrderList orderList)
        {
            List<Order> pendingOrders = orderList.GetOrdersByStatus(OrderStatus.Pending);
            Console.WriteLine($"\nPending Orders: {pendingOrders.Count}");
            foreach (var order in pendingOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Customer: {order.Customer.Name}, Address: {order.Customer.Address}, Telephone: {order.Customer.TelephoneNumber}, Total: RM{order.CalculateTotal():F2}");
            }
        }
    }
}
