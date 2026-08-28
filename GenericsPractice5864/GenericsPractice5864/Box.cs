namespace GenericsPractice5864;

public class Box<T>(T contents)
{
    public T Contents { get; } = contents;
}

public class Delivery<T>(T package, bool arrived)
{
    public T Package { get; } = package;
    public bool Arrived { get; } = arrived;

    public static Delivery<T> Success(T package) => new(package, true);
    public static Delivery<T> Failure() => new(default!, false);
}

public class Create<T>(List<T> items)
{
    public List<T> Items { get; } = items;
    public int Counts => Items.Count;
}
