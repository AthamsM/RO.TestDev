
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.Repositories;

public class ProductRepository(DefaultContext context): BaseRepository<Product>(context), IProductRepository{}
