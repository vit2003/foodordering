using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Category;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

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
            if(cate != null)
            {
                if(cate.Products.Count() > 0)
                {
                    foreach(var product in cate.Products)
                    {
                        if(product.ProductContents.Count() > 0)
                        {
                            foreach(var proContent in product.ProductContents)
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
    }
}
