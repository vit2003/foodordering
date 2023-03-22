using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.RequestObj.Cart;
using Repository.RequestObj.Order;
using Service.Implement;
using Service.Interface;

namespace FoodOrderingAPI.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        #region
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder(CreateOrderParameter param)
        {
            var id = await _orderServices.CreateOrder(param);

            return Ok(new { Id = id });
        }
        #endregion
        #region
        [HttpDelete]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            await _orderServices.DeleteOrder(Id);

            return Ok(new { message = "Delete success" });
        }
        #endregion
        #region
        [HttpGet]
        [Route("{Id}/details")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDetail(int Id)
        {
            var result = await _orderServices.GetOrderDetail(Id);

            return Ok(result);
        }
        #endregion
    }
}
