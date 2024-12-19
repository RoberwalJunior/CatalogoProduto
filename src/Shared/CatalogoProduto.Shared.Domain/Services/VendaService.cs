using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;

namespace CatalogoProduto.Shared.Domain.Services;

public class VendaService(IVendaRepository repository)
    : EntityService<Venda>(repository), IVendaService
{
    public async Task<IEnumerable<Venda>> GetVendasDoDia(DateTime date)
    {
        return await _repository.GetAll(x => x.DataDaCompra.Equals(date));
    }

    public async Task<IEnumerable<Venda>> GetVendasDeUmPeriodo(DateTime dataInicio, DateTime dataFinal)
    {
        return await _repository.GetAll(x => x.DataDaCompra >= dataInicio && x.DataDaCompra <= dataFinal);
    }
}
