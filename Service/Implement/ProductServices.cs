﻿using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.RequestObj.Product;
using Service.DTOs.BasicRes;
using Service.DTOs.Product;
using Service.Interface;

namespace Service.Implement
{
    public class ProductServices : IProductServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Delete(int productId)
        {
            var product = await _repositoryManager.Product.FindByCondition(x => x.ProductId == productId, true)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                product.IsDeleted= true;
                await _repositoryManager.SaveAsync();
            }
        }

        public async Task<ListResponse<ProductInListDTO>> GetByCategoryProduct(GetProductParam param)
        {
            var data = await _repositoryManager.Product.FindByCondition(x => x.IsDeleted == false && x.CategoryId == param.CategoryId, true)
                .Skip((param.PageCurrent - 1) * param.PageSize)
                .Take(param.PageSize)
                .Select(x => new ProductInListDTO
                {
                    Price = x.Price,
                    ProductName = x.ProductName,
                    ProductId = x.ProductId,
                    ProductImageUrl = x.ProductImageUrl,
                    Quantity = x.Quantity
                }).ToListAsync();
            return new ListResponse<ProductInListDTO>
            {
                Count = await _repositoryManager.Product.FindByCondition(x => x.IsDeleted == false && x.CategoryId == param.CategoryId, false).CountAsync(),
                PageSize = param.PageSize,
                PageNumber = param.PageCurrent,
                Data = data
            };
        }

        public async Task<ProductDTO> GetDetail(int productId)
        {
            var product = await _repositoryManager.Product.FindByCondition(x => x.ProductId == productId, true)
                .Include(x => x.Category).FirstOrDefaultAsync();

            if (product != null)
                return new ProductDTO
                {
                    ProductId = productId,
                    CategoryName = product.Category.CategoryName,
                    Price = product.Price,
                    ProductDescription = product.ProductDescription,
                    ProductImageUrl = product.ProductImageUrl,
                    ProductName = product.ProductName,
                    Quantity = product.Quantity
                };
            else
                return null;
        }
    }
}
