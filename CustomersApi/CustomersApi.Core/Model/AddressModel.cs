
using System;

namespace CustomersApi.Core.Model
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string AddressLine { get; set; }
        public string City{ get; set; }
        public string Country{ get; set; }
        public int CityCode{ get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}
