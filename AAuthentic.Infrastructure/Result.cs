namespace AAuthentic.Infrastructure
{
    public class Result
    {
        private Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result Faillure(Error error) => new(false, error);

        public Error Error { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
    }

    public sealed record Error(string Code, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}
