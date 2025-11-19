using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== ORDER 1 =====
        Address address1 = new Address("123 Main St", "Miami", "FL", "USA");
        Customer customer1 = new Customer("Dany Jimenez", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Mouse", "P001", 15.50, 2));
        order1.AddProduct(new Product("Keyboard", "P002", 30.00, 1));

        // ===== ORDER 2 =====
        Address address2 = new Address("Avenida Central", "San José", "CR", "Costa Rica");
        Customer customer2 = new Customer("Juan Perez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "P010", 120.00, 1));
        order2.AddProduct(new Product("USB Cable", "P011", 5.00, 3));

        // ===== DISPLAY OUTPUT =====
        Console.WriteLine("=========== ORDER 1 ===========");
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("TOTAL:");
        Console.WriteLine("$" + order1.GetTotalCost());


        Console.WriteLine("\n=========== ORDER 2 ===========");
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("TOTAL:");
        Console.WriteLine("$" + order2.GetTotalCost());
    }
}