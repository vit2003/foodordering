using Repository.RequestObj.User;
using Service.DTOs.User;

namespace Service.Interface
{
    public interface IUserServices
    {
        Task<LoginInfoDTO> LoginByUnPw(LoginParameters param);
    }
}
