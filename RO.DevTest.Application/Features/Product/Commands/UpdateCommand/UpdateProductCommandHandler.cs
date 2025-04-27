using MediatR;
using RO.DevTest.Domain.Exception;

public class UpdateProductCommandHandle(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.Get(p => p.Id == request.Id);
        if(product == null){
            throw new BadRequestException("Produto não encontrado");
        }
        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.Description = request.Description;
        await _productRepository.Update(product);
        return Unit.Value;
    }
}