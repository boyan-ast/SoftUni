using System;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.Models;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using CarDealer.DTO.Output;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string suppliersInputXml = File.ReadAllText("Datasets/suppliers.xml");
            //string partsInputXml = File.ReadAllText("Datasets/parts.xml");
            //string carsInputXml = File.ReadAllText("Datasets/cars.xml");
            //string customersInputXml = File.ReadAllText("Datasets/customers.xml");
            //string salesInputXml = File.ReadAllText("Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(dbContext, suppliersInputXml));
            //Console.WriteLine(ImportParts(dbContext, partsInputXml));
            //Console.WriteLine(ImportCars(dbContext, carsInputXml));
            //Console.WriteLine(ImportCustomers(dbContext, customersInputXml));
            //Console.WriteLine(ImportSales(dbContext, salesInputXml));

            //Console.WriteLine(GetCarsWithDistance(dbContext));
            //Console.WriteLine(GetCarsFromMakeBmw(dbContext));
            //Console.WriteLine(GetLocalSuppliers(dbContext));
            //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));
            //Console.WriteLine(GetTotalSalesByCustomer(dbContext));
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleOutputModel
                {
                    Car = new SaleCarOutputModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Select(pc => pc.Part.Price).Sum(),
                    PriceWithDiscount = s.Car.PartCars.Select(pc => pc.Part.Price).Sum() * (100 - s.Discount) / 100
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleOutputModel[]), new XmlRootAttribute("sales"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, sales, ns);

            return writer.ToString();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var cusomers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new CustomerOutputModel
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars.Select(pc => pc.Part.Price)).Sum()
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerOutputModel[]), new XmlRootAttribute("customers"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, cusomers, ns);

            return writer.ToString();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarWithPartsOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => pc.Part)
                        .Select(p => new CarPartOutputModel
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarWithPartsOutputModel[]), new XmlRootAttribute("cars"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, cars, ns);

            return writer.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSuppliersOutputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocalSuppliersOutputModel[]), new XmlRootAttribute("suppliers"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, suppliers, ns);

            return writer.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarWithAttrOutputModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarWithAttrOutputModel[]), new XmlRootAttribute("cars"));

            TextWriter writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(writer, cars, ns);

            return writer.ToString();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            List<CarOutputModel> cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CarOutputModel>), new XmlRootAttribute("cars"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            TextWriter writer = new StringWriter();

            xmlSerializer.Serialize(writer, cars, ns);

            return writer.ToString();
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));

            SaleInputModel[] salesDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as SaleInputModel[];

            List<int> carsIds = context.Cars.Select(c => c.Id).ToList();

            List<Sale> sales = salesDto
                .Where(s => carsIds.Contains(s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                }).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));

            var customersDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as CustomerInputModel[];

            List<Customer> customers = customersDto
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = DateTime.Parse(c.BirthDate),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));

            var carsDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as CarInputModel[];

            var partsIds = context.Parts.Select(p => p.Id);

            List<Car> cars = carsDto
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    PartCars = c.Parts
                        .Select(p => p.Id)
                        .Distinct()
                        .Where(x => partsIds.Contains(x))
                        .Select(x => new PartCar
                        {
                            PartId = x
                        })
                        .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));

            var partsDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as PartInputModel[];

            int[] suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();

            Part[] parts = partsDto
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as SupplierInputModel[];

            Supplier[] suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
    }
}