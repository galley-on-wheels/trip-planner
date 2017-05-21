using System;
using System.Collections.Generic;
using Booking.Implementation.Enums;
using Booking.Implementation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Booking.Implementation
{
    public class BookingAccessor : IDisposable
    {
        private readonly PhantomJSDriver _driver;

        public BookingAccessor()
        {
            _driver = new PhantomJSDriver() { Url = "https://booking.com" };
        }

        #region Methods

        public void SetDirection(string direction)
        {
            try
            {
                _driver.FindElementByName("ss").SendKeys("London");
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        public void SetTravelingForWork(bool forWork)
        {
            try
            {
                var container = _driver.FindElementByClassName("b-form-group-content__container");
                var radiobuttons = container.FindElements(By.ClassName("b-booker-type__input"));
                var executableRadioBtn = forWork ? radiobuttons[0] : radiobuttons[1];
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].checked = true;", executableRadioBtn);
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        //TODO: inject with JS
        public void SetCheckInDate()
        {
            try
            {
                _driver.FindElementByClassName("sb-date-field__display").SendKeys("Thursday 15 February 2018");
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        public void SetArrivingMethod(ArrivingMethod arriving)
        {
            try
            {
                var container = _driver.FindElementByClassName("b-sb-travelling-types__options");
                var radiobuttons = container.FindElements(By.ClassName("b-sb-travelling-types__input"));

                var executableRadioBtn = radiobuttons[0];
                switch (arriving)
                {
                    case ArrivingMethod.Aeroplane:
                        executableRadioBtn = radiobuttons[0];
                        break;
                    case ArrivingMethod.Train:
                        executableRadioBtn = radiobuttons[1];
                        break;
                    case ArrivingMethod.Car:
                        executableRadioBtn = radiobuttons[2];
                        break;
                }
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].checked = true;", executableRadioBtn);
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }


        private void Search()
        {
            try
            {
                _driver.FindElementByClassName("sb-searchbox__button").Submit();
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        public int GetTripCount()
        {
            var tripCount = 0;
            try
            {
                Search();
                tripCount = _driver.FindElementsByClassName("sr-hotel__name").Count;
            }
            catch (Exception e)
            {
                //loger.Log
            }
            return tripCount;
        }

        public List<BookingItemModel> GetHotels()
        {
            List<BookingItemModel> hotels = new List<BookingItemModel>(16);
            try
            {
                Search();
                foreach (var hotel in _driver.FindElementsByClassName("sr_item"))
                {
                    hotels.Add(new BookingItemModel()
                    {
                        HotelName = hotel.FindElement(By.ClassName("sr-hotel__name")).Text,
                        Description = hotel.FindElement(By.ClassName("hotel_desc")).Text

                    });
                }

            }
            catch (Exception e)
            {
                //loger.Log
            }
            return hotels;

        }

        #endregion

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
