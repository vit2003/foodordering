using Repository.RequestObj.Cart;
using Service.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICartServices
    {
        Task<int> CreateCart(CreateCartParameters param);
        Task DeleteCart(int cartId);
        Task<CartDetailDTO> GetCartDetail(int cartId);
    }
}
