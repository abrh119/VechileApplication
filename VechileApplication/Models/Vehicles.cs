using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VechileApplication.Models
{
    public class Vehicles
    {
        [Key]
        public int v_id { get; set; }

        [Required]
        public string v_name { get; set; } = default!;

        [Required]
        public int make_id { get; set; }

        [Required]
        public int model_id { get; set; } = default!;

    }
}