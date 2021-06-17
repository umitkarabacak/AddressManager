using System;

namespace AddressManager.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }


        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
