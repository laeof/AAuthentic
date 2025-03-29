using AAuthentic.Domain.Entities;

namespace AAuthentic.Application.Interfaces;

public interface IUserService {
    Task<IResult<User>> GetUserByIdAsync(Guid id);
    Task<IResult<User>> GetUserByRefreshTokenAsync()
}