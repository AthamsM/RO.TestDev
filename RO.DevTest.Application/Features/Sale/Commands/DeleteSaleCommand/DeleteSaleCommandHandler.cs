using MediatR;
using RO.DevTest.Domain.Exception;

public class DeleteSaleCommandHandler(ISaleRepository saleRepository): IRequestHandler<DeleteSaleComand, Unit>{
    private readonly ISaleRepository _saleRepository = saleRepository;

    public Task<Unit> Handle(DeleteSaleComand request, CancellationToken cancellationToken){

        var sale = _saleRepository.Get(s => s.Id == request.Id);
        if(sale == null){
            throw new BadRequestException("Venda não encontrada");
        }
        _saleRepository.Delete(sale);
        return Task.FromResult(Unit.Value);
    }
}