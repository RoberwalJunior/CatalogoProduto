using AutoMapper;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Application.Dtos.Modelo;

namespace CatalogoProduto.Shared.Application.Profiles;

public class ModeloProfile : Profile
{
    public ModeloProfile()
    {
        CreateMap<Modelo, ReadModeloDto>();
        CreateMap<Modelo, ReadModeloCompletoDto>();
        CreateMap<CreateUpdateModeloDto, Modelo>();
    }
}
