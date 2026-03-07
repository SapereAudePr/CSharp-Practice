namespace InterfaceSegregationPrinciple
{
    public interface IOnOff
    {
        void StartDevice();
        void ShutDownDevice();
    }

    public interface IRecordable
    {
        void RecordVideo();
    }

    public interface IPlayable
    {
        void PlayMedia();
    }

    public class SmartLight : IOnOff
    {
        public void StartDevice()
        {
            Console.WriteLine("Starting device...");
        }

        public void ShutDownDevice()
        {
            Console.WriteLine("Shutting the device down...");
        }
    }

    public class SecurityCamera : IOnOff, IRecordable
    {
        public void StartDevice()
        {
            Console.WriteLine("Starting device...");
        }
        public void ShutDownDevice()
        {
            Console.WriteLine("Shutting down the device...");
        }
        public void RecordVideo()
        {
            Console.WriteLine("Starting record...");
        }
    }

    public class SmartSpeaker : IOnOff, IPlayable
    {
        public void StartDevice()
        {
            Console.WriteLine("Starting device...");
        }
        public void ShutDownDevice()
        {
            Console.WriteLine("Shutting down the device...");
        }
        public void PlayMedia()
        {
            Console.WriteLine("Playing media...");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IOnOff smartLight = new SmartLight();
            smartLight.StartDevice();

            SecurityCamera securityCamera = new();
            securityCamera.StartDevice();
            securityCamera.RecordVideo();
            securityCamera.ShutDownDevice();

            SmartSpeaker smartSpeaker = new();
            smartSpeaker.StartDevice();
            smartSpeaker.PlayMedia();
            smartSpeaker.ShutDownDevice();
        }
    }
}
