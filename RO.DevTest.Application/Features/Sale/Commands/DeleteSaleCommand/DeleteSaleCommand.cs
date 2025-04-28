using MediatR;

public record DeleteSaleComand(Guid Id): IRequest<Unit>{}