using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainWare.Data.Entities
{
    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("company_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }

        [Required]
        [Column("name")]
        [StringLength(128)]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
