using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsCatchTests
{
    [Fact]
    public void Catch_GivenSuccessResult_ShouldReturnValue()
    {
        var result = new Result<string>(new NotFoundFail())
            .Catch<string, NotFoundFail>(x => new Result<string>("test"));
            
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public async Task Catch_GivenSuccessResult_WhenCatchAsync_ShouldReturnValue()
    {
        var result = await new Result<string>(new NotFoundFail())
            .CatchAsync<string, NotFoundFail>(x => ValueTask.FromResult(new Result<string>("test")));
            
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public async Task Catch_GivenSuccessResultValueTask_ShouldReturnValue()
    {
        var result = await ValueTask.FromResult(new Result<string>(new NotFoundFail()))
            .CatchAsync<string, NotFoundFail>(x => new Result<string>("test"));
            
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public async Task Catch_GivenSuccessResult_WhenCatchValueTaskAsync_ShouldReturnValue()
    {
        var result = await ValueTask.FromResult(new Result<string>(new NotFoundFail()))
            .CatchAsync<string, NotFoundFail>(x => ValueTask.FromResult(new Result<string>("test")));
            
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public async Task Catch_GivenSuccessResultTask_WhenCatch_ShouldReturnValue()
    {
        var result = await Task.FromResult(new Result<string>(new NotFoundFail()))
            .CatchAsync<string, NotFoundFail>(x => new Result<string>("test"));
            
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public async Task Catch_GivenSuccessResultTask_WhenCatchAsync_ShouldReturnValue()
    {
        var result = await Task.FromResult(new Result<string>(new NotFoundFail()))
            .CatchAsync<string, NotFoundFail>(x => ValueTask.FromResult(new Result<string>("test")));
            
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
}
