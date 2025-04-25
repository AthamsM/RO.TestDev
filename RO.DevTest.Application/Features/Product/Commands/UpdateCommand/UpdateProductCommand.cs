using MediatR;

public record UpdateProductCommand(Guid Id, string Name, float Price, int Stock, string Description): IRequest<UpdateProductResult>{}