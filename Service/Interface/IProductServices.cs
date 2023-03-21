using Repository.RequestObj.Cart;
using Repository.RequestObj.Product;
using Service.DTOs.BasicRes;
using Service.DTOs.Product;

namespace Service.Interface
{
    public interface IProductServices
    {
        Task<int> CreateProduct(CreateProductParam param);
        Task Delete(int productId);
        Task<ListResponse<ProductInListDTO>> GetByCategoryProduct(GetProductParam param);
        Task<ProductDTO> GetDetail(int productId);
    }
}
