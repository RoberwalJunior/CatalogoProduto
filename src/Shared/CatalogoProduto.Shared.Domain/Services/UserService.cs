using Microsoft.AspNetCore.Identity;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;

namespace CatalogoProduto.Shared.Domain.Services;

public class UserService(UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public async Task<bool> RegisterUser(string email, string password)
    {
        var user = new ApplicationUser { UserName = email, Email = email };
        return (await _userManager.CreateAsync(user, password)).Succeeded;
    }

    public async Task<bool> Login(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password,
            isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded;
    }
}
