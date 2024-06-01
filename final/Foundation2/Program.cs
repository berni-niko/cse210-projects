using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // Create Address instances
        Address address1 = new Address("1 Addy1 St", "Los Angles", "CA", "USA");
        Address address2 = new Address("2 Addy2 St", "Hamilton", "WK", "New Zealand");

        // Create Customer instances
        Customer customer1 = new Customer("Nic Tomu", address1);
        Customer customer2 = new Customer("Name2", address2);

        // Create Product instances
        Product product1 = new Product("Item1", "I123", 10.00m, 2);
        Product product2 = new Product("Itme2", "I456", 15.00m, 1);
        Product product3 = new Product("Item 3", "I789", 20.00m, 3);
        Product product4 = new Product("Item 4", "I12", 5.00m, 5);

        // Create Order instances
        List<Product> order1Products = new List<Product> { product1, product2 };
        List<Product> order2Products = new List<Product> { product3, product4 };

        Order order1 = new Order(order1Products, customer1);
        Order order2 = new Order(order2Products, customer2);

                // Display results for Order 1
        DisplayOrderDetails(order1, "Order1");

        // Display results for Order 2
        DisplayOrderDetails(order2, "Order2");

    }

           static void DisplayOrderDetails(Order order, string orderName)
    {
        // Print Total Cost
        Console.WriteLine($"{orderName} Total Cost: {order.CalculateTotalCost():C}");
        
        // Print Packing Label
        Console.WriteLine("Packing Label");
        Console.WriteLine(new string('=', 20));
        Console.WriteLine(order.GetPackingLabel());

        // Print Shipping Label
        Console.WriteLine("Shipping Label");
        Console.WriteLine(new string('=', 20));
        Console.WriteLine(order.GetShippingLabel());
    }
        
}



