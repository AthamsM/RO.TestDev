using MediatR;

public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository = productRepository;


    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            Description = request.Description
        };

        await _productRepository.CreateAsync(product);
        return new CreateProductResult(product.Id);
    }
}
