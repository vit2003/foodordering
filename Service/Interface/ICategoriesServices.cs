using Repository.RequestObj.Category;
using Service.DTOs.Category;

namespace Service.Interface
{
    public interface ICategoriesServices
    {
        Task<int> CreateCategory(CreateCategoryParameter newcategory);
        Task DeleteCategory(int categoryId);
        Task<List<CategoryDTO>> GetListCategories();
        Task Update(int categoryId, UpdateCategoryParameter param, bool trackChanges);
    }
}
