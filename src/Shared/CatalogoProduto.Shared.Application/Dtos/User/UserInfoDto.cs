﻿using System.ComponentModel.DataAnnotations;

namespace CatalogoProduto.Shared.Application.Dtos.User;

public class UserInfoDto
{
    [Required(ErrorMessage = "Email é obrigatório")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatório")]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }
}
