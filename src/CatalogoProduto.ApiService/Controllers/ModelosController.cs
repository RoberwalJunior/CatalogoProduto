using Microsoft.AspNetCore.Mvc;
using CatalogoProduto.Shared.Application.Dtos.Modelo;
using CatalogoProduto.Shared.Application.Abstractions;

namespace CatalogoProduto.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelosController(IModeloServiceApp service) : ControllerBase
{
    private readonly IModeloServiceApp _service = service;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeModelos()
    {
        return Ok(await _service.RecuperarListaDeModelos());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarModeloPeloId(int id)
    {
        var modelo = await _service.RecuperarModeloPeloId(id);
        return modelo != null ? Ok(modelo) : NotFound("Modelo do produto não encontrado!");
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarNovoModelo([FromBody] CreateUpdateModeloDto dto)
    {
        var resultado = await _service.AdicionarNovoModelo(dto);
        return resultado ? Ok("Modelo do produto cadastrado com sucesso!")
            : StatusCode(500, new { Message = "Erro ao cadastrar novo modelo de produto." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarModelo(int id, [FromBody] CreateUpdateModeloDto dto)
    {
        return await _service.AtualizarModelo(id, dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarModelo(int id)
    {
        return await _service.DeletarModelo(id) ? NoContent() : NotFound();
    }
}
