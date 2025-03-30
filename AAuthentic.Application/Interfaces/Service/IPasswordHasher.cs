namespace AAuthentic.Application.Interfaces.Service;

public interface IPasswordHasher
{
    IResult<string> Hash(string password);
    IResult<bool> Verify(string password, string hashedPassword);
}