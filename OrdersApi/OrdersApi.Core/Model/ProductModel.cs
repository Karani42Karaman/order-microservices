using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdersApi.Core.Model
{
    [Table("Product")]
    public class ProductModel
    {
        [JsonIgnore]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("ImageUrl")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Column("Name")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [JsonIgnore]
        public Guid OrderId { get; set; }
        public virtual OrderModel Order { get; set; }

    }
}
