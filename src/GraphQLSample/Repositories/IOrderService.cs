using GraphQLSample.Models;

namespace GraphQLSample.Repositories
{
    public interface IOrderService
    {
        public Task<List<Orders>> OrdersAsync();

        public Task<Orders> GetOrderByIdAsync(Guid orderId);

        public Task<bool> AddOrderAsync(Orders orderInfo);

        public Task<bool> UpdateOrderAsync(Orders orderInfo);

        public Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
