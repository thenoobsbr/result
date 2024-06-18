using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsMatchTests
{
    [Fact]
    public void GivenResultWhenSuccessThenMatchShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.Match(x => 1, fail => 2).Should().Be(1);
    }

    [Fact]
    public void GivenResultWhenFailThenMatchShouldReturnFail()
    {
        var result = new Result<string>(new TestFail());
        result.Match(x => 1, fail => 2).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenSuccessThenMatchShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task GivenValueTaskResultWhenFailThenMatchShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenTaskResultWhenSuccessThenMatchShouldReturnTheValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task GivenValueResultWhenFailThenMatchShouldReturnFail()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenSuccessThenMatchAsyncShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task GivenValueTaskResultWhenFailThenMatchAsyncShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenTaskResultWhenSuccessThenMatchAsyncShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => 2)).Should().Be(1);
    }

    [Fact]
    public async Task GivenTaskResultWhenFailThenMatchAsyncShouldReturnFail()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => Task.FromResult(1), fail => 2)).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenSuccessThenMatchAsyncShouldReturnTheValueAsync()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => ValueTask.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task GivenValueTaskResultWhenFailThenMatchAsyncShouldReturnFailAsync()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => ValueTask.FromResult(2))).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenTaskResultWhenSuccessThenMatchAsyncShouldReturnTheValueAsync()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => 1, fail => Task.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task GivenTaskResultWhenFailThenMatchAsyncShouldReturnFailAsync()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => 1, fail => Task.FromResult(2))).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenSuccessAsyncThenMatchAsyncShouldReturnTheValueAsync()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => ValueTask.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task GivenValueTaskResultWhenFailAsyncThenMatchAsyncShouldReturnFailAsync()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => ValueTask.FromResult(1), fail => ValueTask.FromResult(2))).Should().Be(2);
    }
    
    [Fact]
    public async Task GivenTaskResultWhenSuccessAsyncThenMatchAsyncShouldReturnTheValueAsync()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.MatchAsync(x => Task.FromResult(1), fail => Task.FromResult(2))).Should().Be(1);
    }

    [Fact]
    public async Task GivenTaskResultWhenFailAsyncThenMatchAsyncShouldReturnFailAsync()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.MatchAsync(x => Task.FromResult(1), fail => Task.FromResult(2))).Should().Be(2);
    }
}
