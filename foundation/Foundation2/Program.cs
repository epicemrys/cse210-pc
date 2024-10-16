using System;
using System.Collections.Generic;

// Address class defined
class Address
{
   private string streetAddress;
   private string city;
   private string state;
   private string country;

   // Address class constructor
   public Address(string street, string city, string state, string country)
   {
       this.streetAddress = street;
       this.city = city;
       this.state = state;
       this.country = country;
   }

   // Check if address is in the USA
   public bool IsInUSA()
   {
       return country == "USA";
   }

   // Return all address fields
   public string GetAddressInfo()
   {
       return $"{streetAddress}\n{city}, {state}, {country}";
   }
}

// Define the Customer class here
class Customer
{
   private string name;
   private Address address;

   // Customer class constructor
   public Customer(string name, Address address)
   {
       this.name = name;
       this.address = address;
   }

   // Check if customer is in the USA based on address
   public bool IsInUSA()
   {
       return address.IsInUSA();
   }

   // Get customer name
   public string GetName()
   {
       return name;
   }

   // Get customer address
   public Address GetAddress()
   {
       return address;
   }
}

// Define the Product class
class Product
{
   private string name;
   private int productId;
   private double price;
   private int quantity;

   // Product class constructor
   public Product(string name, int productId, double price, int quantity)
   {
       this.name = name;
       this.productId = productId;
       this.price = price;
       this.quantity = quantity;
   }

   // Calculate total cost for the product
   public double CalculateTotalCost()
   {
       return price * quantity;
   }

   // Get product name
   public string GetName()
   {
       return name;
   }

   // Get product ID
   public int GetProductId()
   {
       return productId;
   }
}

// Order class defined
class Order
{
   private List<Product> products;
   private Customer customer;
   private double shippingCost = 0;

   // Constructors
   public Order(Customer customer)
   {
       products = new List<Product>();
       this.customer = customer;

       // Determine shipping cost based on customer's location
       if (customer.IsInUSA())
       {
           shippingCost = 5;
       }
       else
       {
           shippingCost = 35;
       }
   }

   // Add a product to the order
   public void AddProduct(Product product)
   {
       products.Add(product);
   }

   // Calculate total cost of the order
   public double CalculateTotalOrderCost()
   {
       double totalCost = 0;

       foreach (Product product in products)
       {
           totalCost += product.CalculateTotalCost();
       }

       return totalCost + shippingCost;
   }

   // Get packing label
   public string GetPackingLabel()
   {
       string packingLabel = "Packing Label:\n";
       foreach (Product product in products)
       {
           packingLabel += $"{product.GetName()} - Product ID: {product.GetProductId()}\n";
       }
       return packingLabel;
   }

   // Get shipping label
   public string GetShippingLabel()
   {
       string shippingLabel = "Shipping Label:\n";
       shippingLabel += $"{customer.GetName()}\n";
       shippingLabel += customer.GetAddress().GetAddressInfo();
       return shippingLabel;
   }
}

class Program
{
   static void Main()
   {
       // Create Address instances
       Address address1 = new Address("123 Main St", "Anytown", "UT", "USA");
       Address address2 = new Address("456 Elm St", "Othertown", "TX", "USA");

       // Create Customer instances
       Customer customer1 = new Customer("Joseph Smith", address1);
       Customer customer2 = new Customer("Brigham Young", address2);

       // Create Product instances
       Product product1 = new Product("Laptop", 1001, 899.99, 1);
       Product product2 = new Product("Mouse", 2001, 19.99, 2);
       Product product3 = new Product("Keyboard", 3001, 49.99, 1);

       // Create Order instances
       Order order1 = new Order(customer1);
       Order order2 = new Order(customer2);

       // Add products to orders
       order1.AddProduct(product1);
       order1.AddProduct(product2);
       order2.AddProduct(product2);
       order2.AddProduct(product3);

       // Display results
       Console.WriteLine(order1.GetPackingLabel());
       Console.WriteLine(order1.GetShippingLabel());
       Console.WriteLine($"Total Price: ${order1.CalculateTotalOrderCost()}");

       Console.WriteLine("\n");

       Console.WriteLine(order2.GetPackingLabel());
       Console.WriteLine(order2.GetShippingLabel());
       Console.WriteLine($"Total Price: ${order2.CalculateTotalOrderCost()}");
   }
}