namespace OperationResult.Tests;

public class OperationResultTests
{
    [Fact]
    public void Result()
    {
        {
            var result = TestMethods.ResultSimpleValueType(failure: true);
            Assert.True(result.IsError);
        }

        {
            var result = TestMethods.ResultSimpleValueType(failure: false);
            Assert.True(result.IsSuccess);
        }

        {
            var result = TestMethods.ResultComplexValueType(failure: true);
            Assert.True(result.IsError);
        }

        {
            var result = TestMethods.ResultComplexValueType(failure: false);
            Assert.True(result.IsSuccess);
        }

        {
            var result = TestMethods.ResultReferenceType(failure: true);
            Assert.True(result.IsError);
            Assert.NotNull(result.Error);
        }

        {
            var result = TestMethods.ResultReferenceType(failure: false);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
        }
    }

    [Fact]
    public void Status()
    {
        {
            var status = TestMethods.StatusSimpleValueType(failure: true);
            Assert.True(status.IsError);
        }

        {
            var status = TestMethods.StatusSimpleValueType(failure: false);
            Assert.True(status.IsSuccess);
        }

        {
            var status = TestMethods.StatusComplexValueType(failure: true);
            Assert.True(status.IsError);
        }

        {
            var status = TestMethods.StatusComplexValueType(failure: false);
            Assert.True(status.IsSuccess);
        }

        {
            var status = TestMethods.StatusReferenceType(failure: true);
            Assert.True(status.IsError);
            Assert.NotNull(status.Error);
        }

        {
            var status = TestMethods.StatusReferenceType(failure: false);
            Assert.True(status.IsSuccess);
            Assert.Null(status.Error);
        }
    }    
}