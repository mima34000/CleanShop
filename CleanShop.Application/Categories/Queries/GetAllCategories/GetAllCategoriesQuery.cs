using CleanShop.Application.Categories.Dtos;
using MediatR;

namespace CleanShop.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}