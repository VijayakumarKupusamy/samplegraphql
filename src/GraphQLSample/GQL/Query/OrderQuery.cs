using GraphQLSample.Models;
using GraphQLSample.Repositories;

namespace GraphQLSample.GQL
{
    public class OrderQuery
    {
        public async Task<List<Orders>> GetProductListAsync([Service] IOrderService orderService)
        {
            return await orderService.OrdersAsync();
        }

        public async Task<Orders> GetProductDetailsByIdAsync([Service] IOrderService orderService, Guid orderId)
        {
            return await orderService.GetOrderByIdAsync(orderId);
        }
    }
}
