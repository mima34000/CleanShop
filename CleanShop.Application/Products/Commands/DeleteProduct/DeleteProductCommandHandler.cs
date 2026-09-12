using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    // Standard repo sak
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // Fixar borttagningen här
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Hittar rätt produkt

        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product is null)
        {
            return false;
        }
        // Tar bort den
        _productRepository.Delete(product);
        await _productRepository.SaveChangesAsync();

        return true;
    }
}