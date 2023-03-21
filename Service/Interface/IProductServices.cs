﻿using Repository.RequestObj.Cart;
using Repository.RequestObj.Product;
using Service.DTOs.BasicRes;
using Service.DTOs.Product;

namespace Service.Interface
{
    public interface IProductServices
    {
        Task<ListResponse<ProductDTO>> GetAllProduct(GetProductParam param);
        Task<int> CreateProduct(CreateProductParam param);
        Task<ListResponse<ProductDTO>> GetByCategoryProduct(GetProductParam param);
    }
}
