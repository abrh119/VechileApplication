using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VechileApplication.Models
{
    public class Model
    {
        [Key]
        public int model_id { get; set; }

        [Required]
        public string model_name { get; set; } = default!;

        [Required]
        public int make_id { get; set; }

    }
}
