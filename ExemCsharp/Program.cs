// See https://aka.ms/new-console-template for more information
using ExemCsharp;

Console.WriteLine("Hello, World!");
ProductController productController = new ProductController();

bool exit = false;

while (!exit)
{
    Console.Clear();
    Console.WriteLine("Product Management System");
    Console.WriteLine("--------------------------");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Display Product");
    Console.WriteLine("3. Delete Product");
    Console.WriteLine("4. Exit");
    Console.Write("Enter your choice (1-4): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            productController.CreateNewProduct();
            break;
        case "2":
            productController.GetAllProducts();
            break;
        case "3":
            productController.DeleteProduct();
            break;
        case "4":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            Console.ReadLine();
            break;
    }
}
