﻿using Domain.Repositories.Interface;
using Repository;
using Repository.Repository.Implement;
using Repository.Repository.Interface;

namespace Domain.Repositories.Implement
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly FoodOrderingDBDbContext _context;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ICartRepository _cartRepository;
        private IUserRepository _userRepository;
        private IProductContentRepository _productContentRepository;
        private IOrderRepository _orderRepository;

        public RepositoryManager(FoodOrderingDBDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product => _productRepository == null ? new ProductRepository(_context) : _productRepository;
        public ICategoryRepository Category => _categoryRepository == null ? new CategoryRepository(_context) : _categoryRepository;
        public ICartRepository Cart => _cartRepository == null ? new CartRepository(_context) : _cartRepository;
        public IUserRepository User => _userRepository == null ? new UserRepository(_context) : _userRepository;
        public IProductContentRepository ProductContent => _productContentRepository == null ? new ProductContentRepository(_context) : _productContentRepository;
        public IOrderRepository Order => _orderRepository == null ? new OrderRepository(_context) : _orderRepository;

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
