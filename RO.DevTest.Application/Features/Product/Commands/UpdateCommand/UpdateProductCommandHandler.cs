using MediatR;
using RO.DevTest.Domain.Exception;

public class UpdateProductCommandHandle(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository = productRepository;

    public Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.Get(p => p.Id == request.Id);
        if(product == null){
            throw new BadRequestException("Produto não encontrado");
        }
        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.Description = request.Description;
        _productRepository.Update(product);
        return Task.FromResult(new UpdateProductResult(product.Name, product.Price, product.Stock, product.Description));
    }
}