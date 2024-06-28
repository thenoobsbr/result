using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTryCatchTests
{
    [Fact]
    public void A()
    {
        var result = new Result<string>("test");
        result.TryCatch<string, int>(
            x => 1,
            exception => new TestFail())
            .Value
            .Should().Be(1);
    }
    
    [Fact]
    public void B()
    {
        var result = new Result<string>(new TestFail());
        result.TryCatch<string, int>(
                x => 1,
                exception => new ServerErrorFail())
            .Fail
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void B2()
    {
        var result = new Result<string>("test");
        result.TryCatch<string, int>(
                x => Throw(),
                exception => new ServerErrorFail())
            .Fail
            .Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task C()
    {
        var result = await new Result<string>("test")
            .TryCatchAsync<string, int>(
                x => ValueTask.FromResult(new Result<int>(1)),
                exception => new ServerErrorFail());
        result.Value.Should().Be(1);
    }
    
    [Fact]
    public async Task D()
    {
        var result = await new Result<string>(new TestFail())
            .TryCatchAsync<string, int>(
                x => 1,
                exception => ValueTask.FromResult(new Result<int>(new ServerErrorFail())));
        result.Fail.Should().BeOfType<TestFail>();
    }
    
    
    [Fact]
    public async Task D2()
    {
        var result = await new Result<string>("test")
            .TryCatchAsync<string, int>(
                x => Throw(),
                exception => ValueTask.FromResult(new Result<int>(new ServerErrorFail())));
        result.Fail.Should().BeOfType<ServerErrorFail>();
    }
    
    [Fact]
    public async Task D3()
    {
        var result = await new Result<string>("test")
            .TryCatchAsync<string, int>(
                x => ThrowAsync(),
                exception => ValueTask.FromResult(new Result<int>(new ServerErrorFail())));
        result.Fail.Should().BeOfType<ServerErrorFail>();
    }
    
    private static Result<int> Throw()
    {
        throw new Exception();
    }
    
    private static ValueTask<Result<int>> ThrowAsync()
    {
        return ValueTask.FromResult(Throw());
    }
}
