using Domain.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.RequestObj.Cart;
using Repository.RequestObj.Category;
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
        private readonly IRepositoryManager _repository;
        public OrdersController(IOrderServices orderServices, IRepositoryManager repository)
        {
            _orderServices = orderServices;
            _repository = repository;
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
        [HttpPut]
        [Route("Update/{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateOrder(int orderId, UpdateOrderParameter param, bool trackChanges)
        {
            await _orderServices.Update(orderId, param, trackChanges);


            await _repository.SaveAsync();

            return Ok("Save changes success");
        }
    }
}
