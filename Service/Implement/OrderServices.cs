using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.RequestObj.Order;
using Service.DTOs.Cart;
using Service.DTOs.Order;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepositoryManager _repositoryManager;
        public OrderServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<int> CreateOrder(CreateOrderParameter param)
        {
            var order = new Order
            {
                UserId = param.UserId,
                DeliveryTime = param.DeliveryTime,
                OrderDate = param.OrderDate,
                Address = param.Address,
            };

            _repositoryManager.Order.Create(order);
            await _repositoryManager.SaveAsync();

            return order.Id;
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _repositoryManager.Order.FindByCondition(x => x.Id == id, true).FirstOrDefaultAsync();

            if (order != null)
            {                
                _repositoryManager.Order.Delete(order);
            }
            await _repositoryManager.SaveAsync();
        }

        public async Task<OrderDetailDTO> GetOrderDetail(int id)
        {
            var order = await _repositoryManager.Order.FindByCondition(x => x.Id == id, true)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
            if (order != null)
            {
                return new OrderDetailDTO
                {
                    Id = order.Id,
                    UserName = order.User.UserName,
                    DeliveryTime = order.DeliveryTime,
                    OrderDate = order.OrderDate,
                    Address = order.Address,
                    Phone = order.User.Mobile,
                    UserEmail = order.User.Email,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task Update(int orderId, UpdateOrderParameter param, bool trackChanges)
        {
            var order = await _repositoryManager.Order.FindByCondition(x => x.Id == orderId, trackChanges)
                .FirstOrDefaultAsync();
            if (order != null)
            {
                order.Address = param.Address;
                order.DeliveryTime = param.DeliveryTime;
                order.OrderDate = param.OrderDate;

                _repositoryManager.Order.Update(order);
                await _repositoryManager.SaveAsync();
            }
            else
            {
                throw new Exception("Not Founf ID");
            }
        }
    }
}
