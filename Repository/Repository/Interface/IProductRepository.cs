﻿using Domain.Repositories.Interface;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void CreateProduct(Product product);
        Task Update(int ProductId, string ProductName, string ProductImageUrl, string ProductDescription, int CategoryId, int Quantity, double Price, bool IsDeleted, bool trackChanges);

    }
}
