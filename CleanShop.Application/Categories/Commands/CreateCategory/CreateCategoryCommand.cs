using MediatR;

namespace CleanShop.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
}