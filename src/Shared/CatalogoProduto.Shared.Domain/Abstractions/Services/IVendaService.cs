using CatalogoProduto.Shared.Domain.Entities;

namespace CatalogoProduto.Shared.Domain.Abstractions.Services;

public interface IVendaService : IEntityService<Venda>
{
    public Task<IEnumerable<Venda>> GetVendasDoDia(DateTime date);
    public Task<IEnumerable<Venda>> GetVendasDeUmPeriodo(DateTime dataInicio, DateTime dataFinal);
}
