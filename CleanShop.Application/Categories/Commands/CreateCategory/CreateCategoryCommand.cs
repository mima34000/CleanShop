using CleanShop.Application.Categories.Dtos;
using MediatR;

namespace CleanShop.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public string Name { get; set; } = string.Empty;
}