﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using StringLibrary;

// Homework 3
namespace StringLibrary
{

	public class FlowerShopBusiness
	{
        public OrderList OrderList { get; set; }
        public CustomerList CustomerList { get; set; }
        public FlowerProductList ProductList { get; set; }
        public const string FIREBASE_PROJID = "flowerorderdatabase"; // ID firebase floral fusion
        public FirestoreDb db;

        public FlowerShopBusiness()
        {
            OrderList = new OrderList();
            CustomerList = new CustomerList();
            ProductList = new FlowerProductList();
        }

        public void initFirestore()
        {
            FirebaseApp.Create();
            db = FirestoreDb.Create(FIREBASE_PROJID);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", FIREBASE_PROJID);
        }

        public async Task SaveOrder(Order order)
        {
            CollectionReference collectionRef = db.Collection("orders");
            DocumentReference docRef = collectionRef.Document(order.OrderID.ToString());

            var arrangements = new List<Dictionary<string, object>>();
            foreach (var arrangement in order.Arrangements)
            {
                var flowers = new List<Dictionary<string, object>>();
                foreach (var flower in arrangement.Flowers)
                {
                    flowers.Add(new Dictionary<string, object>
                {
                    { "ProductID", flower.ProductID },
                    { "Name", flower.Name },
                    { "Price", Convert.ToDouble(flower.Price) }
                }
                    );
                }

                arrangements.Add(new Dictionary<string, object>
            {
                { "Size", arrangement.Size.ToString() },
                { "Flowers", flowers }
            });
            }

            Dictionary<string, object> values = new Dictionary<string, object>
        {
            { "OrderID", order.OrderID },
            { "Customer", new Dictionary<string, object>
                {
                    { "CustomerID", order.Customer.CustomerID },
                    { "Name", order.Customer.Name },
                    { "Address", order.Customer.Address },
                    { "TelephoneNumber", order.Customer.TelephoneNumber }
                }
            },
            { "Arrangements", arrangements },
            { "Status", order.Status.ToString() },
            { "PersonalizedMessage", order.PersonalizedMessage?.Content },
            { "Total",  Convert.ToDouble(order.CalculateTotal()) }
        };

            await docRef.SetAsync(values);
        }

        public async Task<Order> GetOrder(int orderId)
        {
            DocumentReference docRef = db.Collection("orders").Document(orderId.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (!snapshot.Exists)
                return null;

            Dictionary<string, object> data = snapshot.ToDictionary();

            // Create customer
            var customerData = (Dictionary<string, object>)data["Customer"];
            Customer customer = new Customer(
                int.Parse(customerData["CustomerID"].ToString()),
                customerData["Name"].ToString(),
                customerData["Address"].ToString(),
                customerData["TelephoneNumber"].ToString()
            );

            // Create order
            Order order = new Order(customer, int.Parse(data["OrderID"].ToString()));

            // Add arrangements
            var arrangements = (List<object>)data["Arrangements"];
            foreach (Dictionary<string, object> arrangementData in arrangements)
            {
                Size size = (Size)Enum.Parse(typeof(Size), arrangementData["Size"].ToString());
                FlowerArrangement arrangement = new FlowerArrangement(size);

                var flowers = (List<object>)arrangementData["Flowers"];
                foreach (Dictionary<string, object> flowerData in flowers)
                {
                    FlowerProduct flower = new FlowerProduct(
                        flowerData["Name"].ToString(),
                        decimal.Parse(flowerData["Price"].ToString()),
                        int.Parse(flowerData["ProductID"].ToString())
                    );
                    arrangement.AddFlower(flower);
                }

                order.AddArrangement(arrangement);
            }

            // Set status
            order.UpdateStatus((OrderStatus)Enum.Parse(typeof(OrderStatus), data["Status"].ToString()));

            // Add message if exists
            if (data.ContainsKey("PersonalizedMessage") && data["PersonalizedMessage"] != null)
            {
                order.AddPersonalizedMessage(data["PersonalizedMessage"].ToString());
            }

            return order;
        }

        public async Task DeleteOrder(int orderId)
        {
            DocumentReference docRef = db.Collection("orders").Document(orderId.ToString());
            await docRef.DeleteAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            Query ordersQuery = db.Collection("orders");
            QuerySnapshot querySnapshot = await ordersQuery.GetSnapshotAsync();

            List<Order> orders = new List<Order>();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                int orderId = int.Parse(documentSnapshot.Id);
                Order order = await GetOrder(orderId);
                if (order != null)
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        public async Task<List<Order>> GetOrdersByStatus(OrderStatus status)
        {
            Query ordersQuery = db.Collection("orders").WhereEqualTo("Status", status.ToString());
            QuerySnapshot querySnapshot = await ordersQuery.GetSnapshotAsync();

            List<Order> orders = new List<Order>();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                int orderId = int.Parse(documentSnapshot.Id);
                Order order = await GetOrder(orderId);
                if (order != null)
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        public async Task RestoreOrders()
        {
            Query collectionQuery = db.Collection("orders");
            QuerySnapshot allQuerySnapshot = await collectionQuery.GetSnapshotAsync();

            OrderList.Clear(); // Clear the existing list before restoring

            foreach (DocumentSnapshot documentSnapshot in allQuerySnapshot.Documents)
            {
                Dictionary<string, object> data = documentSnapshot.ToDictionary();
                //datatype //property = //datatype.parse(data["varName"].ToString());
                int OrderID = int.Parse(data["OrderID"].ToString());
                Message PersonalizedMessage = new Message(data["PersonalizedMessage"].ToString());
                OrderStatus Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), data["Status"].ToString());

                string name = data["Name"].ToString();
                string address = data["Address"].ToString();
                string telephoneNumber = data["TelephoneNumber"].ToString();
                int customerID = int.Parse(data["customerID"].ToString());
                Customer customer = new Customer(customerID, name, address, telephoneNumber);    

                FlowerProduct flower = new FlowerProduct();
                flower.Name = data["Name"].ToString();
                flower.Price = decimal.Parse(data["Price"].ToString());
                flower.ProductID = int.Parse(data["ProductID"].ToString());

                Size size = (Size)Enum.Parse(typeof(Size), data["Size"].ToString());
                FlowerArrangement arrangement = new FlowerArrangement(size);
                arrangement.Flowers.Add(flower);

                Order order = new Order(customer, OrderID)
                {
                    PersonalizedMessage = PersonalizedMessage,
                    Status = Status
                };
                order.Arrangements.Add(arrangement); 

                OrderList.AddOrder(order);

            }
        }

    }
}
// Extract and create the customer
/*var customerData = (Dictionary<string, object>)data["Customer"];
Customer customer = new Customer(
    int.Parse(customerData["CustomerID"].ToString()),
    customerData["Name"].ToString(),
    customerData["Address"].ToString(),
    customerData["TelephoneNumber"].ToString()
);

// Create the order
Order order = new Order(customer, int.Parse(data["OrderID"].ToString()));

// Extract and add arrangements to the order
var arrangementsData = (List<object>)data["Arrangements"];
foreach (Dictionary<string, object> arrangementData in arrangementsData)
{
    Size size = (Size)Enum.Parse(typeof(Size), arrangementData["Size"].ToString());
    FlowerArrangement arrangement = new FlowerArrangement(size);

    var flowersData = (List<object>)arrangementData["Flowers"];
    foreach (Dictionary<string, object> flowerData in flowersData)
    {
        FlowerProduct flower = new FlowerProduct(
            flowerData["Name"].ToString(),
            decimal.Parse(flowerData["Price"].ToString()),
            int.Parse(flowerData["ProductID"].ToString())
        );
        arrangement.AddFlower(flower);
    }

    order.AddArrangement(arrangement);
}

// Update the order status
order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), data["Status"].ToString());

// Add a personalized message if available
if (data.ContainsKey("PersonalizedMessage") && data["PersonalizedMessage"] != null)
{
    order.AddPersonalizedMessage(data["PersonalizedMessage"].ToString());
}
*/
// Add the order to the OrderList