using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.RequestObj.Cart;
using Service.DTOs.Cart;
using Service.Interface;

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
            var cart = new Cart { UserId = param.UserId, IsActive = true };

            _repositoryManager.Cart.Create(cart);
            await _repositoryManager.SaveAsync();

            return cart.CartId;
        }

        public async Task DeleteCart(int cartId)
        {
            var cart = await _repositoryManager.Cart.FindByCondition(x => x.CartId == cartId, true)
                .Include(x => x.ProductContents)
                .FirstOrDefaultAsync();

            if (cart != null)
            {
                if (cart.ProductContents.Count() > 0)
                {
                    foreach (var pro in cart.ProductContents)
                    {
                        _repositoryManager.ProductContent.Delete(pro);
                    }
                }
                _repositoryManager.Cart.Delete(cart);
            }
            await _repositoryManager.SaveAsync();
        }

        public async Task<List<CartInListDTO>> GetByPhoneNum(string phoneNum)
        {
            var carts = await _repositoryManager.Cart.FindByCondition(x => x.User!.Mobile == phoneNum, true)
                .Include(x => x.User).Include(x => x.ProductContents).ThenInclude(x => x.Product).ToListAsync();

            return carts.Select(x => new CartInListDTO
            {
                CartId = x.CartId,
                Products = x.ProductContents.Select(y => new ProductInCartList
                {
                    Name = y.Product!.ProductName,
                    Price = y.Price.ToString(),
                    ProductId = y.ProductId,
                    Quantity = y.Quantity,
                }).ToList(),
                Total = x.ProductContents?.Select(y => y.Price * y.Quantity).Sum().ToString()
            }).ToList();
        }

        public async Task<CartDetailDTO> GetCartDetail(int cartId)
        {
            var cart = await _repositoryManager.Cart.FindByCondition(x => x.CartId == cartId, true)
                .Include(x => x.ProductContents)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();

            if (cart != null)
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

        public async Task NewProductContent(int cartId, int productId, int quantity)
        {
            var cart = await _repositoryManager.Cart.FindByCondition(x => x.CartId == cartId, true)
                .Include(x => x.ProductContents)
                .FirstOrDefaultAsync();
            if (cart == null)
                return;
            var proInCart = cart!.ProductContents.Where(x => x.ProductId == productId).FirstOrDefault();
            if (proInCart != null)
            {
                if (quantity == 0)
                {
                    _repositoryManager.ProductContent.Delete(proInCart);
                }
                else
                {
                    proInCart.Quantity = quantity;
                    _repositoryManager.ProductContent.Update(proInCart);
                }
            }
            else
            {
                _repositoryManager.ProductContent.Create(new ProductContent
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cartId,
                    Price = await _repositoryManager.Product.FindByCondition(x => x.ProductId == productId, true)
                    .Select(x => x.Price).FirstOrDefaultAsync()
                });
            }
            await _repositoryManager.SaveAsync();
        }
    }
}
