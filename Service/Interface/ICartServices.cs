using Repository.RequestObj.Cart;
using Service.DTOs.Cart;

namespace Service.Interface
{
    public interface ICartServices
    {
        Task<int> CreateCart(CreateCartParameters param);
        Task DeleteCart(int cartId);
        Task<List<CartInListDTO>> GetByPhoneNum(string phoneNum);
        Task<CartDetailDTO> GetCartDetail(int cartId);
        Task NewProductContent(int cartId, int productId, int quantity);
    }
}
