﻿namespace ConventionAssertions.Internal;

public interface ITypeFilter : IFluentInterface
{
    Type Type { get; }

    bool IsClass { get; }

    bool IsInterface { get; }

    bool HasAttribute<T>()
        where T : Attribute;

    bool IsAssignableTo<T>();

    public bool IsAssignableTo(Type type);

    public bool IsAssignableToAny(params Type[] types);

    bool IsInSameNamespaceAs<T>();
}
