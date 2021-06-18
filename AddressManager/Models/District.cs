using System;
using System.Collections.Generic;

namespace AddressManager.Models
{
    public class District
    {
        public Guid Id { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictDescription { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<Address> Addresses { get; set; }
            = new HashSet<Address>();
    }
}
