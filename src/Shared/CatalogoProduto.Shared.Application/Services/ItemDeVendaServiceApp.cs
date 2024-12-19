using AutoMapper;
using CatalogoProduto.Shared.Application.Abstractions;
using CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;

namespace CatalogoProduto.Shared.Application.Services;

public class ItemDeVendaServiceApp(IMapper mapper, IItemDeVendaService itemService) : IItemDeVendaServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IItemDeVendaService _itemService = itemService;

    public async Task<IEnumerable<ReadItemDeVendaDto>> RecuperarListaDeItemsDeVendas()
    {
        var lista = await _itemService.GetAll();
        return _mapper.Map<IEnumerable<ReadItemDeVendaDto>>(lista);
    }

    public async Task<IEnumerable<ReadItemDeVendaDto>> RecuperarListaDeItemsDaVenda(int vendaId)
    {
        var lista = await _itemService.GetItemsFromVenda(vendaId);
        return _mapper.Map<IEnumerable<ReadItemDeVendaDto>>(lista);
    }

    public async Task<ReadItemDeVendaCompletoDto?> RecuperarItemDeVendaPeloId(int id)
    {
        var entity = await _itemService.GetEntityById(id);
        return entity != null ? _mapper.Map<ReadItemDeVendaCompletoDto>(entity) : null;
    }

    public async Task<bool> AdicionarItemNaVenda(CreateItemDeVendaDto dto)
    {
        var entity = _mapper.Map<ItemDeVenda>(dto);
        return await _itemService.AddEntity(entity);
    }

    public async Task<bool> AtualizarItemNaVenda(int id, UpdateItemDeVendaDto dto)
    {
        var entity = await _itemService.GetEntityById(id);
        if (entity == null) return false;
        _mapper.Map(dto, entity);
        return await _itemService.UpdateEntity(entity);
    }

    public async Task<bool> DeletarItem(int id)
    {
        return await _itemService.DeleteEntity(id);
    }
}
