namespace CleanShop.Domain.Entities;

// Representerar en produkt i systemet med tillhörande lager- och prisuppgifter.

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    // Aktuellt antal artiklar i lager.
    public int Stock { get; set; }

    // Foreign key för den kategori som produkten tillhör.
    public int CategoryId { get; set; }

    // Navigeringsegenskap för kopplingen till produktens kategori.
    public Category? Category { get; set; }
}