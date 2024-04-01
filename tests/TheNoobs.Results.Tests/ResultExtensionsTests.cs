using FluentAssertions;
using TheNoobs.Results.Extensions;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTests
{
    [Fact]
    public void GivenResultWhenSuccessThenMapShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.Map<string, int>(x => 1).Value.Should().Be(1);
    }

    [Fact]
    public void GivenResultWhenFailThenMapShouldReturnFail()
    {
        var result = new Result<string>(new TestFail());
        result.Map<string, int>(x => 1).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenResultWhenValueTaskSuccessThenMapAsyncShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MapAsync(x => ValueTask.FromResult(new Result<int>(1)))).Value.Should().Be(1);
    }

    [Fact]
    public async Task GivenResultWhenValueTaskFailThenMapShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MapAsync(x => ValueTask.FromResult(new Result<int>(1)))).Fail.Should().BeOfType<TestFail>();
    }
}
