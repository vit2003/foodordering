using Repository.Repository.Interface;

namespace Domain.Repositories.Interface
{
    public interface IRepositoryManager
    {
        Task SaveAsync();
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        ICartRepository Cart { get; }
    }
}
