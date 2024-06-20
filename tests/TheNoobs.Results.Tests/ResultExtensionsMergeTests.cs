using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsMergeTests
{
    [Fact]
    public void Merge_GivenTwoSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        result.Merge(result2).Value.Should().Be((1, 2));
    }
    
    [Fact]
    public void Merge_GivenOneSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(new TestFail());
        result.Merge(result2).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenThreeSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        result
            .Merge(result2)
            .Merge(result3)
            .Value.Should().Be((1, 2, 3));
    }
    
    [Fact]
    public void Merge_GivenTwoSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(new TestFail());
        result
            .Merge(result2)
            .Merge(result3)
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenFourSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Value.Should().Be((1, 2, 3, 4));
    }
    
    [Fact]
    public void Merge_GivenThreeSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(new TestFail());
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenFiveSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Value.Should().Be((1, 2, 3, 4, 5));
    }
    
    [Fact]
    public void Merge_GivenFourSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(new TestFail());
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenSixSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        var result6 = new Result<int>(6);
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Merge(result6)
            .Value.Should().Be((1, 2, 3, 4, 5, 6));
    }
    
    [Fact]
    public void Merge_GivenFiveSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        var result6 = new Result<int>(new TestFail());
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Merge(result6)
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenSevenSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        var result6 = new Result<int>(6);
        var result7 = new Result<int>(7);
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Merge(result6)
            .Merge(result7)
            .Value.Should().Be((1, 2, 3, 4, 5, 6, 7));
    }
    
    [Fact]
    public void Merge_GivenSixSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        var result6 = new Result<int>(6);
        var result7 = new Result<int>(new TestFail());
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Merge(result6)
            .Merge(result7)
            .Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void Merge_GivenEightSuccessResults_WhenMerged_ShouldReturnTupleOfValues()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        var result6 = new Result<int>(6);
        var result7 = new Result<int>(7);
        var result8 = new Result<int>(8);
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Merge(result6)
            .Merge(result7)
            .Merge(result8)
            .Value.Should().Be((1, 2, 3, 4, 5, 6, 7, 8));
    }
    
    [Fact]
    public void Merge_GivenSevenSuccessAndOneFailureResult_WhenMerged_ShouldReturnFailure()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(3);
        var result4 = new Result<int>(4);
        var result5 = new Result<int>(5);
        var result6 = new Result<int>(6);
        var result7 = new Result<int>(7);
        var result8 = new Result<int>(new TestFail());
        result
            .Merge(result2)
            .Merge(result3)
            .Merge(result4)
            .Merge(result5)
            .Merge(result6)
            .Merge(result7)
            .Merge(result8)
            .Fail.Should().BeOfType<TestFail>();
    }
}
