using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsBindTests
{
    [Fact]
    public void GivenResultWhenSuccessThenBindShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.Bind<string, int>(x => 1).Value.Should().Be(1);
    }

    [Fact]
    public void GivenResultWhenFailThenBindShouldReturnFail()
    {
        var result = new Result<string>(new TestFail());
        result.Bind<string, int>(x => 1).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenResultWhenValueTaskSuccessThenBindShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => new Result<int>(1))).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenResultWhenValueTaskFailThenBindShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => new Result<int>(1))).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenResultWhenTaskSuccessThenBindShouldReturnTheValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => new Result<int>(1))).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenResultWhenTaskFailThenBindShouldReturnFail()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => new Result<int>(1))).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenResultWhenValueTaskSuccessThenBindAsyncShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => ValueTask.FromResult(new Result<int>(1)))).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenResultWhenTaskSuccessThenBindAsyncShouldReturnTheValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.BindAsync(x => Task.FromResult(new Result<int>(1)))).Value.Should().Be(1);
    }

    [Fact]
    public async Task GivenResultWhenValueTaskFailThenBindAsyncShouldReturnFail()
    {
        var result = ValueTask.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => ValueTask.FromResult(new Result<int>(1)))).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public async Task GivenResultWhenTaskFailThenBindAsyncShouldReturnFail()
    {
        var result = Task.FromResult(new Result<string>(new TestFail()));
        (await result.BindAsync(x => Task.FromResult(new Result<int>(1)))).Fail.Should().BeOfType<TestFail>();
    }
}
