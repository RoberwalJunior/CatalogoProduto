using AutoMapper;
using CatalogoProduto.Shared.Application.Dtos.Venda;
using CatalogoProduto.Shared.Application.Abstractions;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Entities;

namespace CatalogoProduto.Shared.Application.Services;

public class VendaServiceApp(IMapper mapper, IVendaService vendaService) : IVendaServiceApp
{
    private readonly IMapper _mapper = mapper;
    private readonly IVendaService _vendaService = vendaService;

    public async Task<IEnumerable<ReadVendaDto>> RecuperarListaDeVendas()
    {
        var lista = await _vendaService.GetAll();
        return _mapper.Map<IEnumerable<ReadVendaDto>>(lista);
    }

    public async Task<ReadVendaCompletoDto?> RecuperarVendaPeloId(int id)
    {
        var entity = await _vendaService.GetEntityById(id);
        return entity != null ? _mapper.Map<ReadVendaCompletoDto>(entity) : null;
    }

    public async Task<bool> RegistrarNovaVenda(CreateVendaDto dto)
    {
        var entity = _mapper.Map<Venda>(dto);
        return await _vendaService.AddEntity(entity);
    }

    //public async Task<bool> AdicionarItemNaVenda(int vendaId, CreateItemDeVendaDto dto)
    //{
    //    var venda = await _vendaService.GetEntityById(vendaId);
    //    if (venda != null && venda.Itens != null)
    //    {
    //        var item = _mapper.Map<ItemDeVenda>(dto);
    //        venda.Itens.Add(item);
    //        venda.ValorTotal += item.Valor;
    //        return await _vendaService.UpdateEntity(venda);
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public async Task<bool> AtualizarVenda(int vendaId, UpdateVendaDto dto)
    {
        var entity = await _vendaService.GetEntityById(vendaId);
        if (entity == null) return false;
        _mapper.Map(dto, entity);
        return await _vendaService.UpdateEntity(entity);
    }

    public async Task<bool> DeletarVenda(int vendaId)
    {
        return await _vendaService.DeleteEntity(vendaId);
    }

    public async Task<bool> RemoverItemNaVenda(int vendaId, int itemId)
    {
        var entity = await _vendaService.GetEntityById(vendaId);
        if (entity != null && entity.Itens != null)
        {
            var item = entity.Itens.FirstOrDefault(item => item.Id == itemId);
            if (item != null)
            {
                entity.ValorTotal -= item.Valor;
                entity.Itens.Remove(item);
                return await _vendaService.UpdateEntity(entity);
            }
        }

        return false;
    }
}
