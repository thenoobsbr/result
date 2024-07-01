using FluentAssertions;
using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;
using static TheNoobs.Results.Tests.Stubs.FunctionsStubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsBindTests
{
    [Fact]
    public void GivenFailResult_WhenBindToFail_ThenShouldReturnOriginalFail()
    {
        var result = GetFail()
            .Bind(_ => GetFail(new ServerErrorFail()));

        result
            .Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenSuccessResult_WhenBindToFail_ThenShouldReturnFail()
    {
        var result = GetSuccess()
            .Bind(_ => GetFail());

        result
            .Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenSuccessResult_WhenBindToSuccess_ThenShouldReturnSuccess()
    {
        var result = GetSuccess()
            .Bind(_ => GetSuccess());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenFailResult_WhenBindAsyncToFail_ThenShouldReturnOriginalFail()
    {
        var result = await GetFail()
            .BindAsync(_ => GetFailAsync(new ServerErrorFail()));

        result
            .Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenBindAsyncToFail_ThenShouldReturnFail()
    {
        var result = await GetSuccess()
            .BindAsync(_ => GetFailAsync());

        result
            .Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenBindAsyncToSuccess_ThenShouldReturnSuccess()
    {
        var result = await GetSuccess()
            .BindAsync(_ => GetSuccessAsync());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenBindAsyncToSuccess_ThenShouldReturnSuccess()
    {
        var result = await GetSuccessAsync()
            .BindAsync(_ => GetSuccess());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenBindAsyncToSuccessAsync_ThenShouldReturnSuccess()
    {
        var result = await GetSuccessAsync()
            .BindAsync(_ => GetSuccessAsync());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenBindAsyncToSuccess_ThenShouldReturnSuccess()
    {
        var result = await GetSuccessTaskAsync()
            .BindAsync(_ => GetSuccessAsync());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenBindAsyncToSuccessAsync_ThenShouldReturnSuccess()
    {
        var result = await GetSuccessTaskAsync()
            .BindAsync(_ => GetSuccessAsync());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }

    [Fact]
    public void GivenSuccessResult_WhenBindingToSuccessWithNewValue_ThenShouldReturnNewValue()
    {
        GetSuccess()
            .Bind(x => GetSuccess(2))
            .GetValue<int>().Value.Should().Be(2);
    }
    
    [Fact]
    public void GivenSuccessResult_WhenBindingToResultOfIResult_ThenShouldReturnNestedValue()
    {
        GetSuccess()
            .Bind(x => new Result<IResult>(new Result<string>("test")))
            .GetValue<string>().Value.Should().Be("test");
    }
    
    [Fact]
    public void GivenSuccessResult_WhenBindingToSuccessAndGettingMismatchedValue_ThenShouldReturnNotFoundFail()
    {
        GetSuccess()
            .Bind(x => GetSuccess())
            .GetValue<string>().Fail.Should().BeOfType<NotFoundFail>();
    }
}
