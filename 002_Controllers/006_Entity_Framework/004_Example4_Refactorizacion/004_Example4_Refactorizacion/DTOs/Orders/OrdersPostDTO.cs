using System.ComponentModel.DataAnnotations.Schema;

namespace _004_Example4_Refactorizacion.DTOs.Orders
{
    public class OrdersPostDTO
    {
        public Guid ClientsId { get; set; }
        public Guid ProductsId { get; set; }

    }
}
