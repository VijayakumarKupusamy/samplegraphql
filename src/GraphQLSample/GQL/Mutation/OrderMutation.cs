using GraphQLSample.Models;
using GraphQLSample.Repositories;

namespace GraphQLSample.GQL
{
    public class OrderMutation
    {
        public async Task<bool> AddProductAsync([Service] IOrderService orderService, Orders orders)
        {
            return await orderService.AddOrderAsync(orders);
        }

        public async Task<bool> UpdateProductAsync([Service] IOrderService orderService, Orders orders)
        {
            return await orderService.UpdateOrderAsync(orders);
        }

        public async Task<bool> DeleteProductAsync([Service] IOrderService orderService, Guid orderId)
        {
            return await orderService.DeleteOrderAsync(orderId);
        }
    }
}
