using Repository.RequestObj.Cart;
using Repository.RequestObj.Order;
using Service.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderServices
    {
        Task<int> CreateOrder(CreateOrderParameter param);
        Task DeleteOrder(int id);
        Task<OrderDetailDTO> GetOrderDetail(int id);
        Task Update(int orderId, UpdateOrderParameter param, bool trackChanges);
    }
}
