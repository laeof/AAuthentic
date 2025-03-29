using AAuthentic.Application.Interfaces;
using AAuthentic.Domain.Entities;

namespace AAuthentic.Infrastructure.Services;

public class AuthService : IAuthService
{
    public Task<IResult<string>> AddRefreshTokenAsync(Guid userId, string refreshToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult<User>> AuthenticateAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}