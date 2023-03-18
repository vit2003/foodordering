using Repository.RequestObj.Cart;
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
    }
}
