using Repository.RequestObj.Cart;
using Repository.RequestObj.Category;
using Repository.RequestObj.Product;
using Service.DTOs.BasicRes;
using Service.DTOs.Product;

namespace Service.Interface
{
    public interface IProductServices
    {
        Task<int> CreateProduct(CreateProductParam param);
        Task Delete(int productId);
        Task Update(int productId,UpdateProductParameter param, bool trackChanges);
        Task<ListResponse<ProductInListDTO>> GetByCategoryProduct(GetProductParam param);
        Task<ProductDTO> GetDetail(int productId);
    }
}
