using AAuthentic.Application.Common.Result;
using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Repository;
using AAuthentic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AAuthentic.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly ITransformToUnixDate transformToUnixDate;
    private readonly AAuthenticDbContext context;
    public UserRepository(ITransformToUnixDate transformToUnixDate, AAuthenticDbContext context)
    {
        this.transformToUnixDate = transformToUnixDate;
        this.context = context;
    }

    public async Task<IResult<User>> CreateUserAsync(User user)
    {
        user.CreatedDateUnix = transformToUnixDate.TransformFromNormalToUnixTime(DateTime.Now).Value;
        user.UpdatedDateUnix = user.CreatedDateUnix;

        try
        {
            context.Entry(user).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result<User>.Faillure(new("500", ex.Message));
        }

        return Result<User>.Success(user);
    }

    public Task<IResult<bool>> DisableUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult<User>> GetUserByEmailAsync(string email)
    {
        var userResult = await context.Users.FirstOrDefaultAsync(e => e.Email == email);

        if (userResult == null) return Result<User>.Faillure(new("404", "User not found"));

        return Result<User>.Success(userResult);
    }

    public async Task<IResult<User>> GetUserByIdAsync(Guid id)
    {
        var userResult = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (userResult == null) return Result<User>.Faillure(new("404", "User not found"));

        return Result<User>.Success(userResult);
    }

    public Task<IResult<User>> ModifyUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}