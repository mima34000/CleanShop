using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using CleanShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    // Hämtar allt och inkluderar kategori
    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return await _dbSet.Include(p => p.Category).ToListAsync();
    }
    // Hittar en med kategori via id
    public async Task<Product?> GetByIdWithCategoryAsync(int id)
    {
        return await _dbSet.Include(p => p.Category)
                            .FirstOrDefaultAsync(p => p.Id == id);
    }
}