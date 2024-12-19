using AutoMapper;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Application.Abstractions;
using CatalogoProduto.Shared.Application.Dtos.Produto;
using CatalogoProduto.Shared.Domain.Abstractions.Services;

namespace CatalogoProduto.Shared.Application.Services;

public class ProdutoServiceApp(IMapper mapper, IProdutoService service) : IProdutoServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IProdutoService _service = service;

    public async Task<IEnumerable<ReadProdutoDto>> RecuperarListaDeProdutos()
    {
        var lista = await _service.GetAll();
        return _mapper.Map<IEnumerable<ReadProdutoDto>>(lista);
    }

    public async Task<ReadProdutoCompletoDto?> RecuperarProdutoPeloId(int id)
    {
        var entity = await _service.GetEntityById(id);
        return entity != null ? _mapper.Map<ReadProdutoCompletoDto>(entity) : null;
    }

    public async Task<bool> AdicionarNovoProduto(CreateProdutoDto dto)
    {
        var entity = _mapper.Map<Produto>(dto);
        return await _service.AddEntity(entity);
    }

    public async Task<bool> AtualizarProduto(int id, UpdateProdutoDto dto)
    {
        var entity = await _service.GetEntityById(id);
        if (entity == null) return false;
        _mapper.Map(dto, entity);
        return await _service.UpdateEntity(entity);
    }

    public async Task<bool> DeletarProduto(int id)
    {
        return await _service.DeleteEntity(id);
    }
}
