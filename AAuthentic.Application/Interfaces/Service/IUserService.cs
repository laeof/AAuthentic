using AAuthentic.Application.DTOs;
using AAuthentic.Domain.Entities;

namespace AAuthentic.Application.Interfaces.Service;

public interface IUserService {
    Task<IResult<User>> GetUserByIdAsync(Guid id);
    Task<IResult<User>> GetUserByRefreshTokenAsync(string refreshToken);
    Task<IResult<bool>> RevokeRefreshTokenAsync(string oldRefreshToken);
    Task<IResult<bool>> AddRefreshTokenAsync(Guid userId, string newRefreshToken);
    Task<IResult<bool>> ExistsByEmailAsync(string email); 
    Task<IResult<User>> RegisterUserAsync(Register dto, string passwordHash);
}