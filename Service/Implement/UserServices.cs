using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.RequestObj.User;
using Service.DTOs.User;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryManager _repository;
        private readonly IJwtServices _jwtServices;

        public UserServices(IRepositoryManager repository, IJwtServices jwtServices)
        {
            _repository = repository;
            _jwtServices = jwtServices;
        }

        public async Task<LoginInfoDTO> LoginByUnPw(LoginParameters param)
        {
            var user = await _repository.User
                .FindByCondition(x => x.UserName == param.UserName && x.Password == param.Password, true)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            else
            {
                return new LoginInfoDTO
                {
                    Id = user.Id,
                    Token = _jwtServices.GetToken(user.Id)
                };
            }
        }
    }
}
