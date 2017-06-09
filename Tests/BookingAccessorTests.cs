using System;
using System.Linq;
using Booking.Implementation;
using Booking.Implementation.Enums;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestFixture]
    public class BookingAccessorTests
    {
        private BookingAccessor _booking;
        private IWebDriver _webDriver;

        [OneTimeSetUp]
        public void SetupDriver()
        {
            _webDriver = new ChromeDriver();
            _booking = new BookingAccessor(_webDriver);
        }
        
        [TestCase("")]
        [TestCase("Kiev")]
        [TestCase("12345")]
        [TestCase("TestCity test street")]
        public void SetDirection_Test(string inputText)
        {
            //Act.
            _booking.SetDirection(inputText);

            var textElement = _webDriver.FindElement(By.Name("ss"));
            var email = textElement.GetAttribute("value");
            //Assert.
            Assert.That(email, Is.EqualTo(inputText));
        }

        [Test]
        public void SetDirection_NullPassed_Test()
        {
            //Act.
            _booking.SetDirection(null);

            var textElement = _webDriver.FindElement(By.Name("ss"));
            var email = textElement.GetAttribute("value");
            //Assert.
            Assert.That(email, Is.EqualTo(string.Empty));
        }

        [TestCase(false)]
        public void SetTravelingForWork_Test(bool inputValue)
        {
            //Act.
            _booking.SetTravelingForWork(inputValue);
            var container = _webDriver.FindElement(By.ClassName("b-form-group-content__container"));
            var radiobuttons = container.FindElements(By.ClassName("b-booker-type__input"));
            var actualRadioButton = inputValue ? radiobuttons[1] : radiobuttons[0];
            //Assert.
            Assert.That(actualRadioButton.Selected, Is.EqualTo(inputValue));
        }

        [TestCase(1, 0)]
        [TestCase(4, 7)]
        [TestCase(14, 10)]
        public void SetVisitors_Test(int inputAdults, int inputChildren)
        {
            //Act.
            _booking.SetVisitors(inputAdults, inputChildren);
            SelectElement selectedValue1 = new SelectElement(_webDriver.FindElement(By.Id("group_adults")));
            SelectElement selectedValue2 = new SelectElement(_webDriver.FindElement(By.Id("group_children")));
            string adults = selectedValue1.SelectedOption.Text.Trim();
            string children = selectedValue2.SelectedOption.Text.Trim();
            //Assert.
            Assert.That(adults, Is.EqualTo(inputAdults.ToString()));
            Assert.That(children, Is.EqualTo(inputChildren.ToString()));
        }

        [Test]
        public void SearchHotels_Test()
        {
            //Act.
            _booking.SetDirection("Rome");
            _booking.SetCheckInDate(DateTime.Now + TimeSpan.FromDays(3));

            _booking.SetTravelingForWork(false);
            _booking.SetArrivingMethod(ArrivingMethod.Car);
            _booking.SetVisitors(2, 2);
            _booking.SetCheckOutDate(DateTime.Now + TimeSpan.FromDays(5));

            var hotels = _booking.GetHotels(); 

            //Assert.
            Assert.That(hotels, Is.Not.Null);

        }

        //[TearDown]
        //public void ReloadPage()
        //{
        //    _webDriver.Navigate().Refresh();
        //}

        [OneTimeTearDown]
        public void TearDown()
        {
            _booking.Dispose();
        }
    }
}