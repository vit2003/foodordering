using Service.DTOs.Category;

namespace Service.Interface
{
    public interface ICategoriesServices
    {
        Task DeleteCategory(int categoryId);
        Task<List<CategoryDTO>> GetListCategories();
    }
}
