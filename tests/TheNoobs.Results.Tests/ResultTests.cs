using FluentAssertions;
using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Exceptions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;

namespace TheNoobs.Results.Tests;

public class ResultTests
{
    [Fact]
    public void GivenSuccessResult_WhenGettingValue_ThenShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.IsSuccess.Should().BeTrue();
        result.ResultType.Should().Be(typeof(string));
        result.Value.Should().Be("test");
    }

    [Fact]
    public void GivenSuccessResultAsIResult_WhenGettingValue_ThenShouldReturnTheValue()
    {
        IResult result = new Result<string>("test");
        result.GetValue().Should().Be("test");
    }

    [Fact]
    public void GivenFailResult_WhenGettingTypedValue_ThenShouldReturnFail()
    {
        var result = new Result<string>(new TestFail());
        result.GetValue<string>().Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenSuccessResult_WhenGettingTypedValue_ThenShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.GetValue<string>().Value.Should().Be("test");
    }
    
    [Fact]
    public void GivenSuccessResult_WhenGettingMismatchedTypedValue_ThenShouldReturnNotFoundFail()
    {
        var result = new Result<string>("test");
        result.GetValue<int>().Fail.Should().BeOfType<NotFoundFail>();
    }

    [Fact]
    public void GivenSuccessResult_WhenCheckingSuccess_ThenShouldReturnTrue()
    {
        var result = new Result<string>("test");
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void GivenSuccessResult_WhenGettingFail_ThenShouldReturnNull()
    {
        var result = new Result<string>("test");
        result.Fail.Should().BeNull();
    }

    [Fact]
    public void GivenSuccessResult_WhenImplicitConversion_ThenShouldReturnTheValue()
    {
        string result = new Result<string>("test");
        result.Should().Be("test");
    }

    [Fact]
    public void GivenSuccessResult_WhenDeconstructing_ThenShouldReturnTheValue()
    {
        var (result, _) = new Result<string>("test");
        result.Should().Be("test");
    }

    [Fact]
    public void GivenFailResult_WhenGettingValue_ThenShouldThrowInvalidResultValueException()
    {
        var result = new Result<string>(new TestFail());
        result.Invoking(r => _ = r.Value).Should().Throw<InvalidResultValueException>();
    }

    [Fact]
    public void GivenFailResultAsIResult_WhenGettingValue_ThenShouldThrowInvalidResultValueException()
    {
        IResult result = new Result<string>(new TestFail());
        result.Invoking(r => _ = r.GetValue()).Should().Throw<InvalidResultValueException>();
    }

    [Fact]
    public void GivenFailResult_WhenCheckingSuccess_ThenShouldReturnFalse()
    {
        var result = new Result<string>(new TestFail());
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void GivenFailResult_WhenGettingFail_ThenShouldReturnTheFail()
    {
        var result = new Result<string>(new TestFail(new NotImplementedException()));
        result.Fail.Should().NotBeNull();
        result.Fail.Should().BeOfType<TestFail>();
        result.Fail!.Code.Should().Be("test");
        result.Fail!.Message.Should().Be("Test");
        result.Fail!.Exception.Should().BeOfType<NotImplementedException>();
    }

    [Fact]
    public void GivenSuccessResult_WhenImplicitlyConvertingFromValue_ThenShouldReturnResultWithSuccess()
    {
        Result<string> result = "test";
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }

    [Fact]
    public void GivenFailResult_WhenImplicitlyConvertingFromFail_ThenShouldReturnResultWithFail()
    {
        Result<string> result = new TestFail();
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().NotBeNull();
        result.Fail.Should().BeOfType<TestFail>();
        result.Fail!.Code.Should().Be("test");
        result.Fail!.Message.Should().Be("Test");
    }

    [Theory]
    [MemberData(nameof(GetTypes))]
    public void GivenFailTypes_WhenCreatingResultFromType_ThenShouldReturnTheCorrectTypeInstanceWithMessageAndCode(Fail fail, Type type, string message, string code)
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
