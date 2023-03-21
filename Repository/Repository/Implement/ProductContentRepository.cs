using Domain.Repositories.Implement;
using Repository;
using Repository.Models;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implement
{
    public class ProductContentRepository : RepositoryBase<ProductContent>,IProductContentRepository
    {
        public ProductContentRepository(FoodOrderingDBDbContext context) : base(context)
        {

        }
    }
}
