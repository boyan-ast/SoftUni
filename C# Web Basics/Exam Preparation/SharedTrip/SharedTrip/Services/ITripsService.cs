using System;
using System.Collections.Generic;
using SharedTrip.Data.Models;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void AddTrip(
            string startingPoint, 
            string endPoint, 
            DateTime departureTime, 
            string imagePath, 
            int seats, 
            string description);

        IEnumerable<Trip> GetAllTrips();

        Trip GetTripById(string id);

        bool UserHasJoinedTrip(string userId, string tripId);

        int GetFreeSeats(string tripId);

        void ReserveSeat(string userId, string tripId);
    }
}
