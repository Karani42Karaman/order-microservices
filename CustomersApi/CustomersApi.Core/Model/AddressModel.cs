using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomersApi.Core.Model
{
    [Table("Address")]
    public class AddressModel
    {
        [JsonIgnore]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("AddressLine")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string AddressLine { get; set; }
        [Column("City")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string City{ get; set; }
        [Column("Country")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string Country{ get; set; }
        [Column("CityCode")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public int CityCode{ get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}
