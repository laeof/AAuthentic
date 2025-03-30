namespace AAuthentic.Application.Interfaces.Repository;

public interface IUserRoleRepository {
    Task<IResult<bool>> AddRoleToUser(Guid userId, Guid roleId);
}