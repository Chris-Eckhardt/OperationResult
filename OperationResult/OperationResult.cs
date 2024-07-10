namespace OperationResult;

public class ResultObject
{
    private static SuccessTag SuccessTag { get; }

    private static ErrorTag ErrorTag { get; }

    /// <summary>
    /// An object representing an operation that completed successfully.
    /// </summary>
    /// <returns></returns>
    public static SuccessTag Ok()
    {
        return SuccessTag;
    }

    /// <summary>
    /// An object representing an operation that completed successfully with a return value.
    /// </summary>
    public static SuccessTag<TResult> Ok<TResult>(TResult result)
    {
        return new SuccessTag<TResult>(result);
    }

    /// <summary>
    /// An object representing an operation that completed unsuccessfully.
    /// </summary>
    /// <returns></returns>
    public static ErrorTag Error()
    {
        return ErrorTag;
    }

    /// <summary>
    /// An object representing an operation that completed unuccessfully with an error.
    /// </summary>
    /// <typeparam name="TError"></typeparam>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ErrorTag<TError> Error<TError>(TError error)
    {
        return new ErrorTag<TError>(error);
    }
}
