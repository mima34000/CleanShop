using CleanShop.Domain.Entities;

namespace CleanShop.Domain.Interfaces;

// Repository för produktkategorier
public interface ICategoryRepository : IRepository<Category>
{
    // Kontrollerar om kategorin finns
    Task<bool> ExistsAsync(int id);
}