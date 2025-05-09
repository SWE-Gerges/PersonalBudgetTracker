namespace BudgetTracker.Domain.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public Error? Error { get; }
    public T? Value { get; }

    private Result(bool isSuccess, T? value, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public static Result<T> Success(T value) =>
     new(true, value, null);

    public static Result<T> Failure(Error error) =>
    new(false, default, error);
}
