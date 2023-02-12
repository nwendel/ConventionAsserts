﻿using ConventionAssertions.Internal;

namespace ConventionAssertions.Tests;

public class ConventionContextTests
{
    private readonly ConventionContext _tested = new("some-id");

    [Fact]
    public void Throws_on_fail_null_type()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _tested.Fail(null!, "message"));
        Assert.Equal("type", ex.ParamName);
    }

    [Fact]
    public void Throws_on_fail_null_message()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _tested.Fail(typeof(object), null!));
        Assert.Equal("message", ex.ParamName);
    }

    [Fact]
    public void Throws_on_fail()
    {
        _ = Assert.Throws<ConventionFailedException>(() => _tested.Fail(typeof(object), "some-message"));
        var message = Assert.Single(_tested.Messages);
        Assert.Equal("Type Object some-message", message);
    }
}
