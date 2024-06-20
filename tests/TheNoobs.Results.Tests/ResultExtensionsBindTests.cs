using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsBindTests
{
    [Fact]
    public void Bind_GivenSuccessResult_ShouldReturnValue()
    {
        var result = new Result<string>("test");
        result.Bind<string, int>(x => 1).Value.Should().Be(1);
    }

    [Fact]
    public void Bind_GivenFailResult_ShouldReturnFail()
    {
        var result = new Result<string>(new TestFail());
        result.Bind<string, int>(x => 1).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task BindAsync_GivenValueTaskSuccessResult_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => new Result<int>(1))).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task BindAsync_GivenValueTaskFailResult_ShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => new Result<int>(1))).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task BindAsync_GivenTaskSuccessResult_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => new Result<int>(1))).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task BindAsync_GivenTaskFailResult_ShouldReturnFail()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => new Result<int>(1))).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task BindAsync_GivenValueTaskSuccessResult_WhenBoundAsync_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => ValueTask.FromResult(new Result<int>(1)))).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task BindAsync_GivenTaskSuccessResult_WhenBoundAsync_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => Task.FromResult(new Result<int>(1)))).Value.Should().Be(1);
    }

    [Fact]
    public async Task BindAsync_GivenValueTaskFailResult_WhenBoundAsync_ShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => ValueTask.FromResult(new Result<int>(1)))).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task BindAsync_GivenTaskFailResult_WhenBoundAsync_ShouldReturnFail()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => Task.FromResult(new Result<int>(1)))).Fail.Should().BeOfType<TestFail>();
    }
}
