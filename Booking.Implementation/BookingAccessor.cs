﻿using System;
using System.Collections.Generic;
using Booking.Implementation.Enums;
using Booking.Implementation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace Booking.Implementation
{
    public class BookingAccessor : IDisposable
    {
        private readonly IWebDriver _driver;

        public BookingAccessor(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Url = "https://booking.com";
        }

        #region Methods

        public void SetDirection(string direction)
        {
            try
            {
                var webElement = _driver.FindElement(By.Name("ss"));
                webElement.Clear();
                webElement.SendKeys(direction);
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
                var container = _driver.FindElement(By.ClassName("b-form-group-content__container"));
                var radiobuttons = container.FindElements(By.ClassName("b-booker-type__input"));
                var executableRadioBtn = forWork ? radiobuttons[0] : radiobuttons[1];
                ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].checked = true;", executableRadioBtn);
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        public void SetVisitors(int adults, int children)
        {
            if (adults <= 0 || children < 0)
            {
                return;
            }
            try
            {
                _driver.FindElement(By.Id("group_adults"))
                    .FindElement(By.CssSelector($"option[value='{adults}']"))
                    .Click();
                _driver.FindElement(By.Id("group_children"))
                    .FindElement(By.CssSelector($"option[value='{children}']"))
                    .Click();
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        public void SetCheckInDate(DateTime date)
        {
            try
            {
                var dateControl = _driver.FindElements(By.ClassName("sb-date-field__controls"))[0];
                SetDate(dateControl, date);
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        public void SetCheckOutDate(DateTime date)
        {
            try
            {
                var dateControl = _driver.FindElements(By.ClassName("sb-date-field__controls"))[1];
                SetDate(dateControl, date);
            }
            catch (Exception e)
            {
                //loger.Log
            }
        }

        private void SetDate(IWebElement dateControl, DateTime date)
        {
            dateControl.FindElement(By.Name("checkin_monthday")).SendKeys(date.Day.ToString());
            dateControl.FindElement(By.Name("checkin_month")).SendKeys(date.Month.ToString());
            dateControl.FindElement(By.Name("checkin_year")).SendKeys(date.Year.ToString());
        }

        public void SetArrivingMethod(ArrivingMethod arriving)
        {
            try
            {
                var container = _driver.FindElement(By.ClassName("b-sb-travelling-types__options"));
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
                ((IJavaScriptExecutor) _driver).ExecuteScript("arguments[0].checked = true;", executableRadioBtn);
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
                _driver.FindElement(By.ClassName("sb-searchbox__button")).Submit();
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
                tripCount = _driver.FindElements(By.ClassName("sr-hotel__name")).Count;
            }
            catch (Exception e)
            {
                //loger.Log
            }
            return tripCount;
        }

        public HotelsWrapper GetHotels()
        {
            var hotelsWrapper = new HotelsWrapper();
            var hotels = new List<HotelModel>(16);
            try
            {
                Search();
                foreach (var hotel in _driver.FindElements(By.ClassName("sr_item")))
                {
                    hotels.Add(new HotelModel()
                    {
                        Name = hotel.FindElement(By.ClassName("sr-hotel__name")).Text,
                        Description = hotel.FindElement(By.ClassName("hotel_desc")).Text
                    });
                }
                hotelsWrapper.Hotels = hotels;
            }
            catch (Exception e)
            {
                //loger.Log
            }
            return hotelsWrapper;
        }

        #endregion

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}