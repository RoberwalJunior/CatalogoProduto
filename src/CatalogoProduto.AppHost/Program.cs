var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CatalogoProduto_ApiService>("catalogoproduto-apiservice");

builder.Build().Run();
