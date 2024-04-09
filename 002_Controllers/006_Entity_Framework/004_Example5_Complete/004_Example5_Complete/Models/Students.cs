using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _004_Example5_Complete.Models
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public DateOnly DateOnly { get; set; } = new DateOnly();
        public string? Address { get; set;}
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = "12345";

    }
}
