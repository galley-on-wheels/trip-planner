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
        public string OriginId { get; set; }
        public string DestinationId { get; set; }
        public string[] QuoteIds { get; set; }
        public double Price { get; set; }
        public DateTime QuoteDateTime { get; set; }
    }

    public class Quote
    {
        public double QuoteId { get; set; }
        public double MinPrice { get; set; }
        public bool Direct { get; set; }
        public Outboundleg OutboundLeg { get; set; }
        public Inboundleg InboundLeg { get; set; }
        public DateTime QuoteDateTime { get; set; }
    }

    public class Outboundleg
    {
        public double[] CarrierIds { get; set; }
        public double OriginId { get; set; }
        public double DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class Inboundleg
    {
        public double[] CarrierIds { get; set; }
        public double OriginId { get; set; }
        public double DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class Place
    {
        public double PlaceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SkyscannerCode { get; set; }
    }

    public class Carrier
    {
        public double CarrierId { get; set; }
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
        public double RoundingCoefficient { get; set; }
        public int DecimalDigits { get; set; }
    }

}
