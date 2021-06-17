using System;
using System.Collections.Generic;

namespace AddressManager.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string CityDescription { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<District> Districts { get; set; }
            = new HashSet<District>();
    }
}
