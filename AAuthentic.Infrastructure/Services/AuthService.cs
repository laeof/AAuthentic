using AAuthentic.Application.Common.Result;
using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Repository;
using AAuthentic.Application.Interfaces.Service;
using AAuthentic.Domain.Entities;

namespace AAuthentic.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly IRefreshTokensRepository refreshTokensRepository;
    private readonly IPasswordHasher passwordHasher;
    public AuthService(IUserRepository userRepository,
    IRefreshTokensRepository refreshTokensRepository, IPasswordHasher passwordHasher)
    {
        this.userRepository = userRepository;
        this.refreshTokensRepository = refreshTokensRepository;
        this.passwordHasher = passwordHasher;
    }
    public async Task<IResult<UserRefreshToken>> AddRefreshTokenAsync(Guid userId, string refreshToken)
    {
        var refreshTokenResult = await refreshTokensRepository.CreateRefreshTokenAsync(userId, refreshToken);

        if (refreshTokenResult.IsFailure) return Result<UserRefreshToken>.Faillure(refreshTokenResult.Error);

        return refreshTokenResult;
    }

    public async Task<IResult<User>> AuthenticateAsync(string email, string password)
    {
        var userResult = await userRepository.GetUserByEmailAsync(email);

        if (userResult.IsFailure) return Result<User>.Faillure(userResult.Error);

        var verificationResult = passwordHasher.Verify(password, userResult.Value.PasswordHash);

        if (verificationResult.IsFailure) return Result<User>.Faillure(verificationResult.Error);

        return userResult;
    }
}