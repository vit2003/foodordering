using Repository.RequestObj.Category;
using Repository.RequestObj.Product;
using Service.DTOs.Category;

namespace Service.Interface
{
    public interface ICategoriesServices
    {
        Task DeleteCategory(int categoryId);
        Task<int> CreateCategory(CreateCategoryParameter param);
        Task<List<CategoryDTO>> GetListCategories();
        Task Update(int categoryId, UpdateCategoryParameter param, bool trackChanges);
    }
}
