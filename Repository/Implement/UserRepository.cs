﻿using Domain.Repositories.Interface;
using FoodOrderingAPI.Repository;
using Repository.Models;

namespace Domain.Repositories.Implement
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(FoodOrderingDBDbContext context) : base(context)
        {

        }
    }
}