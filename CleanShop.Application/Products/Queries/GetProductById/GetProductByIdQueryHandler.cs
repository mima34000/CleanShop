using CleanShop.Application.Products.Dtos;
using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // Hämtar en specifik
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        // Hittar med kategori

        var product = await _productRepository.GetByIdWithCategoryAsync(request.Id);
        if (product is null)
        {
            return null;
        }
        // Mappa och returnera
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.Name ?? string.Empty
        };
    }
}