using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VechileApplication.Models
{
    public class Make
    {
        [Key]
        public int make_id { get; set; }

        [Required]
        public string make_name { get; set; } = default!;

    }
}
