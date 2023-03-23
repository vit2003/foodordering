using Domain.Repositories.Implement;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Repository.Implement
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(FoodOrderingDBDbContext context) : base(context)
        {
        }
    }
}
