using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomersApi.Core.Model
{
    [Table("Customer")]
    public class CustomerModel
    {
        [JsonIgnore]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Name")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string Name { get; set; }
        [Column("Email")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string Email { get; set; }
        [JsonIgnore]
        [Column("CreateAt")]
        public DateTime CreateAt{ get; set; }
        [JsonIgnore]
        [Column("UpdateAt")]
        public DateTime? UpdateAt{ get; set; }
        public virtual AddressModel Address { get; set; }

    }
}
