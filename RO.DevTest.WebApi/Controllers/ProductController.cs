using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Domain.Enums;

[Route("api/products")]
[ApiController]
public class ProductsController(IMediator mediator, IProductRepository productsRepository) : ControllerBase {
    private readonly IMediator _mediator = mediator;
    private readonly IProductRepository _productsRepository = productsRepository;

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command) {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateProduct), new { id = result.Id }, result);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("product")]
    [ProducesResponseType(typeof(GetProductResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProduct([FromBody] GetProductCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet]
    [ProducesResponseType(typeof(GetProductResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProduct() {
        var result = await _productsRepository.GetAllProduct();
        return Ok(result);
    }
    [Authorize(Roles = "Admin")]
    [HttpPut]
    [ProducesResponseType(typeof(UpdateProductCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete]
    [ProducesResponseType(typeof(DeleteProductCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
