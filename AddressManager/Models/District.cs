using System;
using System.Collections.Generic;

namespace AddressManager.Models
{
    public class District
    {
        public Guid Id { get; set; }
        public int DistrictName { get; set; }
        public int DistrictCode { get; set; }
        public int DistrictDescription { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<Address> Addresses { get; set; }
            = new HashSet<Address>();
    }
}
