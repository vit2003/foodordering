using Domain.Repositories.Interface;
using Repository.Models;
using Repository.RequestObj.Cart;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class CartServices : ICartServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public CartServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<int> CreateCart(CreateCartParameters param)
        {
            var cart = new Cart { UserId= param.UserId, IsActive = true };

            _repositoryManager.Cart.Create(cart);
            await _repositoryManager.SaveAsync();

            return cart.CartId;
        }
    }
}
