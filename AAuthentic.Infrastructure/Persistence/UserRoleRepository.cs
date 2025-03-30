using AAuthentic.Application.Common.Result;
using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Repository;
using AAuthentic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AAuthentic.Infrastructure.Persistence;

public class UserRoleRepository : IUserRoleRepository
{
    private AAuthenticDbContext context;
    private ITransformToUnixDate transformToUnixDate;
    public UserRoleRepository(AAuthenticDbContext context, ITransformToUnixDate transformToUnixDate)
    {
        this.context = context;
        this.transformToUnixDate = transformToUnixDate;
    }

    public async Task<IResult<bool>> AddRoleToUser(Guid userId, Guid roleId)
    {
        var userRole = new UserRole
        {
            UserId = userId,
            RoleId = roleId,
            CreatedDateUnix = transformToUnixDate.TransformFromNormalToUnixTime(DateTime.UtcNow).Value,
            UpdatedDateUnix = transformToUnixDate.TransformFromNormalToUnixTime(DateTime.UtcNow).Value,
        };
        try
        {
            context.Entry(userRole).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result<bool>.Faillure(new("500", ex.Message));
        }

        return Result<bool>.Success(true);
    }
}