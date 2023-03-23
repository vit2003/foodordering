using Domain.Repositories.Implement;
using Repository;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Repository.Implement
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(FoodOrderingDBDbContext context) : base(context) { }
    }
}