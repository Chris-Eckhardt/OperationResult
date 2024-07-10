namespace OperationResult;

public struct ErrorTag<TError>
{
    public TError Error { get; internal set; }

    internal ErrorTag(TError error)
    {
        Error = error;
    }
}

public struct ErrorTag { }
