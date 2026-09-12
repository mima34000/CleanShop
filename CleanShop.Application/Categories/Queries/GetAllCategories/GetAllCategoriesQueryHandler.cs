using CleanShop.Application.Categories.Dtos;
using CleanShop.Domain.Interfaces;
using MediatR;

namespace CleanShop.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    // Fixar hela listan
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        // Hämtar alla kategorier

        var categories = await _categoryRepository.GetAllAsync();

        // Mappa till DTO

        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}