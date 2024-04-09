using _004_Example4_Refactorizacion.DatabaseContext;
using _004_Example4_Refactorizacion.DTOs.Orders;
using _004_Example4_Refactorizacion.Model;
using Microsoft.EntityFrameworkCore;

namespace _004_Example4_Refactorizacion.Services.Orders
{
    public class OrdersService : IOrdersService
    {

        private EShopDbContext _eShopDbContext;

        public OrdersService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public async Task<IEnumerable<OrdersGetDTO>> GetOrders()
        {
            var orderDTO = await _eShopDbContext.Orders.Select(order => new OrdersGetDTO
            {
                Id = order.Id,
                ClientsId = order.ClientsId,
                ProductsId = order.ProductsId
            }).ToListAsync();

            return orderDTO;
        }

        public async Task<OrdersGetDTO> GetOrderById(Guid id)
        {
            var order = await _eShopDbContext.Orders.FindAsync(id);
            if (order == null) return null;

            var orderDTO = new OrdersGetDTO
            {
                Id = order.Id,
                ClientsId = order.ClientsId,
                ProductsId = order.ProductsId
            };

            return orderDTO;
        }

        public async Task<OrdersGetDTO> AddOrder(OrdersPostDTO ordersPostDTO)
        {
            var product = _eShopDbContext.Products.Find(ordersPostDTO.ProductsId);
            var client = _eShopDbContext.Clients.Find(ordersPostDTO.ClientsId);
            if (product == null || client == null) return null;
            if (product.Amount == 0) return null;

            var order = new _004_Example4_Refactorizacion.Model.Orders()
            {
                ClientsId = ordersPostDTO.ClientsId,
                ProductsId = ordersPostDTO.ProductsId
            };

            await _eShopDbContext.Orders.AddAsync(order);

            product.Amount -= 1;
            _eShopDbContext.Products.Update(product);
            await _eShopDbContext.SaveChangesAsync();

            var orderDTO = new OrdersGetDTO
            {
                Id = order.Id,
                ClientsId = order.ClientsId,
                ProductsId = order.ProductsId
            };

            return orderDTO;

        }

        public async Task<OrdersGetDTO> DeleteOrder(Guid id)
        {
            var order = await _eShopDbContext.Orders.FindAsync(id);
            if (order == null) return null;

            var product = await _eShopDbContext.Products.FindAsync(order.ProductsId);
            product.Amount += 1;

            _eShopDbContext.Products.Update(product);
            _eShopDbContext.Remove(order);
            await _eShopDbContext.SaveChangesAsync();

            var orderDTO = new OrdersGetDTO
            {
                Id = order.Id,
                ClientsId = order.ClientsId,
                ProductsId = order.ProductsId
            };

            return orderDTO;
        }

    }
}
