using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainWare.Data.Entities
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(128)]
        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("orderproducts")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
