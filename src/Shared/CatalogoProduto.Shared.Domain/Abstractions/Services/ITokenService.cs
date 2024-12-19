namespace CatalogoProduto.Shared.Domain.Abstractions.Services;

public interface ITokenService
{
    public string GenerateToken(string email);
}
