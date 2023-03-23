using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.RequestObj.User;
using Service.Interface;

namespace FoodOrderingAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> LoginByUnPw(LoginParameters param)
        {
            var result = await _userServices.LoginByUnPw(param);

            return Ok(result == null ? new { ErrorCode = 401, Message = "Unauthorize user" } : result);
        }

    }
}
