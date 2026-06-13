namespace Practice2385;

public static class BoxExtensions
{
    public static Box<T> IsFull<T>(this Box<T> box)
    {
        if (box.HasValue) Console.WriteLine($"Box contains \"{box.Value!}\"");
        else Console.WriteLine("Box is empty");

        return box;
    }

    public static Box<T> Transform<T>(this Box<T> box, Func<T, T> func)
    {
        if (!box.HasValue)
        {
            return Box<T>.Empty();
        }

        var result = func(box.Value!);
        return Box<T>.Put(result);
    }

    public static Box<TResult> ConvertTo<T, TResult>(this Box<T> box, Func<T, TResult> func)
    {
        if (!box.HasValue)
            return Box<TResult>.Empty();

        var result = func(box.Value!);

        return Box<TResult>.Put(result);
    }

    public static Box<T> Describe<T>(this Box<T> box)
    {
        if (!box.HasValue)
        {
            Console.WriteLine("Has no value!");
        }
        else
        {
            Console.WriteLine(
                $"Has value: {box.HasValue} | " +
                $"The value: {box.Value} | " +
                $"Value type : {box.Value.GetType()}");
        }

        return box;
    }
}
