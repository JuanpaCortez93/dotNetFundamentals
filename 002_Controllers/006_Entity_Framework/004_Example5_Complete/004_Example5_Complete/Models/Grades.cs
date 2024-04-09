using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _004_Example5_Complete.Models
{
    public class Grades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int Year { get; set; }
        public string Cycle { get; set; }
        public int Bimester { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Grade { get; set;}

        [ForeignKey("StudentId")]
        public virtual Students Students { get; set; }
        [ForeignKey("CourseId")]
        public virtual Courses Courses { get; set; }


    }
}
