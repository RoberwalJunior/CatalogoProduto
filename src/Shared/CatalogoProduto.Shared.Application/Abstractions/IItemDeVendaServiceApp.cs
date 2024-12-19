using CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;

namespace CatalogoProduto.Shared.Application.Abstractions;

public interface IItemDeVendaServiceApp
{
    public Task<IEnumerable<ReadItemDeVendaDto>> RecuperarListaDeItemsDeVendas();
    public Task<IEnumerable<ReadItemDeVendaDto>> RecuperarListaDeItemsDaVenda(int vendaId);
    public Task<ReadItemDeVendaCompletoDto?> RecuperarItemDeVendaPeloId(int id);
    public Task<bool> AdicionarItemNaVenda(CreateItemDeVendaDto dto);
    public Task<bool> AtualizarItemNaVenda(int id, UpdateItemDeVendaDto dto);
    public Task<bool> DeletarItem(int id);
}
