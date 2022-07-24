using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdersApi.Core.Model
{
    [Table("Order")]
    public class OrderModel
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("CustomerId")]
        [Required]
        public Guid CustomerId { get; set; }
        
        [Column("Quantity")]
        [Required]
        public int Quantity { get; set; }
        
        [Column("Price")]
        [Required]
        public double Price { get; set; }

        [Column("Status")]
        [Required]
        public string Status { get; set; }

        [JsonIgnore]
        [Column("CreateAt")]
        public DateTime CreateAt { get; set; }
        [JsonIgnore]
        [Column("UpdateAt")]
        public DateTime? UpdateAt { get; set; }

        public virtual AddressModel Address { get; set; }
        
        public virtual ICollection<ProductModel> Product { get; set; }



    }
}
