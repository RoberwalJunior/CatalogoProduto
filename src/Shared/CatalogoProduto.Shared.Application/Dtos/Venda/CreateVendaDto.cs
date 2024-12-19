using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.Shared.Application.Dtos.Venda;

public class CreateVendaDto
{
    public DateTime DataDaCompra { get; private set; } = DateTime.Now;
    public int FormaDePagamento { get; set; }
}
