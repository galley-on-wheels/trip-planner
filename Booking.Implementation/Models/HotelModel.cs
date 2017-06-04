using Newtonsoft.Json;

namespace Booking.Implementation.Models
{
    [JsonObject]
    public class HotelModel
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public int Rank { get; set; }

        [JsonProperty]
        public int PriceRank { get; set; }
    }
}
