using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using CleanShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
    // Kollar om kategorin finns
    public async Task<bool> ExistsAsync(int id)
    {
        return await _dbSet.AnyAsync(c => c.Id == id);
    }
}