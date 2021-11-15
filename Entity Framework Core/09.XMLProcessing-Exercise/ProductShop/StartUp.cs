using AutoMapper;
using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
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
            var contextDb = new ProductShopContext();
            //contextDb.Database.EnsureDeleted();
            //contextDb.Database.EnsureCreated();

            //string usersInputXml = File.ReadAllText("../../../Datasets/users.xml");
            //string productsInputXml = File.ReadAllText("../../../Datasets/products.xml");
            //string categoriesInputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(contextDb, usersInputXml));
            //Console.WriteLine(ImportProducts(contextDb, productsInputXml));
            //Console.WriteLine(ImportCategories(contextDb, categoriesInputXml));
            //Console.WriteLine(ImportCategoryProducts(contextDb, categoryProductsXml));
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