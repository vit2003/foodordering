using Service.DTOs.Category;

namespace Service.Interface
{
    public interface ICategoriesServices
    {
        Task<List<CategoryDTO>> GetListCategories();
    }
}
