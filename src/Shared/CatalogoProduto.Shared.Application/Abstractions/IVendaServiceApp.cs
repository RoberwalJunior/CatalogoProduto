using CatalogoProduto.Shared.Application.Dtos.Venda;

namespace CatalogoProduto.Shared.Application.Abstractions;

public interface IVendaServiceApp
{
    public Task<IEnumerable<ReadVendaDto>> RecuperarListaDeVendas();
    public Task<ReadVendaCompletoDto?> RecuperarVendaPeloId(int id);
    public Task<bool> RegistrarNovaVenda(CreateVendaDto dto);
    public Task<bool> AtualizarVenda(int vendaId, UpdateVendaDto dto);
    public Task<bool> DeletarVenda(int vendaId);
    public Task<bool> RemoverItemNaVenda(int vendaId, int itemId);
}
