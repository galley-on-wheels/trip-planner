using System;
using Booking.Implementation.Enums;
using Booking.Implementation.Models;

namespace Booking.Implementation
{
    public interface IBooking
    {
        HotelsWrapper FindHotels(string location, DateTime fromDate, DateTime toDate, ArrivingMethod arrivingMethod, bool businessTrip = false, int adults = 1, int children = 0);
    }
}
