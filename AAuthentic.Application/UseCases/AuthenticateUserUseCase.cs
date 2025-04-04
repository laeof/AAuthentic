using AAuthentic.Application.Common.Result;
using AAuthentic.Application.DTOs;
using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Service;

namespace AAuthentic.Application.UseCases;

public class AuthenticateUserUseCase
{
    private readonly IAuthService authService;
    private readonly IJwtService jwtService;
    public AuthenticateUserUseCase(IAuthService authService, IJwtService jwtService)
    {
        this.authService = authService;
        this.jwtService = jwtService;
    }

    public async Task<IResult<ITokens>> ExecuteAsync(string email, string password)
    {
        var userResult = await authService.AuthenticateAsync(email, password);

        if (userResult.IsFailure) return Result<ITokens>.Faillure(userResult.Error);

        var roles = userResult.Value.Roles.Select(r => r.RoleName).ToList();

        var accessTokenResult = jwtService.GenerateAccessToken(userResult.Value.Id, userResult.Value.Email, roles);

        if (accessTokenResult.IsFailure) return Result<ITokens>.Faillure(accessTokenResult.Error);

        var refreshTokenResult = jwtService.GenerateRefreshToken();

        if (refreshTokenResult.IsFailure) return Result<ITokens>.Faillure(refreshTokenResult.Error);

        var addRefreshResult = await authService.AddRefreshTokenAsync(userResult.Value.Id, refreshTokenResult.Value);

        if (addRefreshResult.IsFailure) return Result<ITokens>.Faillure(addRefreshResult.Error);

        return Result<ITokens>.Success(new Tokens
        {
            AccessToken = accessTokenResult.Value,
            RefreshToken = refreshTokenResult.Value
        });
    }
}