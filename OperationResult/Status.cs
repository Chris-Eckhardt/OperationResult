namespace OperationResult;

public readonly struct Status<TError>
{
    public readonly TError Error;

    private static readonly Status<TError> SuccessStatus = new(isSuccess: true);

    public readonly bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    private Status(bool isSuccess)
    {
        IsSuccess = isSuccess;
        Error = default!;
    }

    private Status(TError error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static implicit operator bool(Status<TError> status)
    {
        return status.IsSuccess;
    }

    public static implicit operator Status<TError>(SuccessTag tag)
    {
        return SuccessStatus;
    }

    public static implicit operator Status<TError>(ErrorTag<TError> tag)
    {
        return new Status<TError>(tag.Error);
    }
}