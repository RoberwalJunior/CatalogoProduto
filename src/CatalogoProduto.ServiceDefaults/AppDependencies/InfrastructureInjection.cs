using CatalogoProduto.Shared.Domain.Abstractions.Repositories;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Services;
using CatalogoProduto.Shared.Infrastructure.Context;
using CatalogoProduto.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoProduto.ServiceDefaults.AppDependencies;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddTransient<IProdutoRepository, ProdutoRepository>();
        services.AddTransient<IModeloRepository, ModeloRepository>();
        services.AddTransient<IVendaRepository, VendaRepository>();
        services.AddTransient<IItemDeVendaRepository, ItemDeVendaRepository>();

        services.AddTransient<IProdutoService, ProdutoService>();
        services.AddTransient<IModeloService, ModeloService>();
        services.AddTransient<IVendaService, VendaService>();
        services.AddTransient<IItemDeVendaService, ItemDeVendaService>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }
}
