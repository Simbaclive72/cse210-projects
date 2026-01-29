using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------
        // ORDER 1 (USA Customer)
        // -------------------------
        Address address1 = new Address("123 Main St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("Simbarashe Musika", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P1001", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "P1003", 49.99, 1));

        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("====================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine();

        // -------------------------
        // ORDER 2 (International Customer)
        // -------------------------
        Address address2 = new Address("45 Samora Machel Ave", "Harare", "Harare", "Zimbabwe");
        Customer customer2 = new Customer("Clive Musika", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P2001", 499.99, 1));
        order2.AddProduct(new Product("Headphones", "P2002", 79.99, 1));

        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("====================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.GetTotalPrice():0.00}");
    }
}
