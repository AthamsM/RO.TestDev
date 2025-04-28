
using RO.DevTest.Application.Contracts.Persistance.Repositories;

public interface IProductRepository : IBaseRepository<Product> {
    Task<List<Product>> GetAllProduct();
}