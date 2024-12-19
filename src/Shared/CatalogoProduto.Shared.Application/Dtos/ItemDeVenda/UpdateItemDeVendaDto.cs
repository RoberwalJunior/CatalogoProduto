﻿using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;

public class UpdateItemDeVendaDto
{
    [Required(ErrorMessage = "O Id do Modelo do produto é obrigatório!")]
    public int ModeloId { get; set; }

    [Required(ErrorMessage = "Quantidade do produto é obrigatório!")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "O Valor do produto é obrigatório!")]
    public decimal Valor { get; set; }
}
