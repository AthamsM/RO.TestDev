using MediatR;

public record GetSaleCommand(DateTime StartDate, DateTime EndDate) : IRequest<GetSaleResponse>;
