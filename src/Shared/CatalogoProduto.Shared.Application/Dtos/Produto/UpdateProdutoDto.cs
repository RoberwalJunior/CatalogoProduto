using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.Shared.Application.Dtos.Produto;

public class UpdateProdutoDto
{
    [Required(ErrorMessage = "Código do produto é obrigatório")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "Nome do produto é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais de 100 caracteres!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Valor Unitário é obrigatório")]
    public decimal PrecoUnitario { get; set; }
}
