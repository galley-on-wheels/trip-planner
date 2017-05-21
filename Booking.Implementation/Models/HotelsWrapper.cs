using System.Collections.Generic;
using Newtonsoft.Json;

namespace Booking.Implementation.Models
{
    [JsonObject]
    public class HotelsWrapper
    {
        [JsonProperty]
        public IEnumerable<HotelModel> Hotels { get; set; }
    }
}
