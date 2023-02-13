﻿using ConventionAssertions.Internal;
using ConventionAssertions.Reflection;

namespace ConventionAssertions;

public class ConventionContext
{
    private readonly List<string> _messages = new();

    public IEnumerable<string> Messages => _messages.AsReadOnly();

    [DoesNotReturn]
    public void Fail(Type type, string message)
    {
        GuardAgainst.Null(type);
        GuardAgainst.NullOrWhiteSpace(message);

        _messages.Add($"Type {type.DisplayName()} {message}");
        throw new ConventionFailedException();
    }
}
