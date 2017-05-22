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

        public HotelsWrapper FindHotels(string location, DateTime fromDate, DateTime toDate, ArrivingMethod arrivingMethod,
            bool businessTrip = false)
        {
            _bookingAccessor.SetDirection(location);
            _bookingAccessor.SetTravelingForWork(businessTrip);
            _bookingAccessor.SetArrivingMethod(arrivingMethod);
            //TODO: add date filtering
            //_bookingAccessor.SetCheckInDate();

            return _bookingAccessor.GetHotels();
        }
    }
}