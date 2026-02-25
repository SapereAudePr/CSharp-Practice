namespace EventsPractice
{
    internal class Program
    {
        public delegate void Notify(string s);

        public class EventPublisher
        {
            public event Notify OnNotify;

            public void RaiseEvent(string s)
            {
                OnNotify?.Invoke(s);
            }
        }

        public class EventSubscriber
        {
            public void OnEventRaised(string s)
            {
                Console.WriteLine($"Event received: {s}");
            }
        }

        static void Main(string[] args)
        {
            EventPublisher publisher = new();
            EventSubscriber subscriber = new();
            publisher.OnNotify += subscriber.OnEventRaised;
            publisher.RaiseEvent("Test");

            Console.ReadKey();
        }
    }
}
