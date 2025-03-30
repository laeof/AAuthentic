using AAuthentic.Application.Common.Result;
using AAuthentic.Application.DTOs;
using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Service;

namespace AAuthentic.Application.UseCases;

public class RefreshTokenUseCase
{
    private readonly IJwtService jwtService;
    private readonly IUserService userService;
    public RefreshTokenUseCase(IJwtService jwtService, IUserService userService)
    {
        this.jwtService = jwtService;
        this.userService = userService;
    }

    public async Task<IResult<ITokens>> ExecuteAsync(string refreshToken)
    {
        var userResult = await userService.GetUserByRefreshTokenAsync(refreshToken);

        if (userResult.IsFailure) return Result<ITokens>.Faillure(userResult.Error);

        var newAccessTokenResult = jwtService.GenerateAccessToken(
            userResult.Value.Id, userResult.Value.Email, userResult.Value.Roles.Select(r => r.RoleName).ToList());

        if (newAccessTokenResult.IsFailure) return Result<ITokens>.Faillure(newAccessTokenResult.Error);

        var newRefreshTokenResult = jwtService.GenerateRefreshToken();

        if (newRefreshTokenResult.IsFailure) return Result<ITokens>.Faillure(newRefreshTokenResult.Error);

        await userService.RevokeRefreshTokenAsync(refreshToken);
        var newRefreshTokenSaved = await userService.AddRefreshTokenAsync(userResult.Value.Id, newRefreshTokenResult.Value);

        if (newRefreshTokenResult.IsFailure) return Result<ITokens>.Faillure(newRefreshTokenResult.Error);

        return Result<ITokens>.Success(
            new Tokens { AccessToken = newAccessTokenResult.Value, RefreshToken = newRefreshTokenResult.Value });
    }
}