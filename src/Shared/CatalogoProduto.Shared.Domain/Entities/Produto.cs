namespace CatalogoProduto.Shared.Domain.Entities;

public class Produto : Entity
{
    public int Codigo { get; set; }
    public string? Nome { get; set; }
    public decimal PrecoUnitario { get; set; }
    public virtual ICollection<Modelo>? Modelos { get; set; }
}
