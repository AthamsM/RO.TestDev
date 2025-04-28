using MediatR;

public class GetSaleCommandHandler(ISaleRepository saleRepository) : IRequestHandler<GetSaleCommand, GetSaleResponse>
{
    private readonly ISaleRepository _saleRepository = saleRepository;

    public async Task<GetSaleResponse> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var startDateUtc = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
        var endDateUtc = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);

        var sales = await _saleRepository.GetSalesByPeriod(startDateUtc, endDateUtc, cancellationToken);

        var totalSales = sales.Count;
        var totalRevenue = sales.Sum(s => s.TotalPrice);

        var productsRevenue = sales
            .GroupBy(s => s.Product.Name)
            .Select(g => new ProductRevenue
            {
                ProductName = g.Key,
                Revenue = g.Sum(s => s.TotalPrice)
            })
            .ToList();

        return new GetSaleResponse
        {
            TotalSales = totalSales,
            TotalRevenue = totalRevenue,
            ProductsRevenue = productsRevenue
        };
    }
}
