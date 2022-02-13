using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using System;
using System.Globalization;
using System.Linq;
using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ITripsService tripsService;

        public TripsController(
            IValidator validator,
            ITripsService tripsService)
        {
            this.validator = validator;
            this.tripsService = tripsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.tripsService
                .GetAllTrips()
                .Select(t => new TripListingViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(DateTimeFormat),
                    Seats = t.Seats
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add()
            => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel trip)
        {
            var errors = this.validator.ValidateTrip(trip);

            bool isValidDate = DateTime.TryParseExact(
                trip.DepartureTime,
                DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime tripDepartureTime);

            if (!isValidDate)
            {
                errors.Add($"Departure Time must be in format {DateTimeFormat}");
            }

            if (errors.Any())
            {
                return Error(errors);
            }

            this.tripsService.AddTrip(
                trip.StartPoint,
                trip.EndPoint,
                tripDepartureTime,
                trip.ImagePath,
                trip.Seats,
                trip.Description);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.tripsService.GetTripById(tripId);

            if (trip == null)
            {
                return NotFound();
            }

            var tripModel = new TripDetailsViewModel
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString(DateTimeFormat),
                Seats = trip.Seats,
                Description = trip.Description,
                ImagePath = trip.ImagePath
            };

            return View(tripModel);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (this.tripsService.UserHasJoinedTrip(User.Id, tripId))
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (this.tripsService.GetFreeSeats(tripId) == 0)
            {
                return Error("No more free seats for this trip.");
            }

            this.tripsService.ReserveSeat(User.Id, tripId);

            return Redirect("/Trips/All");
        }
    }
}
