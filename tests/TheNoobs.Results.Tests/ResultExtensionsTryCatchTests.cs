using FluentAssertions;
using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsTryCatchTests
{
    [Fact]
    public void GivenResultWhenSuccessThenTryCatchShouldReturnTheValue()
    {
        var result = new Result<string>("test");
        result.TryCatch(x => 1, error => new TestFail()).Value.Should().Be(1);
    }
    
    [Fact]
    public void GivenResultWhenThrowThenTryCatchShouldReturnTheFail()
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
    public async Task GivenValueTaskResultWhenSuccessThenTryCatchShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(x => 1, error => new TestFail())).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenThrowThenTryCatchShouldReturnTheFail()
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
    public async Task GivenTaskResultWhenSuccessThenTryCatchShouldReturnTheValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(x => 1, error => new TestFail())).Value.Should().Be(1);
    }
    
    [Fact]
    public async Task GivenTaskResultWhenThrowThenTryCatchShouldReturnTheFail()
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
    public async Task GivenValueTaskResultWhenSuccessThenTryCatchAsyncShouldReturnTheValue()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => new Result<int>(new TestFail(exception)))).Value.Should().Be(1);
        
        static ValueTask<int> GetValue(string value)
        {
            return ValueTask.FromResult(1);
        }
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenThrowThenTryCatchAsyncShouldReturnTheFail()
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
    public async Task GivenTaskResultWhenSuccessThenTryCatchAsyncShouldReturnTheValue()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => new Result<int>(new TestFail(exception)))).Value.Should().Be(1);
        
        static Task<int> GetValue(string value)
        {
            return Task.FromResult(1);
        }
    }
    
    [Fact]
    public async Task GivenTaskResultWhenThrowThenTryCatchAsyncShouldReturnTheFail()
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
    public async Task GivenValueTaskResultWhenSuccessThenTryCatchAsyncShouldReturnTheValueAsync()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => ValueTask.FromResult(new Result<int>(new TestFail(exception))))).Value.Should().Be(1);
        
        static int GetValue(string value)
        {
            return 1;
        }
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenThrowThenTryCatchAsyncShouldReturnTheFailAsync()
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
    public async Task GivenTaskResultWhenSuccessThenTryCatchAsyncShouldReturnTheValueAsync()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => Task.FromResult(new Result<int>(new TestFail(exception))))).Value.Should().Be(1);
        
        static int GetValue(string value)
        {
            return 1;
        }
    }
    
    [Fact]
    public async Task GivenTaskResultWhenThrowThenTryCatchAsyncShouldReturnTheFailAsync()
    {
        var result = Task.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetTaskAsync, exception => Task.FromResult(new Result<int>(new TestFail(exception)))))
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
    public async Task GivenValueTaskResultWhenSuccessAsyncThenTryCatchAsyncShouldReturnTheValueAsync()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => ValueTask.FromResult(new Result<int>(new TestFail(exception))))).Value.Should().Be(1);
        
        static ValueTask<int> GetValue(string value)
        {
            return ValueTask.FromResult(1);
        }
    }
    
    [Fact]
    public async Task GivenValueTaskResultWhenThrowAsyncThenTryCatchAsyncShouldReturnTheFailAsync()
    {
        var result = ValueTask.FromResult(new Result<string>("test"));
        var fail = (await result.TryCatchAsync<string, int>(GetTaskAsync, exception => ValueTask.FromResult(new Result<int>(new TestFail(exception)))))
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
    public async Task GivenTaskResultWhenSuccessAsyncThenTryCatchAsyncShouldReturnTheValueAsync()
    {
        var result = Task.FromResult(new Result<string>("test"));
        (await result.TryCatchAsync(GetValue, exception => Task.FromResult(new Result<int>(new TestFail(exception))))).Value.Should().Be(1);
        
        static Task<int> GetValue(string value)
        {
            return Task.FromResult(1);
        }
    }
    
    [Fact]
    public async Task GivenTaskResultWhenThrowAsyncThenTryCatchAsyncShouldReturnTheFailAsync()
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
