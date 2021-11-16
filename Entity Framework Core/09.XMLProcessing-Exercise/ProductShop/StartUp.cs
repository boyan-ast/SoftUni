using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using ProductShop.DataTransferObjects.Output;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string usersInputXml = File.ReadAllText("../../../Datasets/users.xml");
            //string productsInputXml = File.ReadAllText("../../../Datasets/products.xml");
            //string categoriesInputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(dbContext, usersInputXml));
            //Console.WriteLine(ImportProducts(dbContext, productsInputXml));
            //Console.WriteLine(ImportCategories(dbContext, categoriesInputXml));
            //Console.WriteLine(ImportCategoryProducts(dbContext, categoryProductsXml));

            //Console.WriteLine(GetProductsInRange(dbContext));
            //Console.WriteLine(GetSoldProducts(dbContext));
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext));
            Console.WriteLine(GetUsersWithProducts(dbContext));

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .AsEnumerable()
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsOutputModel
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .Select(ps => new ProductOutputModel
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            UsersOutputModel output = new UsersOutputModel
            {
                Count = context.Users
                    .Include(x => x.ProductsSold)
                    .AsEnumerable()
                    .Where(u => u.ProductsSold.Count > 0).Count(),
                Users = users
            };


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersOutputModel));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, output, ns);

            return writer.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryOutputModel
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(cp => cp.Product).Average(p => p.Price),
                    TotalRevenue = c.CategoryProducts.Select(cp => cp.Product).Sum(p => p.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryOutputModel[]), new XmlRootAttribute("Categories"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, categories, ns);

            return writer.ToString();
        }

        //public static string GetSoldProducts(ProductShopContext context)
        //{
        //    var users = context.Users
        //        .Where(u => u.ProductsSold.Count() > 0)
        //        .Select(u => new UserOutputModel
        //        {
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //            SoldProducts = u.ProductsSold
        //                .Select(ps => new ProductOutputModel
        //                {
        //                    Name = ps.Name,
        //                    Price = ps.Price
        //                })
        //                .ToArray()
        //        })
        //        .OrderBy(u => u.LastName)
        //        .ThenBy(u => u.FirstName)
        //        .Take(5)
        //        .ToArray();

        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserOutputModel[]), new XmlRootAttribute("Users"));

        //    TextWriter writer = new StringWriter();

        //    var ns = new XmlSerializerNamespaces();
        //    ns.Add("", "");

        //    xmlSerializer.Serialize(writer, users, ns);

        //    return writer.ToString();
        //}

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductOutputModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    //Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductOutputModel[]), new XmlRootAttribute("Products"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, products, ns);

            return writer.ToString();
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            const string root = "CategoryProducts";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute(root));

            TextReader reader = new StringReader(inputXml);

            var categoryIds = context.Categories
                .Select(c => c.Id)
                .ToArray();

            var productIds = context.Products
                .Select(p => p.Id)
                .ToArray();

            CategoryProductInputModel[] categoryProductsDto = (xmlSerializer.Deserialize(reader) as CategoryProductInputModel[])
                .Where(x => (categoryIds.Contains(x.CategoryId) && productIds.Contains(x.ProductId)))
                .ToArray();

            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            const string root = "Categories";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesInputModel[]), new XmlRootAttribute(root));

            TextReader reader = new StringReader(inputXml);

            CategoriesInputModel[] categoriesDto = (xmlSerializer.Deserialize(reader) as CategoriesInputModel[])
                .Where(x => x.Name != null)
                .ToArray();

            Category[] categories = mapper.Map<Category[]>(categoriesDto);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            const string root = "Products";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute(root));

            TextReader reader = new StringReader(inputXml);

            ProductInputModel[] productsDto = xmlSerializer.Deserialize(reader) as ProductInputModel[];

            Product[] products = mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            const string root = "Users";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute(root));

            TextReader textReader = new StringReader(inputXml);

            UserInputModel[] usersDto = xmlSerializer.Deserialize(textReader) as UserInputModel[];

            var users = mapper.Map<User[]>(usersDto);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}