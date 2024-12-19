using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.Shared.Application.Dtos.Modelo;

public class CreateUpdateModeloDto
{
    [Required(ErrorMessage = "Descrição é obrigatório")]
    [StringLength(255, ErrorMessage = "O nome do produto não pode ter mais de 255 caracteres!")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Quantidade de estoque é obrigatório")]
    public int QuantidadeEstoque { get; set; }

    [Required(ErrorMessage = "Produto é obrigatório")]
    public int ProdutoId { get; set; }
}
