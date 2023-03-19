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

            return Ok(new {cartId = id});
        }
    }
}
