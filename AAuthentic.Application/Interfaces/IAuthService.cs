using AAuthentic.Domain.Entities;

namespace AAuthentic.Application.Interfaces;

public interface IAuthService {
    Task<IResult<User>> AuthenticateAsync(string email, string password);
    Task<IResult<string>> AddRefreshTokenAsync(Guid userId, string refreshToken);
}