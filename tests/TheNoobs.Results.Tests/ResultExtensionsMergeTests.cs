﻿using System.ComponentModel;
using FluentAssertions;
using TheNoobs.Results.Extensions;
using TheNoobs.Results.Tests.Stubs;
using TheNoobs.Results.Types;
using static TheNoobs.Results.Tests.Stubs.FunctionsStubs;

namespace TheNoobs.Results.Tests;

public class ResultExtensionsMergeTests
{
    [Fact]
    public void GivenTwoSuccessAndOneFailureResult_WhenMerged_ThenShouldReturnAggregateFail()
    {
        var result = new Result<int>(1);
        var result2 = new Result<int>(2);
        var result3 = new Result<int>(new TestFail());
        var mergeResult = result
            .Merge(result2)
            .Merge(result3);
        mergeResult
            .Fail.Should().BeOfType<AggregateFail>();
        mergeResult.Fail
            .As<AggregateFail>().Failures.First()
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenManySuccessResults_WhenMerged_ThenShouldReturnValues()
    {
        var result = new Result<int>(1)
            .Merge(new Result<int>(2), new Result<int>(3), new Result<int>(4));
        result
            .GetValueByIndex<int>(0)
            .Value
            .Should().Be(1);
        result
            .GetValueByIndex<int>(1)
            .Value
            .Should().Be(2);
        result
            .GetValueByIndex<int>(2)
            .Value
            .Should().Be(3);
        result
            .GetValueByIndex<int>(3)
            .Value
            .Should().Be(4);
    }
    
    [Fact]
    public void GivenTwoSuccessAndOneFailureResultInEnumeration_WhenMerged_ThenShouldReturnAggregateFail()
    {
        var resultList = new List<Result<int>>
        {
            new(1),
            new(2),
            new(new TestFail())
        };
        var mergeResult = resultList.Merge();
        mergeResult
            .Fail.Should().BeOfType<AggregateFail>();
        mergeResult.Fail
            .As<AggregateFail>().Failures.First()
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenManySuccessResultsInEnumeration_WhenMerged_ThenShouldReturnValues()
    {
        var resultList = new List<Result<int>> {
            new(1),
            new(2),
            new(3),
            new(4)
        };
        var result = resultList.Merge();
        result
            .GetValueByIndex<int>(0)
            .Value
            .Should().Be(1);
        result
            .GetValueByIndex<int>(1)
            .Value
            .Should().Be(2);
        result
            .GetValueByIndex<int>(2)
            .Value
            .Should().Be(3);
        result
            .GetValueByIndex<int>(3)
            .Value
            .Should().Be(4);
    }
    
    [Fact]
    public void GivenTwoSuccessAndOneFailureResultInEnumeration_WhenMergedWithMapping_ThenShouldReturnAggregateFail()
    {
        var resultList = new List<Result<int>>
        {
            new(1),
            new(2),
            new(new TestFail())
        };
        var mergeResult = resultList.Merge(x => x.Value * 2);
        mergeResult
            .Fail.Should().BeOfType<AggregateFail>();
        mergeResult.Fail
            .As<AggregateFail>().Failures.First()
            .Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenManySuccessResultsInEnumeration_WhenMergedWithMapping_ThenShouldReturnValues()
    {
        var resultList = new List<Result<int>> {
            new(1),
            new(2),
            new(3),
            new(4)
        };
        var result = resultList.Merge(x => x.Value * 2);    
        result
            .Value
            .Should()
            .HaveElementAt(0, 2);
        result
            .Value
            .Should()
            .HaveElementAt(1, 4);
        result
            .Value
            .Should()
            .HaveElementAt(2, 6);
        result
            .Value
            .Should()
            .HaveElementAt(3, 8);
    }
    
    [Fact]
    public void GivenManySuccessResults_WhenMerged_ThenShouldReturnFirstValue()
    {
        var result = new Result<string>("test1")
            .Merge(
                new Result<int>(2),
                new Result<DateTime>(DateTime.UtcNow))
            .Bind(x => x.GetValue<string>());
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test1");
    }
    
    [Fact]
    public void GivenFailureAndManySuccessResults_WhenMerged_ThenShouldReturnTestFail()
    {
        var result = GetFail()
            .Merge(
                new Result<int>(2),
                new Result<DateTime>(DateTime.UtcNow))
            .Bind(x => x.GetValue<string>());
        result.IsSuccess.Should().BeFalse();
        result.Fail.Should().BeOfType<TestFail>();
    }

    [Fact]
    public void GivenSuccessResult_WhenMergingWithSuccessResults_ThenShouldReturnLatestValue()
    {
        GetSuccess()
            .Merge(new Result<string>("2"),
                new Result<DateTime>(DateTime.UtcNow))
            .GetValue<DateTime>().Value.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }
    
    [Fact]
    public void GivenFailResult_WhenMergingWithSuccessResults_ThenShouldReturnOriginalFail()
    {
        GetFail()
            .Merge(new Result<string>("2"),
                new Result<DateTime>(DateTime.UtcNow))
            .GetValue<DateTime>().Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenFailResult_WhenMergingWithSuccessResults_ThenShouldReturnOriginalFailOnGetValueByIndex()
    {
        GetFail()
            .Merge(new Result<string>("2"),
                new Result<DateTime>(DateTime.UtcNow))
            .GetValueByIndex<DateTime>(1).Fail.Should().BeOfType<TestFail>();
    }
    
    [Fact]
    public void GivenSuccessResult_WhenMergingWithSuccessResults_ThenShouldReturnNotFoundFailOnInvalidIndex()
    {
        GetSuccess()
            .Merge(new Result<string>("2"),
                new Result<DateTime>(DateTime.UtcNow))
            .GetValueByIndex<DateTime>(5).Fail.Should().BeOfType<NotFoundFail>();
    }
}
