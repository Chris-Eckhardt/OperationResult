namespace OperationResult;

[GenerateSerializer]
[Alias("OperationResult.Status`1")]
public readonly struct Status<TError>
{
    private static readonly Status<TError> SuccessStatus = new(isSuccess: true);

    [Id(0)]
    public readonly bool IsSuccess;
    [Id(1)]
    public readonly bool IsError;

    [Id(2)]
    public readonly TError Error;

    private Status(bool isSuccess)
    {
        IsSuccess = isSuccess;
        IsError = !isSuccess;
        Error = default!;
    }

    private Status(TError error)
    {
        IsSuccess = false;
        IsError = true;
        Error = error;
    }

    public static implicit operator bool(Status<TError> status)
    {
        return status.IsSuccess;
    }

    public static implicit operator Status<TError>(SuccessTag _)
    {
        return SuccessStatus;
    }

    public static implicit operator Status<TError>(ErrorTag<TError> tag)
    {
        return new Status<TError>(tag.Error);
    }
}