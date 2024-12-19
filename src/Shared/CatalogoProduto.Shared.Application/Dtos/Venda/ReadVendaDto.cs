namespace CatalogoProduto.Shared.Application.Dtos.Venda;

public class ReadVendaDto
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataDaCompra { get; set; }
    public string? FormaDePagamento { get; set; }
}
