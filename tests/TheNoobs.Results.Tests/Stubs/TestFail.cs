using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Tests.Stubs;

internal record TestFail(Exception? Exception = null) : Fail("Test", "test");
