using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsMergeTests
{
    [Fact]
    public void Merge_GivenTwoSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(new TestFail());
        var mergeResult = result
            .Merge(result2)
            .Merge(result3);
        mergeResult
            .Fail.Should().BeOfType<AggregateFail>();
        mergeResult.Fail
            .As<AggregateFail>().Failures.First()
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenManySuccessResult_WhenMerged_ShouldReturnValues()
    {
        var result = new Result<int>(1)
            .Merge(new Result<int>(2), new Result<int>(3), new Result<int>(4));
        result
            .GetValueByIndex<int>(0)
            .Value
            .Should().Be(1);
        result
            .GetValueByIndex<int>(1)
            .Value
            .Should().Be(2);
        result
            .GetValueByIndex<int>(2)
            .Value
            .Should().Be(3);
        result
            .GetValueByIndex<int>(3)
            .Value
            .Should().Be(4);
    }
    
    [Fact]
    public void Merge_GivenManySuccessResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<string>("test1")
            .Merge(
                new Result<int>(2),
                new Result<DateTime>(DateTime.UtcNow))
            .Bind(x => x.GetValue<string>());
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test1");
    }
}
