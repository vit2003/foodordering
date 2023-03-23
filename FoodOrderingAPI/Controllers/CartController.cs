using Domain.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.RequestObj.Cart;
using Service.Interface;
using System.Runtime.CompilerServices;

namespace FoodOrderingAPI.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;


        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCarts(CreateCartParameters param)
        {
            var id = await _cartServices.CreateCart(param);

            return Ok(new { cartId = id });
        }

        [HttpDelete]
        [Route("{cartId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCarts(int cartId)
        {
            await _cartServices.DeleteCart(cartId);

            return Ok(new {message = "Delete success"});
        }

        [HttpGet]
        [Route("{cartId}/details")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDetail(int cartId)
        {
            var result = await _cartServices.GetCartDetail(cartId);

            return Ok(result);
        }

        [HttpGet]
        [Route("phone_number/{phoneNum}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByPhoneNum(string phoneNum)
        {
            var result = await _cartServices.GetByPhoneNum(phoneNum);

            return Ok(result);
        }

        [HttpPost]
        [Route("{cartId}/to_cart/{productId}/{quantity}")]
        [AllowAnonymous]
        public async Task<IActionResult> NewProductContent(int cartId, int productId, int quantity)
        {
            await _cartServices.NewProductContent(cartId, productId, quantity);

            return Ok(new {message = "Add success"});
        }
    }
}
