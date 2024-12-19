using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.Shared.Application.Dtos.Venda;

public class UpdateVendaDto
{
    [Required(ErrorMessage = "Data da compra é obrigatório!")]
    public DateTime DataDaCompra { get; set; }

    [Required(ErrorMessage = "Forma de pagamento é obrigatório!")]
    public int FormaDePagamento { get; set; }
}
