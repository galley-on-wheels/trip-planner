using System;
using Booking.Implementation.Enums;
using Booking.Implementation.Models;
using OpenQA.Selenium.PhantomJS;

namespace Booking.Implementation
{
    public class BookingFacade : IBooking
    {
        private readonly BookingAccessor _bookingAccessor;

        public BookingFacade()
        {
            _bookingAccessor = new BookingAccessor(new PhantomJSDriver());
        }

        public HotelsWrapper FindHotels(string location, DateTime fromDate, DateTime toDate,
            ArrivingMethod arrivingMethod,
            bool businessTrip = false, int adults = 1, int children = 0)
        {
            _bookingAccessor.SetDirection(location);
            _bookingAccessor.SetTravelingForWork(businessTrip);
            _bookingAccessor.SetArrivingMethod(arrivingMethod);
            _bookingAccessor.SetCheckInDate(fromDate);
            _bookingAccessor.SetVisitors(adults, children);
            _bookingAccessor.SetCheckOutDate(toDate);

            return _bookingAccessor.GetHotels();
        }
    }
}