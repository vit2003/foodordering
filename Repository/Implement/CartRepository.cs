using Domain.Repositories.Interface;
using FoodOrderingAPI.Repository;
using Repository.Models;
using Repository.Repository.Interface;

namespace Domain.Repositories.Implement
{
    public class CartRepository : RepositoryBase<Cart>,ICartRepository
    {
        public CartRepository(FoodOrderingDBDbContext context) : base(context) { }
    }
}