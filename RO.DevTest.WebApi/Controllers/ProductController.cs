using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command) {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateProduct), new { id = result.Id }, result);
    }
    [HttpGet]
    [ProducesResponseType(typeof(GetProductResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProduct([FromBody] GetProductCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateProductResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteProductCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
