using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SharedTrip.Data;
using SharedTrip.Data.Models;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext data;

        public TripsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void AddTrip(
            string startingPoint,
            string endPoint,
            DateTime departureTime,
            string imagePath,
            int seats,
            string description)
        {
            var newTrip = new Trip
            {
                StartPoint = startingPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                Seats = seats,
                Description = description,
                ImagePath = imagePath
            };

            this.data.Trips.Add(newTrip);
            this.data.SaveChanges();
        }

        public IEnumerable<Trip> GetAllTrips()
            => this.data.Trips.ToList();

        public int GetFreeSeats(string tripId)
        {
            var trip = this.GetTripById(tripId);

            return trip.Seats;
        }

        public Trip GetTripById(string id)
            => this.data.Trips.Find(id);

        public void ReserveSeat(string userId, string tripId)
        {
            var trip = this.GetTripById(tripId);
            trip.Seats--;
            trip.UserTrips.Add(new UserTrip
            {
                UserId = userId
            });

            this.data.SaveChanges();
        }

        public bool UserHasJoinedTrip(string userId, string tripId)
        {
            var user = this.data
                .Users
                .Include(u => u.UserTrips)
                .FirstOrDefault(u => u.Id == userId);

            var userTripsIds = user.UserTrips.Select(ut => ut.TripId);
            var userAlreadyJoined = userTripsIds.Contains(tripId);

            return userAlreadyJoined;
        }
    }
}
