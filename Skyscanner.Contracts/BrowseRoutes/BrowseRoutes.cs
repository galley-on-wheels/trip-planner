using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyscanner.Contracts.BrowseRoutes
{

    public class RoutesWrapper
    {
        public Route[] Routes { get; set; }
        public Quote[] Quotes { get; set; }
        public Place[] Places { get; set; }
        public Carrier[] Carriers { get; set; }
        public Currency[] Currencies { get; set; }
    }

    public class Route
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public int[] QuoteIds { get; set; }
        public int Price { get; set; }
        public DateTime QuoteDateTime { get; set; }
    }

    public class Quote
    {
        public int QuoteId { get; set; }
        public int MinPrice { get; set; }
        public bool Direct { get; set; }
        public Outboundleg OutboundLeg { get; set; }
        public Inboundleg InboundLeg { get; set; }
        public DateTime QuoteDateTime { get; set; }
    }

    public class Outboundleg
    {
        public int[] CarrierIds { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class Inboundleg
    {
        public int[] CarrierIds { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class Place
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SkyscannerCode { get; set; }
    }

    public class Carrier
    {
        public int CarrierId { get; set; }
        public string Name { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public bool SymbolOnLeft { get; set; }
        public bool SpaceBetweenAmountAndSymbol { get; set; }
        public int RoundingCoefficient { get; set; }
        public int DecimalDigits { get; set; }
    }

}
