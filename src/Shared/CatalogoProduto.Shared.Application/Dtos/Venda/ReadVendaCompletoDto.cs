using CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;

namespace CatalogoProduto.Shared.Application.Dtos.Venda;

public class ReadVendaCompletoDto
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataDaCompra { get; set; }
    public string? FormaDePagamento { get; set; }
    public ICollection<ReadItemDeVendaDto>? Itens { get; set; }
}
