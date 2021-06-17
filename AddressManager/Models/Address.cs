using System;

namespace AddressManager.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }

        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
