using CleanShop.Application.Products.Commands.CreateProduct;
using CleanShop.Application.Products.Commands.DeleteProduct;
using CleanShop.Application.Products.Commands.UpdateProduct;
using CleanShop.Application.Products.Dtos;
using CleanShop.Application.Products.Queries.GetAllProducts;
using CleanShop.Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    { 
        // Hämtar hela listan
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductCommand command)
    {
        // Skapar och returnerar DTO

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        // Kolla om id matchar

        if (id != command.Id)
        {
            return BadRequest();
        }

        var success = await _mediator.Send(command);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteProductCommand(id));

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}