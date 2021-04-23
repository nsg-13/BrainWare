using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainWare.Data.Entities
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Column("order_id")]
        public int OrderID { get; set; }

        [Column("description")]
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Column("company_id")]
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        [Column("orderproducts")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
