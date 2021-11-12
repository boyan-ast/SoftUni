using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

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
            string carsJson = File.ReadAllText("../../../Datasets/cars.json");

            //Console.WriteLine(ImportSuppliers(dbContext, suppliersJson));
            //Console.WriteLine(ImportParts(dbContext, partsJson));
            Console.WriteLine(ImportCars(dbContext, carsJson));
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