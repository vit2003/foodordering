using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.RequestObj.Category;
using Service.DTOs.Category;
using Service.Interface;

namespace Service.Implement
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoriesServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var cate = await _repositoryManager.Category.FindByCondition(x => x.CategoryId == categoryId, true)
                .Include(x => x.Products).ThenInclude(y => y.ProductContents).FirstOrDefaultAsync();
            if (cate != null)
            {
                if (cate.Products.Count() > 0)
                {
                    foreach (var product in cate.Products)
                    {
                        if (product.ProductContents.Count() > 0)
                        {
                            foreach (var proContent in product.ProductContents)
                            {
                                _repositoryManager.ProductContent.Delete(proContent);
                            }
                        }
                        _repositoryManager.Product.Delete(product);
                    }
                }
                _repositoryManager.Category.Delete(cate);
                await _repositoryManager.SaveAsync();
            }
        }
        public async Task<int> CreateCategory(CreateCategoryParameter param)
        {
            var category = new Category
            {
                CategoryName = param.CategoryName,
                CategoryImageUrl = param.CategoryImageUrl,
            };

            _repositoryManager.Category.Create(category);
            await _repositoryManager.SaveAsync();

            return category.CategoryId;
        }

        public async Task<List<CategoryDTO>> GetListCategories()
        {
            var result = await _repositoryManager.Category.FindAll(false)
                .Select(x => new CategoryDTO
                {
                    Id = x.CategoryId,
                    Name = x.CategoryName
                })
                .ToListAsync();
            return result;
        }

        public async Task Update(int categoryId, UpdateCategoryParameter param, bool trackChanges)
        {
            var category = await _repositoryManager.Category.FindByCondition(x => x.CategoryId == categoryId, trackChanges)
                .FirstOrDefaultAsync();
            if (category != null)
            {
                category.CategoryName = param.CategoryName;
                category.CategoryImageUrl = param.CategoryImageUrl;

                _repositoryManager.Category.Update(category);
                await _repositoryManager.SaveAsync();
            }
            else
            {
                throw new Exception("Not Founf ID");
            }
        }
    }

}
