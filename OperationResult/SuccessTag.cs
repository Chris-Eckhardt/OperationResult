namespace OperationResult;

public struct SuccessTag<TResult>
{
    public TResult Value { get; internal set; }

    internal SuccessTag(TResult result)
    {
        Value = result;
    }
}

public struct SuccessTag { }
