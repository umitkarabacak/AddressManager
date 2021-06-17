using System;
using System.Collections.Generic;

namespace AddressManager.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public int NumericCode { get; set; }
        public string CountryName { get; set; }
        public string CountryDescription { get; set; }
        public string AlphaCode2 { get; set; }
        public string AlphaCode3 { get; set; }
        public string PhoneNumberCode { get; set; }

        public ICollection<City> Cities { get; set; }
            = new HashSet<City>();
        public ICollection<Address> Addresses { get; set; }
            = new HashSet<Address>();
    }
}
