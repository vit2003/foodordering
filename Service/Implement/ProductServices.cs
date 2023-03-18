using Domain.Repositories.Interface;
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

        public Task<ListResponse<ProductDTO>> GetAllProduct(GetProductParam param)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResponse<ProductDTO>> GetByCategoryProduct(GetProductParam param)
        {
            var data = await _repositoryManager.Product.FindByCondition(x => x.IsDeleted == false && x.CategoryId == param.CategoryId, true)
                .Skip((param.PageCurrent - 1) * param.PageSize)
                .Take(param.PageSize)
                .Select(x => new ProductDTO
                {
                    CategoryId = x.CategoryId,
                    Price = x.Price,
                    ProductDescription = x.ProductDescription,
                    ProductName = x.ProductName,
                    ProductId = x.ProductId,
                    ProductImageUrl = x.ProductImageUrl,
                    Quantity = x.Quantity
                }).ToListAsync();
            return new ListResponse<ProductDTO>
            {
                Count = await _repositoryManager.Product.FindByCondition(x => x.IsDeleted == false && x.CategoryId == param.CategoryId, false).CountAsync(),
                PageSize = param.PageSize,
                PageNumber = param.PageCurrent,
                Data = data
            };
        }
    }
}
