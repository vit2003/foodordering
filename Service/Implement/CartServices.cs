using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.RequestObj.Cart;
using Service.DTOs.Cart;
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

        public async Task DeleteCart(int cartId)
        {
            var cart = await _repositoryManager.Cart.FindByCondition(x => x.CartId == cartId, true)
                .Include(x => x.ProductContents)
                .FirstOrDefaultAsync();

            if(cart != null)
            {
                if(cart.ProductContents.Count() > 0)
                {
                    foreach(var pro in cart.ProductContents)
                    {
                        _repositoryManager.ProductContent.Delete(pro);
                    }
                }
                _repositoryManager.Cart.Delete(cart);
            }
            await _repositoryManager.SaveAsync();
        }

        public async Task<CartDetailDTO> GetCartDetail(int cartId)
        {
            var cart = await _repositoryManager.Cart.FindByCondition(x => x.CartId == cartId, true)
                .Include(x => x.ProductContents)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();

            if(cart != null)
            {
                return new CartDetailDTO
                {
                    CartId = cart.CartId,
                    Products = cart.ProductContents.Select(x => new ProductInCart
                    {
                        Name = x.Product.ProductName,
                        PricePerOne = x.Price.ToString(),
                        Quantity = x.Quantity,
                        AllPrize = (x.Price * x.Quantity).ToString(),
                        ProductId = x.ProductId
                    }).ToList(),
                    Total = cart.ProductContents.Select(x => (x.Price * x.Quantity)).Sum().ToString()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
