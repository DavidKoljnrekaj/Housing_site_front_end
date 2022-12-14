using System.Security.Claims;
using Model.DTOs;

namespace BlazorWASM.Services.ClientInterfaces;

public interface IAuthService
{
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(UserRegistrationDTO user);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    public string GetCurrentEmail();
}
