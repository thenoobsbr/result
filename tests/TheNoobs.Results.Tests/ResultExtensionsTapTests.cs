using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTapTests
{
    [Fact]
    public void Tap_GivenSuccessResult_WhenInvoked_ShouldExecuteFunction()
    {
        var value = "";
        var result = new Result<string>("test");
        result.Tap(x => value = x).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public void Tap_GivenFailureResult_WhenInvoked_ShouldNotExecuteFunction()
    {
        var value = "";
        var result = new Result<string>(new TestFail());
        result.Tap(x => value = x).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public void TapAsync_GivenSuccessResult_WhenInvoked_ShouldExecuteFunction()
    {
        var value = "";
        var result = new Result<string>("test");
        result.Tap(x => value = x).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task TapAsync_GivenSuccessResultWithValueTask_WhenInvoked_ShouldExecuteFunction()
    {
        var value = "";
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TapAsync(x => value = x)).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task TapAsync_GivenFailureResultWithValueTask_WhenInvoked_ShouldNotExecuteFunction()
    {
        var value = "";
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.TapAsync(x => value = x)).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public async Task TapAsync_GivenSuccessResultWithTask_WhenInvoked_ShouldExecuteFunction()
    {
        var value = "";
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TapAsync(x => value = x)).Value.Should().Be("test");
        value.Should().Be("test");
    }
    
    [Fact]
    public async Task TapAsync_GivenFailureResultWithTask_WhenInvoked_ShouldNotExecuteFunction()
    {
        var value = "";
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.TapAsync(x => value = x)).Fail.Should().BeOfType<TestFail>();
        value.Should().Be("");
    }
    
    [Fact]
    public async Task TapAsync_GivenSuccessResultWithValueTaskReturningValueTask_WhenInvoked_ShouldExecuteFunction()
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
    public async Task TapAsync_GivenFailureResultWithValueTaskReturningValueTask_WhenInvoked_ShouldNotExecuteFunction()
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
    public async Task TapAsync_GivenSuccessResultWithTaskReturningTask_WhenInvoked_ShouldExecuteFunction()
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
    public async Task TapAsync_GivenFailureResultWithTaskReturningTask_WhenInvoked_ShouldNotExecuteFunction()
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
