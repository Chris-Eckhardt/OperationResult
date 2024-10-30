using Orleans.TestingHost;
using static OperationResult.ResultObject;

namespace OperationResult.Tests;

[Collection(ClusterCollection.Name)]
public class OrleansSerializationTests(ClusterFixture fixture)
{
    private readonly TestCluster _cluster = fixture.Cluster;

    [Fact]
    public async Task Result_Value()
    {
        var grain = _cluster.GrainFactory.GetGrain<ITestGrain>(primaryKey: 42);
        var result = await grain.DoSomething(fail: false);
        Assert.True(result.IsSuccess);
        Assert.False(result.IsError);
        Assert.Equal(expected: typeof(SuccessObject), actual: result.Value.GetType());
    }

    [Fact]
    public async Task Result_Error()
    {
        var grain = _cluster.GrainFactory.GetGrain<ITestGrain>(primaryKey: 42);
        var result = await grain.DoSomething(fail: true);
        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.Equal(expected: typeof(FailureObject), actual: result.Error.GetType());
    }

    [Fact]
    public async Task Status_Value()
    {
        var grain = _cluster.GrainFactory.GetGrain<ITestGrain>(primaryKey: 42);
        var result = await grain.DoSomething(fail: false);
        Assert.True(result.IsSuccess);
        Assert.False(result.IsError);
    }

    [Fact]
    public async Task Status_Error()
    {
        var grain = _cluster.GrainFactory.GetGrain<ITestGrain>(primaryKey: 42);
        var result = await grain.DoSomething(fail: true);
        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.Equal(expected: typeof(FailureObject), actual: result.Error.GetType());
    }
}

[GenerateSerializer, Immutable]
[Alias("OperationResult.Tests.SuccessObject")]
public class SuccessObject(string message = "Yay!")
{
    public readonly string Message = message;
}

[GenerateSerializer, Immutable]
[Alias("OperationResult.Tests.FailureObject")]
public readonly struct FailureObject(string message = "Oops!")
{
    public readonly string Message = message;
}

[Alias("OperationResult.Tests.ITestGrain")]
public interface ITestGrain : IGrainWithIntegerKey
{
    [Alias("DoSomething")]
    Task<Result<SuccessObject, FailureObject>>  DoSomething(bool fail = false);

    [Alias("DoSomethingElse")]
    Task<Status<FailureObject>> DoSomethingElse(bool fail = false);
}

internal class TestGrain : Grain, ITestGrain
{
    public async Task<Result<SuccessObject, FailureObject>> DoSomething(bool fail = false)
    {
        await Task.CompletedTask;

        if (fail)
        {
            return Error(new FailureObject());
        }

        return Ok(new SuccessObject());
    }

    public async Task<Status<FailureObject>> DoSomethingElse(bool fail = false)
    {
        await Task.CompletedTask;

        if (fail)
        {
            return Error(new FailureObject());
        }

        return Ok();
    }
}
