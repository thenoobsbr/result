using FluentAssertions;
using TheNoobs.Results.Extensions;
using static TheNoobs.Results.Tests.Stubs.FunctionsStubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsMatchTests
{
    [Fact]
    public void GivenFailResult_WhenMatched_ThenShouldReturnAlternativeValue()
    {
        GetFail()
            .Match(x => 1, fail => 2)
            .Should().Be(2);
    }
    
    [Fact]
    public void GivenSuccessResult_WhenMatched_ThenShouldReturnPrimaryValue()
    {
        GetSuccess()
            .Match(x => 1, fail => 2)
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenFailResult_WhenMatchedAsync_ThenShouldReturnAlternativeValue()
    {
        var result = await GetFail()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, fail => 2);
        result.Should().Be(2);
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenMatchedAsync_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccess()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, x => 2);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenFailResult_WhenMatchedAsyncWithSyncAlternative_ThenShouldReturnAlternativeValue()
    {
        var result = await GetFail()
            .MatchAsync(x => 1, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(2);
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenMatchedAsyncWithSyncAlternative_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccess()
            .MatchAsync(x => 1, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenFailResult_WhenMatchedAsyncWithBothAsync_ThenShouldReturnAlternativeValue()
    {
        var result = await GetFail()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(2);
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenMatchedAsyncWithBothAsync_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccess()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenMatchedAsync_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessAsync()
            .MatchAsync(x => 1, x => 2);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenMatchedAsyncWithAsyncPrimary_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessAsync()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, x => 2);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenMatchedAsyncWithSyncPrimary_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessAsync()
            .MatchAsync(x => 1, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenMatchedAsyncWithBothAsync_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessAsync()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenMatchedAsync_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessTaskAsync()
            .MatchAsync(x => 1, x => 2);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenMatchedAsyncWithAsyncPrimary_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessTaskAsync()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, x => 2);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenMatchedAsyncWithSyncPrimary_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessTaskAsync()
            .MatchAsync(x => 1, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenMatchedAsyncWithBothAsync_ThenShouldReturnPrimaryValue()
    {
        var result = await GetSuccessTaskAsync()
            .MatchAsync(async x => (await GetSuccessAsync()).Value, async x => (await GetSuccessAsync(2)).Value);
        result.Should().Be(1);
    }
}
