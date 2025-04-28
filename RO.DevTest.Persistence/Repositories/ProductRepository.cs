using Microsoft.EntityFrameworkCore;
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly DefaultContext _context;

    public ProductRepository(DefaultContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProduct()
    {
        return await _context.Products.ToListAsync();
    }
}
