using System.Runtime.CompilerServices;

namespace Practice2385;

public class Box<T>
{
    public T? Value { get; }
    public bool HasValue { get; }

    public Box(T? value, bool hasValue)
    {
        Value = value;
        HasValue = hasValue;
    }

    public static Box<T> Put(T value)
    {
        return new Box<T>(value, true);
    }

    public static Box<T> Empty() 
    {
        return new Box<T>(default, false);
    }
}