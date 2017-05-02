using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyscanner.Contracts.Places
{
    public class PlacesWrapper
    {
        public Place[] Places { get; set; }
    }

    public class Place
    {
        public string PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string CountryId { get; set; }
        public string RegionId { get; set; }
        public string CityId { get; set; }
        public string CountryName { get; set; }
    }

}
