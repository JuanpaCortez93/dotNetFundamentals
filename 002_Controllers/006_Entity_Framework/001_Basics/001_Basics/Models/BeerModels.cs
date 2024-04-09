using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _001_Basics.Models
{
    public class BeerModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }

        [ForeignKey("BrandId")]
        public virtual BeerBrands BeerBrands { get; set; }

    }
}
