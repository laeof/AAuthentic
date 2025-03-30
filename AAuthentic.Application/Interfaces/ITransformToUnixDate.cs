namespace AAuthentic.Application.Interfaces;

public interface ITransformToUnixDate
{
    IResult<string> TransformFromNormalToUnixTime(DateTime dateTime);
}
