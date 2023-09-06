using GraphQLSample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbContextClass(serviceProvider.GetRequiredService<DbContextOptions<DbContextClass>>()))
            {
                if (context.Orders.Any())
                {
                    return;
                }
                context.Orders.AddRange(
                    new Orders
                    {
                        orderId = Guid.NewGuid(),
                        orderName = "LG",
                        orderDescription = "LG"
                    },
                    new Orders
                    {
                        orderId = Guid.NewGuid(),
                        orderName = "Sony",
                        orderDescription = "Sony"
                    });
                context.SaveChanges();
            }
        }
    }
}
