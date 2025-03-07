﻿using Microsoft.AspNetCore.Mvc;
using CatalogoProduto.Shared.Application.Dtos.User;
using CatalogoProduto.Shared.Application.Abstractions;

namespace CatalogoProduto.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserServiceApp userService) : ControllerBase
{
    private readonly IUserServiceApp _userService = userService;

    [HttpPost("Register")]
    public async Task<IActionResult> CreateUser([FromBody] UserInfoDto userInfoDto)
    {
        var result = await _userService.RegistrarUsuario(userInfoDto);
        return result ? Ok(userInfoDto) : BadRequest("Usuário ou senha inválidos!");
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserTokenDto>> Login([FromBody] UserInfoDto userInfo)
    {
        var userTokenDto = await _userService.Login(userInfo);

        if (userTokenDto == null)
        {
            ModelState.AddModelError(string.Empty, "Login inválido.");
            return BadRequest(ModelState);
        }

        return userTokenDto;
    }
}
