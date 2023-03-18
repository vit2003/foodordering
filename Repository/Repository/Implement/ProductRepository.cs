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
        public void CreateProduct(Product product) => Create(product);

        public async Task Update(int ProductId, string ProductName, string ProductImageUrl, string ProductDescription, int CategoryId, int Quantity, double Price, bool IsDeleted, bool trackChanges)
        {
            var product = await FindByCondition(x => x.ProductId == ProductId, trackChanges).FirstOrDefaultAsync();

            product.ProductName = ProductName;
            product.ProductImageUrl = ProductImageUrl;
            product.ProductDescription = ProductDescription;
            product.CategoryId = CategoryId;
            product.Quantity = Quantity;
            product.Price = Price;
            product.IsDeleted = IsDeleted;
            Update(product);
        }
    }
}
