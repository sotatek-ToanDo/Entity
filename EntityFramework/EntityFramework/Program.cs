using EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var kq= dbcontext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine($"Tao db {dbname} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong taoj {dbname} thanh cong");
            }
            Console.WriteLine(dbname);
        }
        static void DropDatabase()
        {
            using var dbcontext = new ShopContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine($"Xoa db {dbname} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong xoa {dbname} thanh cong");
            }
            Console.WriteLine(dbname);
        }
        //static void InsertProduct()
        //{
        //    using var dbcontext = new ShopContext();
        //    var products = new object[]
        //    {
        //       new Product(){ProductName = "San pham 3", Provider="cong cty 3"},
        //       new Product(){ProductName = "San pham 4", Provider="cong cty B"},
        //       new Product(){ProductName = "San pham 5", Provider="cong cty C"},
        //    };
        //    dbcontext.AddRange(products);
        //    int number_rows = dbcontext.SaveChanges();
        //    Console.WriteLine($"da chen {number_rows} du lieu");
        //}
        //static void ReadProduct()
        //{
        //    using var dbcontext = new ShopContext();
        //    //LinQ
        //    var products =dbcontext.products.ToList();
        //    products.ForEach(products => products.PrintInfo());
        //    //var qr = from product in dbcontext.products
        //    //         where product.Provider.Contains("cty")
        //    //         orderby product.ProductId 
        //    //         select product;
        //    //qr.ToList().ForEach(product => product.PrintInfo());
        //    //Product product = (from p in dbcontext.products
        //    //                   where p.Provider == "cong cty B"
        //    //                   select p).FirstOrDefault();
        //    //if (product != null) product.PrintInfo();
        //}
        //static void RenameProduct(int id, string newName)
        //{
        //    using var dbcontext = new ShopContext();
        //    Product product = (from p in dbcontext.products
        //                       where p.ProductId == id
        //                       select p).FirstOrDefault();
        //    if (product != null)
        //    {
        //        EntityEntry<Product> entry = dbcontext.Entry(product);
        //        entry.State = EntityState.Detached;

        //        product.ProductName = newName;
        //        int number_rows = dbcontext.SaveChanges();
        //        Console.WriteLine($"cap nhat {number_rows} du lieu");
        //    }
        //}
        //static void DeleteProduct(int id)
        //{
        //    using var dbcontext = new ShopContext();
        //    Product product = (from p in dbcontext.products
        //                       where p.ProductId == id
        //                       select p).FirstOrDefault();
        //    if (product != null)
        //    {
        //        dbcontext.Remove(product);
        //        int number_rows = dbcontext.SaveChanges();
        //        Console.WriteLine($"Delete {number_rows} du lieu");
        //    }
        //}
       static void InsertData()
        {
            using var dbcontext = new ShopContext();
            Category c1 = new Category() { Name = "dien thoai", Description = " Cac loai dien thoai" };
            Category c2= new Category() { Name = "Do uong", Description = " Cac loai do uong" };
            dbcontext.categories.Add(c1);
            dbcontext.categories.Add(c2);

            //var c1 = (from c in dbcontext.categories where c.CategoryId == 1 select c).FirstOrDefault();
            //var c2 = (from c in dbcontext.categories where c.CategoryId == 2 select c).FirstOrDefault();
            dbcontext.Add(new Product() { Name = "Iphone 8", Price = 1000, Category = c1,CateId=1 });
            dbcontext.Add(new Product() { Name = "Iphone X", Price = 2500, Category = c2, Category2 = c2 });
            dbcontext.Add(new Product() { Name = "Iphone 13", Price = 2900, Category = c2});
            dbcontext.Add(new Product() { Name = "Cafe", Price = 900, Category = c2});
            dbcontext.Add(new Product() { Name = "nuoc ngot", Price = 800, Category = c2, Category2 = c2 });

            dbcontext.SaveChanges();
        }
        static void Main(string[] args)
        {
            // Entity -> DataBase, Table
            //DataBase - SQL Server : data01
            //--product
            //var dbcontext = new ProductDbContext();
            //insert delete update select
            //add =1 dong du lieu  || addrange them nhieu doing du lieu
            //DropDatabase();

            //DropDatabase();
            //CreateDatabase();
            //InsertData();


            //InsertProduct();


            //ReadProduct();
            //RenameProduct(2, "Iphone X");
            //DeleteProduct(5);

            //logging

            //InsertData();
            //using var dbcontext = new ShopContext();
            //var category = (from p in dbcontext.categories where p.CategoryId == 2 select p).FirstOrDefault();
            //Console.WriteLine($"{category.CategoryId} - {category.Name}");
            ////var e = dbcontext.Entry(category);
            ////e.Collection(c => c.Products).Load();
            //if (category.Products != null)
            //{
            //    Console.WriteLine($"So san pham: {category.Products.Count()}");
            //    category.Products.ForEach(p => p.PrintInfo());
            //}
            //else Console.WriteLine("Product == null");
            //Delete DB
            //using var dbcontext = new ShopContext();
            //var category = (from p in dbcontext.categories where p.CategoryId == 1 select p).FirstOrDefault();
            //dbcontext.Remove(category);
            //dbcontext.SaveChanges();

            using var dbcontext = new ShopContext();
            //var products = from p in dbcontext.products
            //               where p.Name.Contains("i") 
            //               orderby p.Price 
            //               select p;
            //products.Take(products.Count()).ToList().ForEach(p => p.PrintInfo());

            var kq = from p in dbcontext.products
                     join c in dbcontext.categories on p.CateId equals c.CategoryId
                     select new
                     {
                         Ten = p.Name,
                         DanhMuc = c.Name,
                         gia = p.Price
                     };
            kq.ToList().ForEach(abc => Console.WriteLine(abc));
           
        }
    }
}
