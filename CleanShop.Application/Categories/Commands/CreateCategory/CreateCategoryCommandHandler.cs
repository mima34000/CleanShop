using CleanShop.Application.Categories.Dtos;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Skapar och returnerar DTO
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name
        };

        // Sparar i db

        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        // Mappar om till DTO

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}