using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;
using static TheNoobs.Results.Tests.Stubs.FunctionsStubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsCatchTests
{
    [Fact]
    public void GivenSuccessResult_WhenCatch_ThenShouldReturnOriginalValue()
    {
        GetSuccess()
            .Catch<int, NotFoundFail>(x => GetSuccess(2))
            .Value.Should().Be(1);
    }
    
    [Fact]
    public void GivenSuccessResult_WhenCatchWithBindResult_ThenShouldReturnOriginalValue()
    {
        GetSuccess()
            .Catch<int, NotFoundFail>((_, _) => GetSuccess(2))
            .Value.Should().Be(1);
    }
    
    [Fact]
    public void GivenNotFoundFailResult_WhenCatch_ThenShouldReturnAlternativeValue()
    {
        GetFail(new NotFoundFail())
            .Catch<int, NotFoundFail>(x => GetSuccess(2))
            .Value.Should().Be(2);
    }
    
    [Fact]
    public void GivenNotFoundFailResult_WhenCatchWithBindResultFromFail_ThenShouldReturnAlternativeValue()
    {
        GetFail(new NotFoundFail())
            .Catch<int, NotFoundFail>((_, _) => GetSuccess(2))
            .Value.Should().Be(2);
    }
    
    [Fact]
    public void GivenNotFoundFailResult_WhenCatchWithBindResult_ThenShouldReturnAlternativeValue()
    {
        GetSuccess().Bind(_ => GetFail(new NotFoundFail()))
            .Catch<int, NotFoundFail>((_, _) => GetSuccess(2))
            .Value.Should().Be(2);
    }
    
    [Fact]
    public void GivenNotFoundFailResult_WhenCatchWithBindResult_ThenShouldBeAbleToAccessPreviousSuccess()
    {
        GetSuccess()
            .Bind(x => GetFail(new NotFoundFail()))
            .Catch<int, NotFoundFail>((x, xy) => xy.GetValue<int>())
            .Value.Should().Be(1);
    }
    
    [Fact]
    public void GivenOtherFailResult_WhenCatch_ThenShouldReturnOriginalFail()
    {
        GetFail()
            .Catch<int, NotFoundFail>(x => GetSuccess(2))
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenOtherFailResult_WhenCatchWithBindResult_ThenShouldReturnOriginalFail()
    {
        GetSuccess().Bind(_ => GetFail())
            .Catch<int, NotFoundFail>((_, _) => GetSuccess(2))
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenCatchAsync_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccess()
            .CatchAsync<int, NotFoundFail>(x => GetSuccessAsync(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenCatchAsyncWithBindResult_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccess()
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccessAsync(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenNotFoundFailResult_WhenCatchAsync_ThenShouldReturnAlternativeValue()
    {
        var result = await GetFail(new NotFoundFail())
            .CatchAsync<int, NotFoundFail>(x => GetSuccessAsync(2));
        result.Value.Should().Be(2);
    }
    
    [Fact]
    public async Task GivenNotFoundFailResult_WhenCatchAsyncWithBindResult_ThenShouldReturnAlternativeValue()
    {
        var result = await GetSuccess().Bind(_ => GetFail(new NotFoundFail()))
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccessAsync(2));
        result.Value.Should().Be(2);
    }
    
    [Fact]
    public async Task GivenNotFoundFailResult_WhenCatchAsyncWithBindResultFromFail_ThenShouldReturnAlternativeValue()
    {
        var result = await GetFail(new NotFoundFail())
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccessAsync(2));
        result.Value.Should().Be(2);
    }
    
    [Fact]
    public async Task GivenNotFoundFailResult_WhenCatchAsyncWithBindResult_ThenShouldBeAbleToAccessPreviousSuccess()
    {
        var result = await GetSuccess()
            .Bind(x => GetFail(new NotFoundFail()))
            .CatchAsync<int, NotFoundFail>((x, xy) => ValueTask.FromResult(xy.GetValue<int>()));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenOtherFailResult_WhenCatchAsync_ThenShouldReturnOriginalFail()
    {
        var result = await GetFail()
            .CatchAsync<int, NotFoundFail>(x => GetSuccessAsync(2));
        result.Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenOtherFailResult_WhenCatchAsyncWithBindResult_ThenShouldReturnOriginalFail()
    {
        var result = await GetSuccess().Bind(_ => GetFail())
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccessAsync(2));
        result.Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenCatchAsyncWithSyncAlternative_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessAsync()
            .CatchAsync<int, NotFoundFail>(x => GetSuccess(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenCatchAsyncWithSyncAlternativeAndBindResult_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessAsync()
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccess(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenCatchAsyncWithAsyncAlternative_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessAsync()
            .CatchAsync<int, NotFoundFail>(x => GetSuccessAsync(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenCatchAsyncWithAsyncAlternativeAndBindResult_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessAsync()
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccessAsync(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenCatchAsyncWithSyncAlternative_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessTaskAsync()
            .CatchAsync<int, NotFoundFail>(x => GetSuccess(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenCatchAsyncWithSyncAlternativeWithBindResult_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessTaskAsync()
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccess(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenCatchAsyncWithAsyncAlternative_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessTaskAsync()
            .CatchAsync<int, NotFoundFail>(x => GetSuccessAsync(2));
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenCatchAsyncWithAsyncAlternativeWithBindResult_ThenShouldReturnOriginalValue()
    {
        var result = await GetSuccessTaskAsync()
            .CatchAsync<int, NotFoundFail>((_, _) => GetSuccessAsync(2));
        result.Value.Should().Be(1);
    }
}
