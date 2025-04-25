using MediatR;
using RO.DevTest.Domain.Exception;

public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository = productRepository;

    public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.Get(p => p.Id == request.Id);
        if(product == null){
            throw new BadRequestException("Produto não encontrado");
        }
        _productRepository.Delete(product);
        return Task.FromResult(Unit.Value);
    }
}