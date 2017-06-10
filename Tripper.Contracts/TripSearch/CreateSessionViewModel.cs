namespace Tripper.Models.TripSearch
{
    public class CreateSessionViewModel
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Locale { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
        public string OriginPlace { get; set; }
        public string DestinationPlace { get; set; }
        public string OutboundDate { get; set; }
        public string InboundDate { get; set; }
        public string LocationSchema { get; set; }
        public string CabinClass { get; set; }
        public bool GroupPricing { get; set; }
    }

}
