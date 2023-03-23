using Domain.Repositories.Implement;
using Repository.Models;
using Repository.Repository.Interface;

namespace Repository.Repository.Implement
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(FoodOrderingDBDbContext context) : base(context)
        {

        }
    }
}