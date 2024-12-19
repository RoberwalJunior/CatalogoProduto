using Microsoft.Extensions.DependencyInjection;
using CatalogoProduto.Shared.Application.Services;
using CatalogoProduto.Shared.Application.Abstractions;

namespace CatalogoProduto.ServiceDefaults.AppDependencies;

public static class ApplicationInjection
{
    public static IServiceCollection AddApplicationInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient<IProdutoServiceApp, ProdutoServiceApp>();
        services.AddTransient<IModeloServiceApp, ModeloServiceApp>();
        services.AddTransient<IVendaServiceApp, VendaServiceApp>();
        services.AddTransient<IItemDeVendaServiceApp, ItemDeVendaServiceApp>();
        services.AddTransient<IUserServiceApp, UserServiceApp>();

        return services;
    }
}
