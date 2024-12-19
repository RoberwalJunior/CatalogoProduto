using CatalogoProduto.Shared.Application.Dtos.Modelo;
using CatalogoProduto.Shared.Application.Dtos.Venda;

namespace CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;

public class ReadItemDeVendaCompletoDto
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public ReadVendaDto? Venda { get; set; }
    public ReadModeloDto? Modelo { get; set; }
}
