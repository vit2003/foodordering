using Domain.Repositories.Implement;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Repository.Implement
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(FoodOrderingDBDbContext context) : base(context)
        {
        }
    }
}
