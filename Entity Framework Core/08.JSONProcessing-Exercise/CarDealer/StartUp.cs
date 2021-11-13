using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //string salesJson = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(dbContext, suppliersJson));
            //Console.WriteLine(ImportParts(dbContext, partsJson));
            //Console.WriteLine(ImportCars(dbContext, carsJson));
            //Console.WriteLine(ImportCustomers(dbContext, customersJson));
            //Console.WriteLine(ImportSales(dbContext, salesJson));

            //Console.WriteLine(GetOrderedCustomers(dbContext));
            //Console.WriteLine(GetCarsFromMakeToyota(dbContext));
            //Console.WriteLine(GetLocalSuppliers(dbContext));
            //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));
            //Console.WriteLine(GetTotalSalesByCustomer(dbContext));
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
                    priceWithDiscount = $"{((100 - s.Discount) / 100) * (s.Car.PartCars.Sum(pc => pc.Part.Price)):f2}"
                })
                .Take(10)
                .ToList();

            string salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars.Select(pc => pc.Part.Price)).Sum()
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string customersJson = JsonConvert.SerializeObject(customers, settings);

            return customersJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(pc => pc.Part)
                        .Select(p => new
                        {
                            p.Name,
                            Price = $"{p.Price:f2}"
                        })
                        .ToList()
                })
                .ToList();

            string carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            //File.WriteAllText("../../../cars.json", carsJson);

            return carsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            string localSuppliersJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return localSuppliersJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string toyotaCarsJson = JsonConvert.SerializeObject(toyotaCars, settings);

            return toyotaCarsJson;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver
                })
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            };

            var customersJson = JsonConvert.SerializeObject(customers, settings);

            return customersJson;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<SaleDto> salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleDto>>(inputJson);

            InitializeMapper();

            IEnumerable<Sale> sales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<CustomerDto> customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(inputJson);

            InitializeMapper();

            IEnumerable<Customer> customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarDto>>(inputJson);

            InitializeMapper();

            var cars = new List<Car>();

            foreach (CarDto car in carsDto)
            {
                Car currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (int partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersIds = context.Suppliers
                .Select(s => s.Id);

            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartDto>>(inputJson)
                .Where(p => suppliersIds.Contains(p.SupplierId));

            InitializeMapper();

            IEnumerable<Part> parts = mapper.Map<IEnumerable<Part>>(partsDto);

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplierDto> suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierDto>>(inputJson);

            InitializeMapper();

            IEnumerable<Supplier> suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliersDto.Count()}.";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}