using AAuthentic.Application.Interfaces;

namespace AAuthentic.Infrastructure.Services;

public class JwtService : IJwtService
{
    public IResult<string> GenerateAccessToken(Guid userId, string email, IList<string> roles)
    {
        throw new NotImplementedException();
    }

    public IResult<string> GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }
}