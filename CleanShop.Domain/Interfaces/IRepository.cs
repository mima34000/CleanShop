namespace CleanShop.Domain.Interfaces;

// Grundläggande repository för CRUD
public interface IRepository<T> where T : class
{
    // Hämtar på ID
    Task<T?> GetByIdAsync(int id);

    // Hämtar alla

    Task<IEnumerable<T>> GetAllAsync();

    // Lägger till
    Task AddAsync(T entity);

    // Uppdaterar
    void Update(T entity);

    // Tar bort

    void Delete(T entity);

    // Sparar till databasen
    Task<int> SaveChangesAsync();
}