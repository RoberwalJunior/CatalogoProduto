using Microsoft.AspNetCore.Mvc;
using CatalogoProduto.Shared.Application.Abstractions;
using CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;

namespace CatalogoProduto.ApiService.Controllers;

[ApiController]
[Route("api/Itens")]
public class ItensVendaController(IItemDeVendaServiceApp service, IModeloServiceApp modeloService) : ControllerBase
{
    private readonly IItemDeVendaServiceApp _service = service;
    private readonly IModeloServiceApp _modeloService = modeloService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeItemsDeVendas()
    {
        return Ok(await _service.RecuperarListaDeItemsDeVendas());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarItemDeVendaPeloId(int id)
    {
        var entity = await _service.RecuperarItemDeVendaPeloId(id);
        return entity != null ? Ok(entity) : NotFound("Item de venda não encontrado!");
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarNovaVenda([FromBody] CreateItemDeVendaDto dto)
    {
        var seOItemFoiAdicionadoComExito = await _service.AdicionarItemNaVenda(dto);
        var seOEstoqueDoModeloFoiAtualizado = await _modeloService.AtualizarEstoque(dto.ModeloId, dto.Quantidade);
        return seOItemFoiAdicionadoComExito && seOEstoqueDoModeloFoiAtualizado ? Ok("Item adicionada com sucesso!")
            : StatusCode(500, new { Message = "Erro ao adicionar item na venda." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarItemNaVenda(int id, [FromBody] UpdateItemDeVendaDto dto)
    {
        return await _service.AtualizarItemNaVenda(id, dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarVenda(int id)
    {
        return await _service.DeletarItem(id) ? NoContent() : NotFound();
    }
}
