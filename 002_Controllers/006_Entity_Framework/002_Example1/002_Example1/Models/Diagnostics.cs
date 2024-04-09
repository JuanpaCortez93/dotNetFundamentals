using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _002_Example1.Models
{
    public class Diagnostics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        public int VisitId { get; set; }

        [ForeignKey("VisitId")]
        public virtual Visits Visits { get; set; }

    }
}
