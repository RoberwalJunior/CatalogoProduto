using CatalogoProduto.Shared.Application.Dtos.Modelo;

namespace CatalogoProduto.Shared.Application.Dtos.Produto;

public class ReadProdutoCompletoDto
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public decimal PrecoUnitario { get; set; }
    public ICollection<ReadModeloDto>? Modelos { get; set; }
}
