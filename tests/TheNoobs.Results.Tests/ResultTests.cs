using FluentAssertions;

namespace TheNoobs.Results.Tests;

public class ResultTests
{
    [Fact]
    public void GivenResultWhenSuccessThenValueShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public void GivenResultWhenSuccessThenSuccessShouldReturnTrue()
    {
        var result = new Result<string>("test");
        result.IsSuccess.Should().BeTrue();
    }
    
    [Fact]
    public void GivenResultWhenSuccessThenFailShouldReturnNull()
    {
        var result = new Result<string>("test");
        result.Fail.Should().BeNull();
    }
    
    [Fact]
    public void GivenResultWhenSuccessThenImplicitConverterShouldReturnTheValue()
    {
        string result = new Result<string>("test");
        result.Should().Be("test");
    }
    
    [Fact]
    public void GivenResultWhenSuccessThenDeconstructShouldReturnTheValue()
    {
        var (result, _) = new Result<string>("test");
        result.Should().Be("test");
    }
    
    [Fact]
    public void GivenResultWhenFailThenValueShouldThrow()
    {
        var result = new Result<string>(new TestFail());
        result.Invoking(r => _ = r.Value).Should().Throw<Exception>();
    }
    
    [Fact]
    public void GivenResultWhenFailThenSuccessShouldReturnFalse()
    {
        var result = new Result<string>(new TestFail());
        result.IsSuccess.Should().BeFalse();
    }
    
    [Fact]
    public void GivenResultWhenFailThenFailShouldReturnTheFail()
    {
        var result = new Result<string>(new TestFail());
        result.Fail.Should().NotBeNull();
        result.Fail.Should().BeOfType<TestFail>();
        result.Fail!.Code.Should().Be("test");
        result.Fail!.Message.Should().Be("Test");
    }
}

record TestFail() : Fail("Test", "test");
