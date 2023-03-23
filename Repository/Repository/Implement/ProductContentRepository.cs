using Domain.Repositories.Implement;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Repository.Implement
{
    public class ProductContentRepository : RepositoryBase<ProductContent>, IProductContentRepository
    {
        public ProductContentRepository(FoodOrderingDBDbContext context) : base(context)
        {

        }
    }
}
