﻿namespace Darmankadeh.Core.Domain;

public abstract class ValueObject<T>
    where T : class
{
    protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

    public virtual bool IsEqual(ValueObject<T> other)
    {
        if (other == null) return false;

        return GetAttributesToIncludeInEqualityCheck().SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
    }

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        var hash = 0;
        foreach (var obj in GetAttributesToIncludeInEqualityCheck())
            hash = hash + (obj == null
                ? 0
                : obj.GetHashCode());

        return hash;
    }

    public override bool Equals(object obj)
    {
        return IsEqual((ValueObject<T>)obj);
    }
}

[Serializable]
public abstract class SimpleValueObject<T> : ValueObject
{
    protected SimpleValueObject(T value)
    {
        Value = value;
    }

    public T Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value?.ToString();
    }

    public static implicit operator T(SimpleValueObject<T> valueObject)
    {
        return valueObject == null
            ? default
            : valueObject.Value;
    }
}

[Serializable]
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
    private int? _cachedHashCode;

    public virtual int CompareTo(object obj)
    {
        var thisType = GetUnproxiedType(this);
        var otherType = GetUnproxiedType(obj);

        if (thisType != otherType)
            return string.Compare(
                thisType.ToString(), otherType.ToString(),
                StringComparison.Ordinal);

        var other = (ValueObject)obj;

        var components = GetEqualityComponents().ToArray();
        var otherComponents = other.GetEqualityComponents().ToArray();

        for (var i = 0; i < components.Length; i++)
        {
            var comparison = CompareComponents(components[i], otherComponents[i]);
            if (comparison != 0)
                return comparison;
        }

        return 0;
    }

    public virtual int CompareTo(ValueObject other)
    {
        return CompareTo(other as object);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        if (!_cachedHashCode.HasValue)
            _cachedHashCode = GetEqualityComponents()
                .Aggregate(
                    1, (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    });

        return _cachedHashCode.Value;
    }

    private int CompareComponents(object object1, object object2)
    {
        if (object1 is null && object2 is null)
            return 0;

        if (object1 is null)
            return -1;

        if (object2 is null)
            return 1;

        if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
            return comparable1.CompareTo(comparable2);

        return object1.Equals(object2)
            ? 0
            : -1;
    }

    public static bool operator ==(ValueObject a, ValueObject b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject a, ValueObject b)
    {
        return !(a == b);
    }

    internal static Type GetUnproxiedType(object obj)
    {
        const string EFCoreProxyPrefix = "Castle.Proxies.";
        const string NHibernateProxyPostfix = "Proxy";

        var type = obj.GetType();
        var typeString = type.ToString();

        if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
            return type.BaseType;

        return type;
    }
}