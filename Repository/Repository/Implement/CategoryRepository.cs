using Domain.Repositories.Implement;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Repository.Implement
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(FoodOrderingDBDbContext context) : base(context)
        {
        }
    }
}
