using CleanShop.Application.Products.Dtos;
using MediatR;

namespace CleanShop.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}