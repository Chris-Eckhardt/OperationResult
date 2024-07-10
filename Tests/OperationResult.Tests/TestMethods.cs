using static OperationResult.ResultObject;

namespace OperationResult.Tests;

internal class TestMethods
{
    public static Result<int, bool> ResultSimpleValueType(bool failure)
        => failure ? Error(false) : Ok(42);

    public static Result<ValueType, ValueType> ResultComplexValueType(bool failure) 
        => failure ? Error(new ValueType()) : Ok(new ValueType());

    public static Result<RefereceType, RefereceType> ResultReferenceType(bool failure)
        => failure ? Error(new RefereceType()) : Ok(new RefereceType());

    public static Status<ValueType> StatusComplexValueType(bool failure)
        => failure ? Error(new ValueType()) : Ok();

    public static Status<int> StatusSimpleValueType(bool failure)
        => failure ? Error(-1) : Ok();

    public static Status<RefereceType> StatusReferenceType(bool failure)
        => failure ? Error(new RefereceType()) : Ok();
}

internal class RefereceType
{
    public int Value;
    public string Str;

    public RefereceType()
    {
        Value = 42;
        Str = "Fourty Two";
    }
}

internal struct ValueType
{
    public int Value;
    public string Str;

    public ValueType()
    {
        Value = 42;
        Str = "Fourty Two";
    }
}
