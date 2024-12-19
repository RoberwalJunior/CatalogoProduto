using AutoMapper;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Application.Dtos.ItemDeVenda;

namespace CatalogoProduto.Shared.Application.Profiles;

public class ItemDeVendaProfile : Profile
{
    public ItemDeVendaProfile()
    {
        CreateMap<ItemDeVenda, ReadItemDeVendaDto>();
        CreateMap<ItemDeVenda, ReadItemDeVendaCompletoDto>();
        CreateMap<CreateItemDeVendaDto, ItemDeVenda>();
        CreateMap<UpdateItemDeVendaDto, ItemDeVenda>();
    }
}
