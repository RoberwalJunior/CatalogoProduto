namespace CatalogoProduto.Shared.Application.Dtos.Produto;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public decimal PrecoUnitario { get; set; }
}
