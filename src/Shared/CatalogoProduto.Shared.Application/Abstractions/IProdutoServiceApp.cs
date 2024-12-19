using CatalogoProduto.Shared.Application.Dtos.Produto;

namespace CatalogoProduto.Shared.Application.Abstractions;

public interface IProdutoServiceApp
{
    public Task<IEnumerable<ReadProdutoDto>> RecuperarListaDeProdutos();
    public Task<ReadProdutoCompletoDto?> RecuperarProdutoPeloId(int id);
    public Task<bool> AdicionarNovoProduto(CreateProdutoDto dto);
    public Task<bool> AtualizarProduto(int id, UpdateProdutoDto dto);
    public Task<bool> DeletarProduto(int id);
}
