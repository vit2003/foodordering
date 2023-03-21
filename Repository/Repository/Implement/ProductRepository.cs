using Domain.Repositories.Implement;
using FoodOrderingAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implement
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(FoodOrderingDBDbContext context) : base(context)
        {
        }
    }
}
