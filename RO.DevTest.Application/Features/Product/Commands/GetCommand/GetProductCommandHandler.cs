using MediatR;
using RO.DevTest.Domain.Exception;

public class GetProductCommandHandle(IProductRepository productRepository) : IRequestHandler<GetProductCommand , GetProductResult>
{   
    private readonly IProductRepository _productRepository = productRepository;
    
    public Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.Get( p => p.Id == request.Id);
        if (product is null){
            throw new BadRequestException("Produto nâo encontrado");
        }
        return Task.FromResult( new GetProductResult(product.Id, product.Name, product.Price, product.Stock, product.Description
        ));
    }
}