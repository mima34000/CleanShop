using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    // Skapar kategori
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Skapar nytt objekt

        var category = new Category
        {
            Name = request.Name
        };

        // Sparar i db

        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        // Returnerar det nya id-t

        return category.Id;
    }
}