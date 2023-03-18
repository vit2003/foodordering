using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Category;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
