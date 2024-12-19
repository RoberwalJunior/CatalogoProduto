using CatalogoProduto.Shared.Application.Dtos.Modelo;

namespace CatalogoProduto.Shared.Application.Abstractions;

public interface IModeloServiceApp
{
    public Task<IEnumerable<ReadModeloDto>> RecuperarListaDeModelos();
    public Task<IEnumerable<ReadModeloDto>> RecuperarListaDeModelosDoProduto(int produtoId);
    public Task<ReadModeloCompletoDto?> RecuperarModeloPeloId(int id);
    public Task<bool> AdicionarNovoModelo(CreateUpdateModeloDto dto);
    public Task<bool> AtualizarModelo(int id, CreateUpdateModeloDto dto);
    public Task<bool> AtualizarEstoque(int modeloId, int quantidade);
    public Task<bool> DeletarModelo(int id);
}
