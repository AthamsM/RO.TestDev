using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/sale")]
public class SalesController(IMediator mediator, ISaleRepository saleRepository) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    private readonly ISaleRepository _saleRepository = saleRepository;

    [HttpPost]
    [ProducesResponseType(typeof(CreateSaleResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSaleCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
    }

    //[Authorize (Roles = "Admin")]
    [HttpGet("period")]
    [ProducesResponseType(typeof(GetSaleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSalesByPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var query = new GetSaleCommand(startDate, endDate);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllSaleResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllSales()
    {
        var result = await _saleRepository.GetAllSale();
        return Ok(result);
    }
    
    //[Authorize (Roles = "Admin")]
    [HttpDelete]
    [ProducesResponseType(typeof(DeleteSaleComand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteSale([FromBody] DeleteSaleComand comand)
    {
        var result = await _mediator.Send(comand);
        return Ok(result);
    }
}
