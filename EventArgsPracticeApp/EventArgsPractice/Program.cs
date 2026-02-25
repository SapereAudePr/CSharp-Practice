namespace EventArgsPractice
{
    internal class Program
    {
        public class TemperatureChangedEventArgs : EventArgs
        {
            public int Temperature { get; }

            // TODO: Build these later on
            // -------------------------------------
            //public bool IsCritical { get; }
            //public DateTime Timestamp { get; }
            //public string SensorId { get; }
            // -------------------------------------

            public TemperatureChangedEventArgs(int temperature)
            {
                Temperature = temperature;
            }
        }

        public class TemperatureMonitor
        {
            public event EventHandler<TemperatureChangedEventArgs> ?HighTemperature;

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
                        RaiseHighTempAlert(new TemperatureChangedEventArgs(value));
                    }
                }
            }

            protected virtual void RaiseHighTempAlert(TemperatureChangedEventArgs e)
            {
                HighTemperature?.Invoke(this, e);
            }
        }

        public class AlertEvents
        {
            public void OnHighTempAlert(object? sender, TemperatureChangedEventArgs e)
            {
                Console.WriteLine($"[OnHighTempAlert] | The temp is: {e.Temperature} and the sender: {sender}");
            }
        }

        static void Main(string[] args)
        {
            TemperatureMonitor tempMonitor = new();
            AlertEvents alertEvents = new();
            tempMonitor.HighTemperature += alertEvents.OnHighTempAlert;

            Console.WriteLine("Enter temp input");
            if (int.TryParse(Console.ReadLine(), out int temp))
            {
                tempMonitor.Temperature = temp;
            }

            Console.ReadKey();
        }
    }
}
