using System;

namespace Skyscanner.Contracts.BrowseRoutes.Expanded
{
    public class QuoteExpanded
    {
        public double QuoteId { get; set; }
        public string MinPrice { get; set; }
        public bool Direct { get; set; }
        public OutboundlegExpanded OutboundLeg { get; set; }
        public InboundlegExpanded InboundLeg { get; set; }
        public DateTime QuoteDateTime { get; set; }
    }

    public class OutboundlegExpanded
    {
        public Carrier[] Carriers { get; set; }
        public Place Origin { get; set; }
        public Place Destination { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class InboundlegExpanded
    {
        public Carrier[] Carriers { get; set; }
        public Place Origin { get; set; }
        public Place Destination { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class PlaceExpanded
    {
        public double PlaceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SkyscannerCode { get; set; }
    }

    public class CarrierExpanded
    {
        public double CarrierId { get; set; }
        public string Name { get; set; }
    }

    public class CurrencyExpanded
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public bool SymbolOnLeft { get; set; }
        public bool SpaceBetweenAmountAndSymbol { get; set; }
        public double RoundingCoefficient { get; set; }
        public int DecimalDigits { get; set; }
    }
}
