using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Address instances
        Address address1 = new Address("1 Addy1 St", "Springfield", "IL", "USA");
        Address address2 = new Address("2 Addy2 St", "Hamilton", "WK", "New Zealand");

        // Create Customer instances
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

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

        // Call methods and display results for Order 1
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Cost:");
        Console.WriteLine(order1.CalculateTotalCost());
        Console.WriteLine(new string('-', 20));
        

        // Call methods and display results for Order 2
        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Cost:");
        Console.WriteLine(order2.CalculateTotalCost());
        Console.WriteLine(new string('-', 20));
        
    }


}
