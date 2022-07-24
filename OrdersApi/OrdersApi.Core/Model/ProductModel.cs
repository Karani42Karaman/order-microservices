using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApi.Core.Model
{
    [Table("Product")]
    public class ProductModel
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("ImageUrl")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string ImageUrl { get; set; }
        [Column("Name")]
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string Name { get; set; }

        public Guid OrderId { get; set; }
        public virtual OrderModel Order { get; set; }

    }
}
