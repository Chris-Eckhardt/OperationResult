namespace OperationResult;

public readonly struct Result<TResult, TError>
{
    public readonly TResult Value;

    public readonly TError Error;

    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    private Result(TResult result)
    {
        IsSuccess = true;
        Value = result;
        Error = default!;
    }

    private Result(TError error)
    {
        IsSuccess = false;
        Value = default!;
        Error = error;
    }

    public void Deconstruct(out TResult result, out TError error)
    {
        result = Value;
        error = Error;
    }

    public static implicit operator bool(Result<TResult, TError> result)
    {
        return result.IsSuccess;
    }

    public static implicit operator Result<TResult, TError>(TResult result)
    {
        return new Result<TResult, TError>(result);
    }

    public static implicit operator Result<TResult, TError>(SuccessTag<TResult> tag)
    {
        return new Result<TResult, TError>(tag.Value);
    }

    public static implicit operator Result<TResult, TError>(ErrorTag<TError> tag)
    {
        return new Result<TResult, TError>(tag.Error);
    }
}