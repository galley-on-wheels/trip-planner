using System.Reflection;

namespace Skyscanner.Contracts.GeoCatalog
{
        public class Region
        {
            public string CountryId { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }
        }

        public class Airport
        {
            public string CityId { get; set; }

            public string CountryId { get; set; }

            public string Location { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }

            public string RegionId { get; set; }
        }

        public class City
        {

            public bool SingleAirportCity { get; set; }

            public Airport[] Airports { get; set; }

            public string CountryId { get; set; }

            public string Location { get; set; }

            public string IataCode { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }

            public string RegionId { get; set; }
        }

        public class Country
        {

            public string CurrencyId { get; set; }

            public Region[] Regions { get; set; }

            public City[] Cities { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }

            public string LanguageId { get; set; }
        }

        public class Continent
        {

            public Country[] Countries { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }
        }

        public class ContinentsWrapper
        {
            public Continent[] Continents { get; set; }
        }
}
