using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _004_Example4_Refactorizacion.Model
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClientsId { get; set; }

        public Guid ProductsId { get; set; }

        [ForeignKey("ClientsId")]
        public virtual Clients Clients { get; set; }
        [ForeignKey("ProductsId")]
        public virtual Products Products { get; set; }  
    }
}
