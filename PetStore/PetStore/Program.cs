using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetStore;
using PetStore.Data;
using PetStore.Logic;
using System.Text.Json;
using System.Text.Json.Serialization;

var services = CreateServiceCollection();

var productLogic = services.GetService<IProductLogic>();

string userInput = DisplayMenuAndGetInput();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a Product in JSON format");
        var userInputAsJson = Console.ReadLine();
        var product = JsonSerializer.Deserialize<Product>(userInputAsJson);
        productLogic.AddProduct(product);
    }
    else if (userInput == "2")
    {
        Console.Write("What is the id of the product you would like to view? ");
        var id = int.Parse(Console.ReadLine());
        var product = productLogic.GetProductById(id);
        Console.WriteLine(JsonSerializer.Serialize(product));
        Console.WriteLine();
    }
    else if (userInput == "3")
    {
        Console.WriteLine("Please add an Order in JSON format");
        var userInputAsJson = Console.ReadLine();
        var order = JsonSerializer.Deserialize<Order>(userInputAsJson);
        productLogic.AddOrder(order);
    }
    else if (userInput == "4")
    {
        Console.Write("What is the id of the order you would like to view? ");
        var id = int.Parse(Console.ReadLine());
        var order = productLogic.GetOrder(id);
        Console.WriteLine(JsonSerializer.Serialize(order));
        Console.WriteLine();
    }
    else if (userInput == "5")
    {
        foreach(var item in productLogic.GetAllProducts())
            Console.WriteLine(JsonSerializer.Serialize(item));
    }

    else if (userInput == "6")
    {
        foreach (var item in productLogic.GetAllOrders())
            Console.WriteLine(JsonSerializer.Serialize(item));
    }
    userInput = DisplayMenuAndGetInput();
}

static string DisplayMenuAndGetInput()
{
    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a product");
    Console.WriteLine("Press 3 to add an order");
    Console.WriteLine("Press 4 to view an order");
    Console.WriteLine("Press 5 to view all products");
    Console.WriteLine("Press 6 to view all orders");
    Console.WriteLine("Type 'exit' to quit");

    return Console.ReadLine();
}

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .AddTransient<IProductRepository, ProductRepository>()
        .AddTransient<IOrderRepository, OrderRepository>()
        .BuildServiceProvider();
}

// { "Products": [ {"ProductId": 2, "Name": "Dog bowl", "Description": "A thing that holds food", "Price": 8.99}, {"ProductId": 2, "Name": "Chew toy", "Description": "A thing that dogs chew", "Price": 2.89} ] }
// {"ProductId": 1, "Name": "Dog toy", "Description": "A thing that a dog plays with", "Price": 8.99}
// {"ProductId": 2, "Name": "Dog bowl", "Description": "A thing that holds food", "Price": 8.99}
// {"Name": "Dog toy", "Description": "A thing that a dog plays with", "Price": 8.99}