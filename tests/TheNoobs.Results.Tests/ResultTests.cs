using System.Runtime.CompilerServices;
using Void = TheNoobs.Results.Types.Void;

namespace TheNoobs.Results.Tests;

public class ResultTests
{
    [Fact]
    public void Test1()
    {
        var result = new Result<string>("teste");
        var (value, fail) = result;
        Assert.Equal("teste", value);
        Assert.Null(fail);
        Assert.Equal("teste", result);
        Assert.True(result.IsSuccess);
        Assert.Null(result.Fail);
    }
    
    [Fact]
    public void Test2()
    {
        var result = new Result<string>(new TestFail());
        var (value, fail) = result;
        Assert.Null(value);
        Assert.NotNull(fail);
        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Fail);

        switch (result.Fail)
        {
            case TestFail testFail:
                Assert.Equal("Test2", testFail.MemberName);
                break;
        }
    }

    [Fact]
    public void Test3()
    {
        var result = new Result<Void>(new Void());
        var (_, fail) = result;
        Assert.Null(fail);
    }
}

record TestFail([CallerMemberName] string memberName = null!) : Fail("Test", "test")
{
    public string MemberName { get; } = memberName;
}
