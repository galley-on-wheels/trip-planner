using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Booking.Implementation.Models
{
    [JsonObject]
    public class HotelModel
    {
        private string _rawPrice;

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public double Score { get; set; }

        [JsonProperty]
        public double MaxScore { get; set; } = 10;

        [JsonProperty]
        public Uri ImageLink { get; set; }

        [JsonProperty]
        public Uri HotelBookingUri { get; set; }

        [JsonProperty]
        public string RawPrice
        {
            get { return _rawPrice; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _rawPrice = value;
                    Currency = _rawPrice.Substring(0, 3);

                    var numericPart = Regex.Match(_rawPrice, "\\d+\\,\\d+").Value;
                    double resultPrice = 0;
                    if (Double.TryParse(numericPart, out resultPrice))
                    {
                        Price = (int)resultPrice;
                    }
                }
            }
        }

        [JsonProperty]
        public int Price { get; set; }

        [JsonProperty]
        public string Currency { get; set; }

        public int PriceRank { get; set; }
    }
}
