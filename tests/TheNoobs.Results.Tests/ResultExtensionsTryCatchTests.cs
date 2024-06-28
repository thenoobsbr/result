using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;

using static TheNoobs.Results.Tests.Stubs.FunctionsStubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTryCatchTests
{
    [Fact]
    public void GivenFail_WhenTryCatchWithSuccessAndFail_ThenShouldReturnTestFail()
    {
        GetFail()
            .TryCatch(
            _ => GetSuccess(),
            _ => GetFail())
            .Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenSuccess_WhenTryCatchWithFailAndServerErrorFail_ThenShouldReturnTestFail()
    {
        GetSuccess()
                .TryCatch(
                    _ => GetFail(),
                    _ => GetFail(new ServerErrorFail()))
                .Fail
                .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenSuccess_WhenTryCatchWithSuccessAndServerErrorFail_ThenShouldReturnValue1()
    {
        GetSuccess()
                .TryCatch(
                    _ => GetSuccess(),
                    _ => GetFail(new ServerErrorFail()))
                .Value
                .Should().Be(1);
    }
    
    [Fact]
    public void GivenSuccess_WhenTryCatchWithExceptionAndServerErrorFail_ThenShouldReturnServerErrorFail()
    {
        GetSuccess()
                .TryCatch(
                    _ => Throw(),
                    _ => GetFail(new ServerErrorFail()))
                .Fail
                .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenFail_WhenTryCatchAsyncWithSuccessAndServerErrorFail_ThenShouldReturnTestFail()
    {
        var result = await GetFail()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithFailAndServerErrorFail_ThenShouldReturnTestFail()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => GetFailAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithSuccessAndServerErrorFail_ThenShouldReturnValue1()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithExceptionAndServerErrorFail_ThenShouldReturnServerErrorFail()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => ThrowAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenFail_WhenTryCatchAsyncWithExceptionAndFailAsync_ThenShouldReturnTestFail()
    {
        var result = await GetFail()
            .TryCatchAsync(
                _ => Throw(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithFailAndFailAsync_ThenShouldReturnTestFail()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => GetFail(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithSuccessAndFailAsync_ThenShouldReturnValue1()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithExceptionAndFailAsync_ThenShouldReturnServerErrorFail()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => Throw(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenFail_WhenTryCatchAsyncWithExceptionAsyncAndFailAsync_ThenShouldReturnTestFail()
    {
        var result = await GetFail()
            .TryCatchAsync(
                _ => ThrowAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithFailAsyncAndFailAsync_ThenShouldReturnTestFail()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => GetFailAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithSuccessAsyncAndFailAsync_ThenShouldReturnValue1()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccess_WhenTryCatchAsyncWithExceptionAsyncAndFailAsync_ThenShouldReturnServerErrorFail()
    {
        var result = await GetSuccess()
            .TryCatchAsync(
                _ => ThrowAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessAsync_WhenTryCatchAsyncWithSuccessAndFail_ThenShouldReturnValue1()
    {
        var result = await GetSuccessAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFail());
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionAsync_WhenTryCatchAsyncWithSuccessAndServerErrorFail_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessAsync_WhenTryCatchAsyncWithSuccessAsyncAndServerErrorFail_ThenShouldReturnValue1()
    {
        var result = await GetSuccessAsync()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionAsync_WhenTryCatchAsyncWithSuccessAsyncAndServerErrorFail_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowAsync()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessAsync_WhenTryCatchAsyncWithSuccessAndFailAsync_ThenShouldReturnValue1()
    {
        var result = await GetSuccessAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionAsync_WhenTryCatchAsyncWithSuccessAndFailAsync_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessAsync_WhenTryCatchAsyncWithSuccessAsyncAndFailAsync_ThenShouldReturnValue1()
    {
        var result = await GetSuccessAsync()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionAsync_WhenTryCatchAsyncWithSuccessAsyncAndFailAsync_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowAsync()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsync_WhenTryCatchAsyncWithSuccessAndServerErrorFail_ThenShouldReturnValue1()
    {
        var result = await GetSuccessTaskAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFail(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionTaskAsync_WhenTryCatchAsyncWithSuccessAndServerErrorFail_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowTaskAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsync_WhenTryCatchAsyncWithSuccessAsyncAndServerErrorFail_ThenShouldReturnValue1()
    {
        var result = await GetSuccessTaskAsync()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionTaskAsync_WhenTryCatchAsyncWithExceptionAsyncAndServerErrorFail_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowTaskAsync()
            .TryCatchAsync(
                _ => ThrowAsync(),
                _ => GetFail(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsync_WhenTryCatchAsyncWithSuccessAndFailAsync_ThenShouldReturnValue1()
    {
        var result = await GetSuccessTaskAsync()
            .TryCatchAsync(
                _ => GetSuccess(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionTaskAsync_WhenTryCatchAsyncWithExceptionAndFailAsync_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowTaskAsync()
            .TryCatchAsync(
                _ => Throw(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsync_WhenTryCatchAsyncWithSuccessAsyncAndFailAsync_ThenShouldReturnValue1()
    {
        var result = await GetSuccessTaskAsync()
            .TryCatchAsync(
                _ => GetSuccessAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Value
            .Should().Be(1);
    }
    
    [Fact]
    public async Task GivenExceptionTaskAsync_WhenTryCatchAsyncWithExceptionAsyncAndFailAsync_ThenShouldReturnServerErrorFail()
    {
        var result = await ThrowTaskAsync()
            .TryCatchAsync(
                _ => ThrowAsync(),
                _ => GetFailAsync(new ServerErrorFail()));
        result.Fail
            .Should().BeOfType<ServerErrorFail>();
    }
}

