namespace CatalogoProduto.Shared.Domain.Entities;

public class ItemDeVenda : Entity
{
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }

    public int VendaId { get; set; }
    public virtual Venda? Venda { get; set; }

    public int ModeloId { get; set; }
    public virtual Modelo? Modelo { get; set; }
}
