using System;

namespace CustomersApi.Core.Model
{
    public class CustomerModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt{ get; set; }
        public DateTime UpdateAt{ get; set; }
        public virtual AddressModel Address { get; set; }

    }
}
