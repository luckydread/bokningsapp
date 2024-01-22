using System.IdentityModel.Tokens.Jwt;
using bokningsapp.Dtos;
using FluentResults;
namespace bokningsapp.Services
{
    public interface IAuthenticationService
    {
        Task<Result<string>> Register(RegisterRequest request);
        Task<Result<string>> Login(LoginRequest request);
    }
}
