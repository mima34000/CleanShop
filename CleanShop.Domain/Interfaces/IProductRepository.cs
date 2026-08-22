using CleanShop.Domain.Entities;

namespace CleanShop.Domain.Interfaces;

// Repository för produkter
public interface IProductRepository : IRepository<Product>
{
    // Hämtar alla produkter inklusive kategori
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();

    // Hämtar produkt på ID inklusive kategori
    Task<Product?> GetByIdWithCategoryAsync(int id);
}