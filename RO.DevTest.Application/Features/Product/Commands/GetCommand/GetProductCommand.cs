using MediatR;

public record GetProductCommand(Guid Id): IRequest<GetProductResult>{}