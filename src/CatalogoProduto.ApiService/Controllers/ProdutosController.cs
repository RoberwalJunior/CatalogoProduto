using Microsoft.AspNetCore.Mvc;
using CatalogoProduto.Shared.Application.Abstractions;
using CatalogoProduto.Shared.Application.Dtos.Produto;

namespace CatalogoProduto.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoServiceApp produtoService, IModeloServiceApp modeloService) : ControllerBase
{
    private readonly IProdutoServiceApp _produtoService = produtoService;
    private readonly IModeloServiceApp _modeloService = modeloService;

    [HttpGet]
    public async Task<IActionResult> RecuperarListaDeProdutos()
    {
        return Ok(await _produtoService.RecuperarListaDeProdutos());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarProdutoPeloId(int id)
    {
        var produto = await _produtoService.RecuperarProdutoPeloId(id);
        return produto != null ? Ok(produto) : NotFound("Produto não encontrado!");
    }

    [HttpGet("{id}/Modelos")]
    public async Task<IActionResult> RecuperarListaDeModelosDoProduto(int id)
    {
        return Ok(await _modeloService.RecuperarListaDeModelosDoProduto(id));
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarNovoProduto([FromBody] CreateProdutoDto dto)
    {
        var resultado = await _produtoService.AdicionarNovoProduto(dto);
        return resultado ? Ok("Produto cadastrado com sucesso!")
            : StatusCode(500, new { Message = "Erro ao cadastrar novo produto." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] UpdateProdutoDto dto)
    {
        return await _produtoService.AtualizarProduto(id, dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        return await _produtoService.DeletarProduto(id) ? NoContent() : NotFound();
    }
}
