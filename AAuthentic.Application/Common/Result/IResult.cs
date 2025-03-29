namespace AAuthentic.Application;

public interface IResult<T>
{
    public T Value { get; }
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
}