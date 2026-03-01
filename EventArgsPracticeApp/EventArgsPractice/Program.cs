namespace EventArgsPractice;
internal class Program
{
    public class TempEventArgs : EventArgs
    {
        public int Temperature { get; }
        private DateTime _time = DateTime.Now;
        public DateTime Time => _time;

        public string FormattedTime => Time.ToString("HH:mm:ss");

        public TempEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }

    public class TempMonitor
    {
        public event EventHandler<TempEventArgs>? HighTemp;

        private int _temperature;

        public int Temperature
        {
            get => _temperature;

            set
            {
                if (_temperature == value) return;
                _temperature = value;

                if (value > 30)
                {
                    RaiseHighTempEvent(new TempEventArgs(value));
                }
            }
        }

        protected virtual void RaiseHighTempEvent(TempEventArgs e)
        {
            HighTemp?.Invoke(this, e);
        }
    }

    public class AlertEvent
    {
        public void OnHighTempAlert(object? sender, TempEventArgs e)
        {
            if (sender is TempMonitor monitor)
            {
                Console.WriteLine($"Time: {e.FormattedTime} | Sender Temperature: {monitor.Temperature} | EventArgs Temperature: {e.Temperature}");
            }
        }
    }

    static void Main(string[] args)
    {
        TempMonitor monitor = new();
        AlertEvent alertEvent = new();
        monitor.HighTemp += alertEvent.OnHighTempAlert;

        Console.WriteLine("Temp input...");
        if (int.TryParse(Console.ReadLine(), out int temp)) monitor.Temperature = temp;


        Console.ReadKey();
    }
}
