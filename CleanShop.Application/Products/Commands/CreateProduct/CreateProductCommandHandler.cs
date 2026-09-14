using CleanShop.Application.Products.Dtos;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null)
        {
            throw new KeyNotFoundException($"Category with id {request.CategoryId} was not found.");
        }

        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId
        };

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            CategoryName = category.Name
        };
    }
}