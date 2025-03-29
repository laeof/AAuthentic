using AAuthentic.Application.Common.Result;
using AAuthentic.Application.Interfaces;

namespace AAuthentic.Application.UseCases;

public class RefreshTokenUseCase {
    private readonly IAuthService authService;
    private readonly IJwtService jwtService;
    private readonly IUserService userService;
    public RefreshTokenUseCase(IAuthService authService, IJwtService jwtService, IUserService userService)
    {
        this.authService = authService;
        this.jwtService = jwtService;
        this.userService = userService;
    }

    public async Task<Result<ITokens>> ExecuteAsync(string refreshToken) {
        var user = userService.
    }
}