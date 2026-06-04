using System;

class Program
{
    static void Main(string[] args)

    {
        //Order within the USA
        Address address1 = new Address(
            "1475 W 400 S",
            "Salt Lake City",
            "Utah",
            "USA");

        Customer customer1 = new Customer("Nicholas Myra", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P100", 800, 1));
        order1.AddProduct(new Product("Mouse", "P101", 25, 2));
        order1.AddProduct(new Product("Keyboard", "P102", 50, 1));

        Console.WriteLine("Order 1");
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost()}");


        Console.WriteLine("\n----------------------\n");



        //Order outside the USA
        Address address2 = new Address(
            "1475 Maple Road",
            "Toronto",
            "Ontario",
            "Canada");

        Customer customer2 = new Customer("Michael Myers", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Headphones", "P200", 75, 1));
        order2.AddProduct(new Product("Webcam", "P201", 60, 2));
        order2.AddProduct(new Product("Mousepad", "P202", 10, 1));

        Console.WriteLine("Order 2");
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost()}");


    }
}