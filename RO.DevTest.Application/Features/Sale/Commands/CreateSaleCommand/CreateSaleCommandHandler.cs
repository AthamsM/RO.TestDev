using MediatR;
using RO.DevTest.Domain.Exception;

public class CreateSaleCommandHandler(IProductRepository productRepository, ISaleRepository saleRepository) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ISaleRepository _saleRepository = saleRepository;

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.Get(p => p.Id == request.ProductId);
        if (product == null)
            throw new BadRequestException("Produto não encontrado");

        if (product.Stock < request.Quantity)
            throw new BadRequestException("Estoque insuficiente");

        product.Stock -= request.Quantity;

        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            UserId = request.UserId,
            Quantity = request.Quantity,
            TotalPrice = product.Price * request.Quantity,
            SaleDate = DateTime.UtcNow
        };

        await _saleRepository.CreateAsync(sale);

        return new CreateSaleResult(
            sale.Id,
            sale.ProductId,
            sale.UserId,
            sale.Quantity,
            sale.TotalPrice,
            sale.SaleDate
        );
    }
}
