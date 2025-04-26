using System.ComponentModel;
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.Repositories;

public class SaleRepository(DefaultContext context) : BaseRepository<Sale>(context), ISaleRepository{}