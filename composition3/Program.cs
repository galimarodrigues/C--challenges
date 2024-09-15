using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Birth date (DD/MM/YYYY): ");
            string birthDateString = Console.ReadLine() ?? string.Empty;
            DateTime birthDate;
            if (!DateTime.TryParseExact(birthDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            string statusString = Console.ReadLine() ?? string.Empty;
            if (!Enum.TryParse(statusString, out OrderStatus status))
            {
                Console.WriteLine("Invalid order status.");
                return;
            }

            Client client = new Client(clientName, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            string itemCountString = Console.ReadLine() ?? "0";
            if (!int.TryParse(itemCountString, out int n))
            {
                Console.WriteLine("Invalid number of items.");
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine() ?? string.Empty;
                Console.Write("Product price: ");
                string priceString = Console.ReadLine() ?? "0";
                if (!double.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
                {
                    Console.WriteLine("Invalid price format.");
                    return;
                }

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                string quantityString = Console.ReadLine() ?? "0";
                if (!int.TryParse(quantityString, out int quantity))
                {
                    Console.WriteLine("Invalid quantity format.");
                    return;
                }

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}