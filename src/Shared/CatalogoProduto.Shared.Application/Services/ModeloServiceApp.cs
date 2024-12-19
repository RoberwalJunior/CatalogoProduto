using AutoMapper;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Application.Abstractions;
using CatalogoProduto.Shared.Application.Dtos.Modelo;
using CatalogoProduto.Shared.Domain.Abstractions.Services;

namespace CatalogoProduto.Shared.Application.Services;

public class ModeloServiceApp(IMapper mapper, IModeloService service) : IModeloServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IModeloService _service = service;

    public async Task<IEnumerable<ReadModeloDto>> RecuperarListaDeModelos()
    {
        var lista = await _service.GetAll();
        return _mapper.Map<IEnumerable<ReadModeloDto>>(lista);
    }

    public async Task<IEnumerable<ReadModeloDto>> RecuperarListaDeModelosDoProduto(int produtoId)
    {
        var lista = await _service.GetModelosFromProduto(produtoId);
        return _mapper.Map<IEnumerable<ReadModeloDto>>(lista);
    }

    public async Task<ReadModeloCompletoDto?> RecuperarModeloPeloId(int id)
    {
        var entity = await _service.GetEntityById(id);
        return entity != null ? _mapper.Map<ReadModeloCompletoDto>(entity) : null;
    }

    public async Task<bool> AdicionarNovoModelo(CreateUpdateModeloDto dto)
    {
        var entity = _mapper.Map<Modelo>(dto);
        return await _service.AddEntity(entity);
    }

    public async Task<bool> AtualizarModelo(int id, CreateUpdateModeloDto dto)
    {
        var entity = await _service.GetEntityById(id);
        if (entity == null) return false;
        _mapper.Map(dto, entity);
        return await _service.UpdateEntity(entity);
    }

    public async Task<bool> AtualizarEstoque(int id, int quantidade)
    {
        var entity = await _service.GetEntityById(id);
        if (entity == null || (quantidade < 0 && entity.QuantidadeEstoque < quantidade)) return false;
        entity.QuantidadeEstoque += quantidade;
        return await _service.UpdateEntity(entity);
    }

    public async Task<bool> DeletarModelo(int id)
    {
        return await _service.DeleteEntity(id);
    }
}
