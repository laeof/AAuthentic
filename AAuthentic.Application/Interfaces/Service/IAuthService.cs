using AAuthentic.Domain.Entities;

namespace AAuthentic.Application.Interfaces.Service;

public interface IAuthService {
    Task<IResult<User>> AuthenticateAsync(string email, string password);
    Task<IResult<UserRefreshToken>> AddRefreshTokenAsync(Guid userId, string refreshToken);
}