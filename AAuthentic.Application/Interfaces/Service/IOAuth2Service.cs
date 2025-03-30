namespace AAuthentic.Application.Interfaces.Service;

public interface IOAuth2Service {
    IResult<string> GenerateOAuthToken(Guid userId, string email, IList<string> scopes);
}