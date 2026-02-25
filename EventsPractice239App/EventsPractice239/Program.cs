namespace EventsPractice239
{
    //Delegate
    public delegate void EventHandler(int i);

    //Publisher
    public class TemperatureMonitor
    {
        public event EventHandler? OnTempHitAbove;
        public event EventHandler? OnTempHitBelow;

        private int _temperature;
        public int Temperature
        {
            get => _temperature;
            

            set
            {
                if (_temperature == value) return;

                _temperature = value;

                if (_temperature > 30)
                {
                    OnTempHitAbove?.Invoke(_temperature);
                }
                else if (_temperature < 20)
                {
                    OnTempHitBelow?.Invoke(_temperature);
                }
            }
        }
    }

    //Subscriber 
    public class AlertEvent
    {
        TemperatureMonitor _tempMonitor;

        public AlertEvent(TemperatureMonitor tempMonitor)
        {
            _tempMonitor = tempMonitor;
        }

        //The method which subscribes to the delegate
        public void HighTemp(int i)
        {
            Console.WriteLine($"[HighTemp] | Temp is above threshold : {i}");
            //Unnecessary but can be done
            //CooldownTemp();
        }

        private void CooldownTemp()
        {
            _tempMonitor.Temperature = 20;
            Console.WriteLine($"Temp is set back to default value: {_tempMonitor.Temperature}");
        }

        // the method which subscribed in OnTempHitBelow event's invoke list
        public void LowTemp(int i)
        {
            Console.WriteLine($"[LowTemp] | Temp is below threshold : {i}");
        }
    }

    // Another Subscriber for OnTempHitAbove event
    public class SetTemp
    {
        TemperatureMonitor _tempMonitor;

        public SetTemp(TemperatureMonitor tempMonitor)
        {
            _tempMonitor = tempMonitor;
        }

        public void SetTempBackDefault(int i)
        {
            _tempMonitor.Temperature = 20;
            Console.WriteLine($"[SetTemp] | Temp is set back to default value: {_tempMonitor.Temperature}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureMonitor tempMonitor = new();
            SetTemp setTemp = new(tempMonitor);
            AlertEvent alertEvent = new(tempMonitor);

            tempMonitor.OnTempHitAbove += alertEvent.HighTemp;
            tempMonitor.OnTempHitAbove += setTemp.SetTempBackDefault;
            tempMonitor.OnTempHitBelow += alertEvent.LowTemp;

            Console.WriteLine("Your input...");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                tempMonitor.Temperature = value;
            }


            Console.ReadKey();
        }
    }
}
