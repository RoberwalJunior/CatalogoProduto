using AutoMapper;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Application.Dtos.Venda;

namespace CatalogoProduto.Shared.Application.Profiles;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, ReadVendaDto>()
            .ForMember(dto => dto.FormaDePagamento,
                opt => opt.MapFrom(entity => entity.FormaDePagamento.ToString()));
        CreateMap<Venda, ReadVendaCompletoDto>()
            .ForMember(dto => dto.FormaDePagamento,
                opt => opt.MapFrom(entity => entity.FormaDePagamento.ToString()));
        CreateMap<CreateVendaDto, Venda>();
        CreateMap<UpdateVendaDto, Venda>();
    }
}
