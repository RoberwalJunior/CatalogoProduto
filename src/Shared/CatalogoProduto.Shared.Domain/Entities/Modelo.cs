namespace CatalogoProduto.Shared.Domain.Entities;

public class Modelo : Entity
{
    public string? Descricao { get; set; }
    public int QuantidadeEstoque { get; set; }
    public int ProdutoId { get; set; }
    public virtual Produto? Produto { get; set; }
    public virtual ICollection<ItemDeVenda>? Itens { get; set; }
}
