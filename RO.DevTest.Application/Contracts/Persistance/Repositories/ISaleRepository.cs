using RO.DevTest.Application.Contracts.Persistance.Repositories;

public interface ISaleRepository : IBaseRepository<Sale>{
    Task<List<Sale>> GetSalesByPeriod(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<List<Sale>> GetAllSale();
}