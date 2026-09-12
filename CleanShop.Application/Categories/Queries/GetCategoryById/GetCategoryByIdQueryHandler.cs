using CleanShop.Application.Categories.Dtos;
using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    // Hämtar en specifik
    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // Hittar rätt kategori

        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category is null)
        {
            return null;
        }
        // Mappa till DTO

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}