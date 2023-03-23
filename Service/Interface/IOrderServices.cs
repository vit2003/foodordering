using Repository.RequestObj.Order;
using Service.DTOs.Order;

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
