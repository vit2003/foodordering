using Domain.Repositories.Implement;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implement
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(FoodOrderingDBDbContext context) : base(context)
        {
        }
        public void CreateCategory(Category category) => Create(category);
        public async Task Update(int CategoryId, string CategoryName, string ImageUrl, bool trackChanges)
        {
            var category = await FindByCondition(x => x.CategoryId == CategoryId, trackChanges).FirstOrDefaultAsync();

            category.CategoryName = CategoryName;
            category.CategoryImageUrl = ImageUrl;

            Update(category);
        }
    }
}
