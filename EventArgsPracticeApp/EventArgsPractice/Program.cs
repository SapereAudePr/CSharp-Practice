namespace EventArgsPractice;
internal class Program
{
    public class TempEventArgs : EventArgs
    {
        public int Temperature { get; }

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

                if (value > 30) RaiseHighTempEvent(new TempEventArgs(value));
            }
        }

        protected virtual void RaiseHighTempEvent(TempEventArgs e)
        {
            HighTemp?.Invoke(this, e);
        }
    }

    //Subscribers
    public class AlertEvent
    {
        public void OnHighTempAlert(object? sender, TempEventArgs e)
        {
            if (sender is TempMonitor monitor) Console.WriteLine($"Sender's temp: {monitor.Temperature} | Global Temp: {e.Temperature}");
        }
    }

    static void Main(string[] args)
    {
        TempMonitor monitor = new();
        AlertEvent events = new();
        monitor.HighTemp += events.OnHighTempAlert;

        Console.WriteLine("Temp input...");
        if (int.TryParse(Console.ReadLine(), out int temp)) monitor.Temperature = temp;
        else throw new Exception("Invalid input");

        Console.ReadKey();
    }
}
