using CatalogoProduto.Shared.Application.Dtos.User;

namespace CatalogoProduto.Shared.Application.Abstractions;

public interface IUserServiceApp
{
    public Task<bool> RegistrarUsuario(UserInfoDto userDto);
    public Task<UserTokenDto?> Login(UserInfoDto userDto);
}
