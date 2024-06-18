using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTapTests
{
    [Fact]
    public void GivenResultWhenSuccessThenTapShouldExecuteFunction()
    {
        var value = "";
        var result = new Result<string>("test");
        result.Tap(x => value = x).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public void GivenResultWhenFailThenTapShouldNotExecuteFunction()
    {
        var value = "";
        var result = new Result<string>(new TestFail());
        result.Tap(x => value = x).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public void GivenResultWhenSuccessThenTapAsyncShouldExecuteFunction()
    {
        var value = "";
        var result = new Result<string>("test");
        result.Tap(x => value = x).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task GivenResultValueTaskWhenSuccessThenTapShouldNotExecuteFunction()
    {
        var value = "";
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TapAsync(x => value = x)).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task GivenResultValueTaskWhenFailThenTapShouldNotExecuteFunction()
    {
        var value = "";
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.TapAsync(x => value = x)).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public async Task GivenResultTaskWhenSuccessThenTapShouldNotExecuteFunction()
    {
        var value = "";
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TapAsync(x => value = x)).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task GivenResultTasWhenFailThenTapShouldNotExecuteFunction()
    {
        var value = "";
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.TapAsync(x => value = x)).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public async Task GivenResultValueTaskWhenSuccessThenTapAsyncShouldNotExecuteFunction()
    {
        var value = "";
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TapAsync(x =>
        {
            value = x;
            return ValueTask.CompletedTask;
        })).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task GivenResultValueTaskWhenFailThenTapAsyncShouldNotExecuteFunction()
    {
        var value = "";
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.TapAsync(x =>
        {
            value = x;
            return ValueTask.CompletedTask;
        })).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public async Task GivenResultTaskWhenSuccessThenTapAsyncShouldNotExecuteFunction()
    {
        var value = "";
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TapAsync(x =>
        {
            value = x;
            return Task.CompletedTask;
        })).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task GivenResultTaskWhenFailThenTapAsyncShouldNotExecuteFunction()
    {
        var value = "";
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.TapAsync(x =>
        {
            value = x;
            return Task.CompletedTask;
        })).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
}
