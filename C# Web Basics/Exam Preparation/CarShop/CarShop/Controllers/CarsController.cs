﻿using System.Linq;

using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Car;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;
        private readonly IValidator validator;

        public CarsController(
            ApplicationDbContext data, 
            IUserService userService, 
            IValidator validator)
        {
            this.data = data;
            this.userService = userService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All() => View();


        [Authorize]
        public HttpResponse Add()
        {
            if (this.userService.isMechanic(this.User.Id))
            {
                return Error("Mechanics can't add cars");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarFormModel carInputModel)
        {
            var errors = this.validator.ValidateCar(carInputModel);

            if (errors.Any())
            {
                return Error(errors);
            }

            var newCar = new Car
            {
                Model = carInputModel.Model,
                Year = carInputModel.Year,
                PictureUrl = carInputModel.Image,
                PlateNumber = carInputModel.PlateNumber,
                OwnerId = this.User.Id
            };

            this.data.Cars.Add(newCar);

            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }
    }
}
