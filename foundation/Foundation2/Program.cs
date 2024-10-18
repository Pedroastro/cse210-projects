using System;

class Program
{
    static void Main(string[] args)
    {
        Address testAdress = new Address("123 Sesame Street", "New York", "NY", "USA");
        Customer me = new Customer("Pedro", testAdress);
        List<Product> productsOrder1 = new List<Product>();
        Product product1order1 = new Product("Cookie", "MonsterCookie", 5, 15);
        Product product2order1 = new Product("Elmo", "ElmoPlush", 15, 5);
        Product product3order1 = new Product("Big Bird", "BigBirdFeather", 25, 2);
        productsOrder1.Add(product1order1);
        productsOrder1.Add(product2order1);
        productsOrder1.Add(product3order1);
        Order order1 = new Order(me, productsOrder1);

        List<Product> productsOrder2 = new List<Product>();
        Product product1order2 = new Product("Oscar", "OscarGarbageCan", 10, 3);
        Product product2order2 = new Product("Bert", "BertPigeon", 8, 7);
        Product product3order2 = new Product("Ernie", "ErnieRubberDuckie", 12, 4);
        productsOrder2.Add(product1order2);
        productsOrder2.Add(product2order2);
        productsOrder2.Add(product3order2);
        Order order2 = new Order(me, productsOrder2);

        Console.Write($"Packing Label:\n{order1.GetPackingLabel()}");
        Console.Write($"Shipping Label:\n{order1.GetShippingLabel()}\n");
        Console.WriteLine($"Total Price: {order1.CalculateTotalPrice()}");

        Console.Write($"Packing Label:\n{order2.GetPackingLabel()}");
        Console.Write($"Shipping Label:\n{order2.GetShippingLabel()}\n");
        Console.WriteLine($"Total Price: {order2.CalculateTotalPrice()}");
    }
}