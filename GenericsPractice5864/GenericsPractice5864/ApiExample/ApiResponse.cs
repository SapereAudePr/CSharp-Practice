namespace GenericsPractice5864.ApiExample;

public record Book(string Title, Author Author, int Year);
public record Author(string Name, int BooksPublished);

public class ApiResponse<T>(T value, bool isValid, List<string>? errorMessages = null)
{
    public T? Value { get; } = value;
    public bool IsValid { get; } = isValid;
    public List<string>? ErrorMessages { get; } = errorMessages;

    public static ApiResponse<T> Success(T value) => new(value, true);
    public static ApiResponse<T> Fail(params string[] errors) =>
        new(default!, false, [.. errors]);
}

public class PagedList<T>(List<T> items, int page, int pageSize, int totalCount)
{
    public List<T> Items { get; } = items;
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
    public int TotalCount { get; } = totalCount;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}
