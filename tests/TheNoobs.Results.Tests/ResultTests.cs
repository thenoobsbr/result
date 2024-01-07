using FluentAssertions;
using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Exceptions;
using TheNoobs.Results.Types;

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
    public void GivenResultAsIResultWhenSuccessThenValueShouldReturnTheValue()
    {
        IResult result = new Result<string>("test");
        result.GetValue().Should().Be("test");
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
        result.Invoking(r => _ = r.Value).Should().Throw<InvalidResultValueException>();
    }
    
    [Fact]
    public void GivenResultAsIResultWhenFailThenValueShouldThrow()
    {
        IResult result = new Result<string>(new TestFail());
        result.Invoking(r => _ = r.GetValue()).Should().Throw<InvalidResultValueException>();
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
    
    [Fact]
    public void GivenResultWhenSetValueToItThenShouldImplicitlyConvertToResult()
    {
        Result<string> result = "test";
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
    
    [Fact]
    public void GivenResultWhenSetFailToItThenShouldImplicitlyConvertToResult()
    {
        Result<string> result = new TestFail();
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().NotBeNull();
        result.Fail.Should().BeOfType<TestFail>();
        result.Fail!.Code.Should().Be("test");
        result.Fail!.Message.Should().Be("Test");
    }
    
    [Fact]
    public void GivenResultWhenPipeTwoResultFailsThenShouldCombineTheFailures()
    {
        Result<string> first = new BadRequestFail();
        Result<string> second = new NotFoundFail();
        Result<string> third = new ServerErrorFail();
        var combinedResult = first | second | third;
        combinedResult.IsSuccess.Should().BeFalse();
        combinedResult.Fail.Should().NotBeNull();
        combinedResult.Fail.Should().BeOfType<AggregateFail>();
        combinedResult.Fail.As<AggregateFail>().Failures.Should().HaveCount(3);
        combinedResult.Fail.As<AggregateFail>().Failures.ElementAt(0).Should().Be(first.Fail);
        combinedResult.Fail.As<AggregateFail>().Failures.ElementAt(1).Should().Be(second.Fail);
        combinedResult.Fail.As<AggregateFail>().Failures.ElementAt(2).Should().Be(third.Fail);
    }

    [Theory]
    [MemberData(nameof(GetTypes))]
    public void GivenResultWhenCreateFromTypesThenShouldReturnTheTypeInstanceWithMessageAndCode(Fail fail, Type type, string message, string code)
    {
        
        fail.Should().NotBeNull();
        fail.Should().BeOfType(type);
        fail.Code.Should().Be(code);
        fail.Message.Should().Be(message);
    }

    public static IEnumerable<object[]> GetTypes()
    {
        yield return new object[] { new BadRequestFail(), typeof(BadRequestFail), "Bad request", "bad_request" };
        yield return new object[] { new ValidationFail(), typeof(ValidationFail), "Validation failed", "validation_failed" };
        yield return new object[] { new TimeoutFail(), typeof(TimeoutFail), "Request timed out", "timeout" };
        yield return new object[] { new ServerErrorFail(), typeof(ServerErrorFail), "Internal server error", "server_error" };
        yield return new object[] { new DuplicateResourceFail(), typeof(DuplicateResourceFail), "Duplicate resource found", "duplicate_resource" };
        yield return new object[] { new UnauthorizedFail(), typeof(UnauthorizedFail), "Unauthorized access", "unauthorized" };
        yield return new object[] { new UnprocessableEntityFail(), typeof(UnprocessableEntityFail), "Unprocessable entity", "unprocessable_entity" };
        yield return new object[] { new ConfigurationErrorFail(), typeof(ConfigurationErrorFail), "Configuration error", "config_error" };
        yield return new object[] { new NotFoundFail(), typeof(NotFoundFail), "Resource not found", "not_found" };
        yield return new object[] { new InsufficientPermissionsFail(), typeof(InsufficientPermissionsFail), "Insufficient permissions", "insufficient_permissions" };
        yield return new object[] { new InvalidInputFail(), typeof(InvalidInputFail), "Invalid input", "invalid_input" };
        yield return new object[] { new DataProcessingFail(), typeof(DataProcessingFail), "Error processing data", "data_processing_error" };
        yield return new object[] { new ResourceLockedFail(), typeof(ResourceLockedFail), "Resource is locked", "resource_locked" };
        yield return new object[] { new ThirdPartyServiceErrorFail(), typeof(ThirdPartyServiceErrorFail), "Error from third-party service", "third_party_error" };
        yield return new object[] { new RateLimitExceededFail(), typeof(RateLimitExceededFail), "Rate limit exceeded", "rate_limit_exceeded" };
    }
}

record TestFail() : Fail("Test", "test");
