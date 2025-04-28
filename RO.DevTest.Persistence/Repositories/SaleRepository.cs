using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.Repositories;

public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    private readonly DefaultContext _context;
    public SaleRepository(DefaultContext context) : base(context) {
        _context = context;
     }

    public async Task<List<Sale>> GetSalesByPeriod(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Sale>()
            .Include(s => s.Product) // para poder pegar o nome do produto no Handler
            .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Sale>> GetAllSale(){
        return await _context.Sales.ToListAsync();
    }
}