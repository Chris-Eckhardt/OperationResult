namespace OperationResult;

[GenerateSerializer]
[Alias("OperationResult.Result`2")]
public readonly struct Result<TResult, TError>
{
    [Id(0)]
    public readonly bool IsSuccess;

    [Id(1)]
    public readonly bool IsError;

    [Id(2)]
    public readonly TResult Value;

    [Id(3)]
    public readonly TError Error;

    private Result(TResult result)
    {
        IsSuccess = true;
        IsError = false;
        Value = result;
        Error = default!;
    }

    private Result(TError error)
    {
        IsSuccess = false;
        IsError = true;
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