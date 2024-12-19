using Microsoft.AspNetCore.Mvc;
using CatalogoProduto.Shared.Application.Dtos.Venda;
using CatalogoProduto.Shared.Application.Abstractions;

namespace CatalogoProduto.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendasController(IVendaServiceApp service, IItemDeVendaServiceApp itemService) : ControllerBase
{
    private readonly IVendaServiceApp _vendaService = service;
    private readonly IItemDeVendaServiceApp _itemService = itemService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeVendas()
    {
        return Ok(await _vendaService.RecuperarListaDeVendas());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarVendaPeloId(int id)
    {
        var dto = await _vendaService.RecuperarVendaPeloId(id);
        return dto != null ? Ok(dto) : NotFound("Venda não encontrado!");
    }

    [HttpGet("{id}/Itens")]
    public async Task<IActionResult> RecuperarListaDeItemsDaVenda(int id)
    {
        return Ok(await _itemService.RecuperarListaDeItemsDaVenda(id));
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarNovaVenda([FromBody] CreateVendaDto dto)
    {
        var resultado = await _vendaService.RegistrarNovaVenda(dto);
        return resultado ? Ok("Venda registrada com sucesso!")
            : StatusCode(500, new { Message = "Erro ao registrar venda." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarVenda(int id, [FromBody] UpdateVendaDto dto)
    {
        return await _vendaService.AtualizarVenda(id, dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarVenda(int id)
    {
        return await _vendaService.DeletarVenda(id) ? NoContent() : NotFound();
    }
}
