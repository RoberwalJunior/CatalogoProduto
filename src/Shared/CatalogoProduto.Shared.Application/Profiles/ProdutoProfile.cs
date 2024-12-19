using AutoMapper;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Application.Dtos.Produto;

namespace CatalogoProduto.Shared.Application.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ReadProdutoDto>();
        CreateMap<Produto, ReadProdutoCompletoDto>();
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
    }
}
