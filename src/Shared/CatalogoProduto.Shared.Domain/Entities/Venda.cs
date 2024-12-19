using CatalogoProduto.Shared.Domain.Enums;

namespace CatalogoProduto.Shared.Domain.Entities;

public class Venda : Entity
{
    public decimal ValorTotal { get; set; }
    public DateTime DataDaCompra { get; set; }
    public FormaDePagamento FormaDePagamento { get; set; }
    public virtual ICollection<ItemDeVenda>? Itens { get; set; }
}
