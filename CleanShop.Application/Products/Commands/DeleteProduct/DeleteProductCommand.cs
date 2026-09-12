using MediatR;

namespace CleanShop.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteProductCommand(int id)
    {
        Id = id;
    }
}