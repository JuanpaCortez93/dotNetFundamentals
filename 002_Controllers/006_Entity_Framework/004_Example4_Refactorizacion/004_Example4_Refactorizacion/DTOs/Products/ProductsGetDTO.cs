using System.ComponentModel.DataAnnotations.Schema;

namespace _004_Example4_Refactorizacion.DTOs.Products
{
    public class ProductsGetDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
    }
}
