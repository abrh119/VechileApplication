using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VechileApplication.Models
{
    public class Price
    {
        [Key]
        public int price_id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal price { get; set; } = default!;

        [Required]
        public int v_id { get; set; }
    }
}
