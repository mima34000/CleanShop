namespace CleanShop.Domain.Entities;
/// <summary>
/// Representerar en produktkategori, exempelvis "Elektronik" eller "Livsmedel".

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigeringsegenskap för produkter som tillhör kategorin (en-till-många-relation).
    public ICollection<Product> Products { get; set; } = new List<Product>();
}