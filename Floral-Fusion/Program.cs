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

            Customer customer1 = new Customer(1, "John Doe", "123 Main St, Anytown, AN 12345", "555-123-4567");
            customerList.AddCustomer(customer1);

            Order order1 = new Order(customer1, 1);

            FlowerArrangement smallArrangement = new FlowerArrangement(Size.Small);
            smallArrangement.AddFlower(productList.GetFlowerProduct(1)); // Rose
            smallArrangement.AddFlower(productList.GetFlowerProduct(2)); // Tulip
            smallArrangement.AddFlower(productList.GetFlowerProduct(3)); // Sunflower

            order1.AddArrangement(smallArrangement);
            order1.AddPersonalizedMessage("Happy Birthday, Mom! Love, John");

            orderList.AddOrder(order1);

            Console.WriteLine($"Order 1 total: ${order1.CalculateTotal()}");
            Console.WriteLine($"Order 1 status: {order1.Status}");
            Console.WriteLine($"Personalized Message: {order1.PersonalizedMessage.Content}");
            Console.WriteLine($"Customer: {order1.Customer.Name}");
            Console.WriteLine($"Address: {order1.Customer.Address}");
            Console.WriteLine($"Telephone: {order1.Customer.TelephoneNumber}");

            // Update order status
            orderList.UpdateOrderStatus(1, OrderStatus.Ongoing);
            Console.WriteLine($"Updated Order 1 status: {orderList.GetOrder(1).Status}");

            // Add another order
            Customer customer2 = new Customer(2, "Jane Smith", "456 Elm St, Othertown, OT 67890", "555-987-6543");
            customerList.AddCustomer(customer2);

            Order order2 = new Order(customer2, 2);
            FlowerArrangement mediumArrangement = new FlowerArrangement(Size.Medium);
            for (int i = 4; i <= 8; i++)
            {
                mediumArrangement.AddFlower(productList.GetFlowerProduct(i));
            }
            order2.AddArrangement(mediumArrangement);
            order2.AddPersonalizedMessage("Congratulations on your promotion! Best wishes, Jane");

            orderList.AddOrder(order2);

            // Display all pending orders
            List<Order> pendingOrders = orderList.GetOrdersByStatus(OrderStatus.Pending);
            Console.WriteLine($"\nPending Orders: {pendingOrders.Count}");
            foreach (var order in pendingOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Customer: {order.Customer.Name}, Address: {order.Customer.Address}, Telephone: {order.Customer.TelephoneNumber}, Total: ${order.CalculateTotal()}");
            }
        }
    }
}
