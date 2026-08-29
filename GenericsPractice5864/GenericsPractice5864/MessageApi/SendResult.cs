namespace GenericsPractice5864.MessageApi;

public record ChatMessage(string Sender, string Text, DateTime SentAt);
public record Notification(string Title, string Body);

public class SendResult<T>(T payload, string? failReason, bool delivered = false)
{
    public T? Payload { get; } = payload;
    public bool Delivered { get; } = delivered;
    public string? FailReason { get; } = failReason;


    public static SendResult<T> Ok(T payload) => new(payload, null, true);
    public static SendResult<T> Fail(string failReason) =>
        new(default!, failReason, false);
}

public class Thread<T>(List<T> messages, int unreadCount)
{
    public List<T> Messages { get; } = messages;
    public int UnreadCount { get; } = unreadCount;
}
