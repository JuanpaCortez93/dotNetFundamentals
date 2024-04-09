using _004_Example4_Refactorizacion.DTOs.Orders;

namespace _004_Example4_Refactorizacion.Services.Orders
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersGetDTO>> GetOrders();
        Task<OrdersGetDTO> GetOrderById(Guid id);
        Task<OrdersGetDTO> AddOrder(OrdersPostDTO ordersPostDTO);
        Task<OrdersGetDTO> DeleteOrder(Guid id);

    }
}
