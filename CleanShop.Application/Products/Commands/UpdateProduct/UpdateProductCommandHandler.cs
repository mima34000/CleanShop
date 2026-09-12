using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    // Dependecy injection här
    public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }
     // Huvud logik här
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        //Hämtar produkten först
        var product = await _productRepository.GetByIdAsync(request.Id);

        //Hittades inte - Avbryt
        if (product is null)
        {
            return false;
        }
        // Kolla om kategorin finns
        var categoryExists = await _categoryRepository.ExistsAsync(request.CategoryId);
        if (!categoryExists)
        {
            throw new KeyNotFoundException($"Category with id {request.CategoryId} was not found.");
        }
        // Uppdaterad alla fält
        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.CategoryId = request.CategoryId;

        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();

        return true;
    }
}