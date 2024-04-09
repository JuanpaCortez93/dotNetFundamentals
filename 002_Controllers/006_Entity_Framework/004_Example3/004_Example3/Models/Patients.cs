using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _004_Example3.Models
{
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public DateTime Birthday { get; set; } = DateTime.Now;
        public string? Address { get; set; }
        public string? Telephone { get; set; }
    }
}
