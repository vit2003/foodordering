using Repository.RequestObj.User;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserServices
    {
        Task<LoginInfoDTO> LoginByUnPw(LoginParameters param);
    }
}
