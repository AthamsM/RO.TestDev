using MediatR;

public record CreateSaleCommand(Guid ProductId, Guid UserId, int Quantity) : IRequest<CreateSaleResult>;
