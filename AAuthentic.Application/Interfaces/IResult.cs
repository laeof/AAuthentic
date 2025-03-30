using System.Dynamic;
using AAuthentic.Application.Common.Result;

namespace AAuthentic.Application.Interfaces;

public interface IResult<T>
{
    T Value { get; }
    Error Error { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}