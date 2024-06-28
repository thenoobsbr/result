using FluentAssertions;
using NSubstitute;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using static TheNoobs.Results.Tests.Stubs.FunctionsStubs;
using Void = TheNoobs.Results.Types.Void;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTapTests
{
    [Fact]
    public void GivenFailResult_WhenTap_ThenActionShouldNotBeInvokedAndReturnTestFail()
    {
        var action = Substitute.For<Func<BindResult<int>, Result<Void>>>();
        
        var result = GetFail()
            .Tap(action);
        
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().BeOfType<TestFail>();
        action.DidNotReceive().Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public void GivenSuccessResult_WhenTapAndActionReturnsTestFail_ThenShouldReturnTestFail()
    {
        var action = Substitute.For<Func<BindResult<int>, Result<Void>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(new Result<Void>(new TestFail()));
        
        var result = GetSuccess()
            .Tap(action);
        
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().BeOfType<TestFail>();
        action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public void GivenSuccessResult_WhenTapAndActionReturnsSuccess_ThenShouldReturnOriginalValue()
    {
        var action = Substitute.For<Func<BindResult<int>, Result<Void>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(new Result<Void>(new Void()));
        
        var result = GetSuccess()
            .Tap(action);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
        action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenFailResult_WhenTapAsync_ThenActionShouldNotBeInvokedAndReturnTestFail()
    {
        var action = Substitute.For<Func<BindResult<int>, ValueTask<Result<Void>>>>();
        
        var result = await GetFail()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().BeOfType<TestFail>();
        await action.DidNotReceive().Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenTapAsyncAndActionReturnsTestFail_ThenShouldReturnTestFail()
    {
        var action = Substitute.For<Func<BindResult<int>, ValueTask<Result<Void>>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(ValueTask.FromResult(new Result<Void>(new TestFail())));
        
        var result = await GetSuccess()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().BeOfType<TestFail>();
        await action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenSuccessResult_WhenTapAsyncAndActionReturnsSuccess_ThenShouldReturnOriginalValue()
    {
        var action = Substitute.For<Func<BindResult<int>, ValueTask<Result<Void>>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(ValueTask.FromResult(new Result<Void>(new Void())));
        
        var result = await GetSuccess()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
        await action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenTapAsyncAndActionReturnsSuccess_ThenShouldReturnOriginalValue()
    {
        var action = Substitute.For<Func<BindResult<int>, Result<Void>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(new Result<Void>(new Void()));
        
        var result = await GetSuccessAsync()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
        action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenSuccessAsyncResult_WhenTapAsyncAndActionReturnsSuccessAsync_ThenShouldReturnOriginalValue()
    {
        var action = Substitute.For<Func<BindResult<int>, ValueTask<Result<Void>>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(ValueTask.FromResult(new Result<Void>(new Void())));
        
        var result = await GetSuccessAsync()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
        await action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenTapAsyncAndActionReturnsSuccess_ThenShouldReturnOriginalValue()
    {
        var action = Substitute.For<Func<BindResult<int>, Result<Void>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(new Result<Void>(new Void()));
        
        var result = await GetSuccessTaskAsync()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
        action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
    
    [Fact]
    public async Task GivenSuccessTaskAsyncResult_WhenTapAsyncAndActionReturnsSuccessAsync_ThenShouldReturnOriginalValue()
    {
        var action = Substitute.For<Func<BindResult<int>, ValueTask<Result<Void>>>>();
        action.Invoke(Arg.Any<BindResult<int>>())
            .Returns(ValueTask.FromResult(new Result<Void>(new Void())));
        
        var result = await GetSuccessTaskAsync()
            .TapAsync(action);
        
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
        await action.Received(1).Invoke(Arg.Any<BindResult<int>>());
    }
}
