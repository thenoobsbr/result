using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsMatchTests
{
    [Fact]
    public void Match_GivenSuccessResult_WhenMatched_ShouldReturnValue()
    {
        var result = new Result<string>("test");
        result.Match(x => 1, fail => 2).Should().Be(1);
    }

    [Fact]
    public void Match_GivenFailResult_WhenMatched_ShouldReturnFailValue()
    {
        var result = new Result<string>(new TestFail());
        result.Match(x => 1, fail => 2).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenValueTaskSuccessResult_WhenMatched_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenValueTaskFailResult_WhenMatched_ShouldReturnFailValue()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenTaskSuccessResult_WhenMatched_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenTaskFailResult_WhenMatched_ShouldReturnFailValue()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenValueTaskSuccessResult_WhenMatchedWithAsyncFunc_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenValueTaskFailResult_WhenMatchedWithAsyncFunc_ShouldReturnFailValue()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenTaskSuccessResult_WhenMatchedWithAsyncFunc_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenTaskFailResult_WhenMatchedWithAsyncFunc_ShouldReturnFailValue()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => Task.FromResult(1), fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenValueTaskSuccessResult_WhenMatchedWithAsyncFailFunc_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => ValueTask.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenValueTaskFailResult_WhenMatchedWithAsyncFailFunc_ShouldReturnFailValue()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => ValueTask.FromResult(2))).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenTaskSuccessResult_WhenMatchedWithAsyncFailFunc_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => Task.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenTaskFailResult_WhenMatchedWithAsyncFailFunc_ShouldReturnFailValue()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => Task.FromResult(2))).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenValueTaskSuccessResult_WhenMatchedWithAsyncFuncAndFailFunc_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => ValueTask.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenValueTaskFailResult_WhenMatchedWithAsyncFuncAndFailFunc_ShouldReturnFailValue()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => ValueTask.FromResult(2))).Should().Be(2);
    }
    
    [Fact]
    public async Task MatchAsync_GivenTaskSuccessResult_WhenMatchedWithAsyncFuncAndFailFunc_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => Task.FromResult(1), fail => Task.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task MatchAsync_GivenTaskFailResult_WhenMatchedWithAsyncFuncAndFailFunc_ShouldReturnFailValue()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => Task.FromResult(1), fail => Task.FromResult(2))).Should().Be(2);
    }
}
