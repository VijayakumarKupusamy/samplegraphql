using GraphQLSample.Data;
using GraphQLSample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repositories
{
    public class OrderService : IOrderService
    {
        private readonly DbContextClass dbContextClass;
        public OrderService(DbContextClass dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        public async Task<List<Orders>> OrdersAsync()
        {
            return await dbContextClass.Orders.ToListAsync();
        }

        public async Task<Orders> GetOrderByIdAsync(Guid orderId)
        {
            return await dbContextClass.Orders.Where(ele => ele.orderId == orderId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddOrderAsync(Orders orders)
        {
            await dbContextClass.Orders.AddAsync(orders);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderAsync(Orders orders)
        {
            var isProduct = IsOrderExists(orders.orderId);
            if (isProduct)
            {
                dbContextClass.Orders.Update(orders);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var findProductData = dbContextClass.Orders.Where(op => op.orderId == orderId).FirstOrDefault();
            if (findProductData != null)
            {
                dbContextClass.Orders.Remove(findProductData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool IsOrderExists(Guid orderId)
        {
            return dbContextClass.Orders.Any(e => e.orderId == orderId);
        }
    }
}
