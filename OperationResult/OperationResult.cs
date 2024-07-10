namespace OperationResult;

public class ResultObject
{
    private static SuccessTag SuccessTag { get; }

    private static ErrorTag ErrorTag { get; }

    public static SuccessTag Ok()
    {
        return SuccessTag;
    }

    public static SuccessTag<TResult> Ok<TResult>(TResult result)
    {
        return new SuccessTag<TResult>(result);
    }

    public static ErrorTag Error()
    {
        return ErrorTag;
    }

    public static ErrorTag<TError> Error<TError>(TError error)
    {
        return new ErrorTag<TError>(error);
    }
}
