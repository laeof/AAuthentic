using AAuthentic.Application.Common.Result;
using AAuthentic.Application.Interfaces;

namespace AAuthentic.Application.Common.TransformToUnixDate;

public class TransformToUnixDate : ITransformToUnixDate
{
    public IResult<string> TransformFromNormalToUnixTime(DateTime dateTime)
    {
        return Result<string>.Success(((DateTimeOffset)dateTime).ToUnixTimeSeconds().ToString());
    }
}