using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Service;

namespace AAuthentic.Infrastructure.Services;

public class OAuth2Service : IOAuth2Service
{
    private readonly IJwtService jwtService;
    public OAuth2Service(IJwtService jwtService)
    {
        this.jwtService = jwtService;
    }
    public IResult<string> GenerateOAuthToken(Guid userId, string email, IList<string> scopes)
    {
        //fixme
        return jwtService.GenerateAccessToken(userId, email, scopes);
    }
}