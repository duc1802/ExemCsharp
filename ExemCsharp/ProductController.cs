using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemCsharp
{
    internal class ProductController
    {
        ProductDBcontext DbContext;
        public ProductController()
        { 
            var productDbOptions = new DbContextOptionsBuilder<ProductDBcontext>()
                .UseSqlServer("Data Source=DESKTOP-BGT6VKJ\\SQLEXPRESS02;Initial Catalog=ExamCsharp;User ID=sa;Password=duc18022003;Encrypt=False")
                .Options;
            this.DbContext = new ProductDBcontext(productDbOptions);
        }
        public void CreateNewProduct()
        {
            Console.Write("Product ID : ");
            string? id = Console.ReadLine();
            Console.Write("Product Name : ");
            string? name = Console.ReadLine();
            Console.Write("Price : ");
            int? price = Convert.ToInt32(Console.ReadLine());

            var product = new Product
            {
                ID = id,
                Name = name,
                Price = (int)price
            };
            try
            {
                DbContext.Products.Add(product);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while saving the entity changes:");
                Console.WriteLine(e.Message);
            }
        }
        public async void GetAllProducts()
        {
            var products = await DbContext.Products.ToListAsync();
            foreach (var item in products)
            {
                Console.WriteLine("\nProduct ID\tProduct Name\t\tPrice");
                Console.WriteLine($"{item.ID}\t\t{item.Name}\t\t\t{"$"+item.Price}");
            }
        }
        public void DeleteProduct()
        {
            Console.Write("Enter id to find product : ");
            string id = Console.ReadLine();

            Product deleteStaff = (Product)DbContext.Products.Where(s => s.ID == id)
                                         .Single();
            try
            {
                DbContext.Products.Remove(deleteStaff);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
