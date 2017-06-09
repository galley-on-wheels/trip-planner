using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Booking.Implementation
{
    public static class SearchContentExtension
    {
        public static IWebElement TryFindElement(this ISearchContext context, By by)
        {
            IWebElement element = null;
            try
            {
                element = context.FindElement(by);
            }
            catch
            {
            }
            return element;
        }
    }
}