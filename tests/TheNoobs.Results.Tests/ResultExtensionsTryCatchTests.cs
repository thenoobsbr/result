using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTryCatchTests
{
    [Fact]
    public void TryCatch_GivenSuccessResult_WhenInvoked_ShouldReturnValue()
    {
        var result = new Result<string>("test");
        result.TryCatch(x => 1, error => new TestFail()).Value.Should().Be(1);
    }
    
    [Fact]
    public void TryCatch_GivenExceptionResult_WhenInvoked_ShouldReturnFailure()
    {
        var result = new Result<string>("test");
        var fail = result
            .TryCatch<string, int>(x => throw new FileLoadException(), exception => new TestFail(exception))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenSuccessResultWithValueTask_WhenInvoked_ShouldReturnValue()
    {
        var result = new Result<string>("test");
        (await result.TryCatchAsync(x => ValueTask.FromResult(1), error => new TestFail())).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenExceptionResultWithValueTask_WhenInvoked_ShouldReturnFailure()
    {
        var result = new Result<string>("test");
        var fail = (await result
            .TryCatchAsync(GetValueAsync, exception => new TestFail(exception)))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();

        static ValueTask<int> GetValueAsync(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenSuccessResultWithTask_WhenInvoked_ShouldReturnValue()
    {
        var result = new Result<string>("test");
        (await result.TryCatchAsync(x => Task.FromResult(1), error => new TestFail())).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenExceptionResultWithTask_WhenInvoked_ShouldReturnFailure()
    {
        var result = new Result<string>("test");
        var fail = (await result
                .TryCatchAsync(GetValueAsync, exception => new TestFail(exception)))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();

        static Task<int> GetValueAsync(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenValueTaskResultWithSuccess_WhenInvoked_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(x => 1, error => new TestFail())).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenValueTaskResultWithException_WhenInvoked_ShouldReturnFailure()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetValue, exception => new TestFail(exception)))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();
        
        static int GetValue(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenTaskResultWithSuccess_WhenInvoked_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(x => 1, error => new TestFail())).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenTaskResultWithException_WhenInvoked_ShouldReturnFailure()
    {
        var result = Task.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetValue, exception => new TestFail(exception)))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();
        
        static int GetValue(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenValueTaskResultWithSuccessAsync_WhenInvoked_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => new Result<int>(new TestFail(exception)))).Value.Should().Be(1);
        
        static ValueTask<int> GetValue(string value)
        {
            return ValueTask.FromResult(1);
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenValueTaskResultWithExceptionAsync_WhenInvoked_ShouldReturnFailure()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetTaskAsync, exception => new TestFail(exception)))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();

        static ValueTask<int> GetTaskAsync(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenTaskResultWithSuccessAsync_WhenInvoked_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => new Result<int>(new TestFail(exception)))).Value.Should().Be(1);
        
        static Task<int> GetValue(string value)
        {
            return Task.FromResult(1);
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenTaskResultWithExceptionAsync_WhenInvoked_ShouldReturnFailure()
    {
        var result = Task.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetTaskAsync, exception => new TestFail(exception)))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();

        static Task<int> GetTaskAsync(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenValueTaskResultWithSuccessReturningValueAsync_WhenInvoked_ShouldReturnValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => ValueTask.FromResult(new Result<int>(new TestFail(exception))))).Value.Should().Be(1);
        
        static int GetValue(string value)
        {
            return 1;
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenValueTaskResultWithExceptionReturningFailureAsync_WhenInvoked_ShouldReturnFailure()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetTaskAsync, exception => ValueTask.FromResult(new Result<int>(new TestFail(exception)))))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();

        static int GetTaskAsync(string value)
        {
            throw new FileLoadException();
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenTaskResultWithSuccessReturningValueAsync_WhenInvoked_ShouldReturnValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => Task.FromResult(new Result<int>(new TestFail(exception))))).Value.Should().Be(1);
        
        static int GetValue(string value)
        {
            return 1;
        }
    }
    
    [Fact]
    public async Task TryCatchAsync_GivenTaskResultWithExceptionReturningFailureAsync_WhenInvoked_ShouldReturnFailure()
    {
        var result = Task.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetTaskAsync, exception => Task.FromResult(new Result<int>(new TestFail(exception)))))
            .Fail as TestFail;
        fail.Should().NotBeNull();
        fail!.Exception.Should().NotBeNull();
        fail.Exception.Should().BeOfType<FileLoadException>();

        static Task<int> GetTaskAsync(string value)
        {
            throw new FileLoadException();
        }
    }
}
