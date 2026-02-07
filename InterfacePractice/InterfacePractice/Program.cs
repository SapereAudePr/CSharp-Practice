
namespace InterfacePractice
{
    public interface IWriter
    {
        void CensorText(string text);
    }

    public class Censor : IWriter
    {
        string[] badWords =
        [
            "fuck",
            "shit",
        ];

        public void CensorText(string text)
        {
            foreach (string word in badWords)
            {
                text = text.Replace(word, "[CENSORED]");
            }

            DisplayMessage(text);
        }

        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ChatApp app = new();
            app.Terminal();

            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            PaymentService cCpaymentService = new(creditCardProcessor);
            cCpaymentService.ProcessOrderPayment(200.00m);

            IPaymentProcessor paypalProcessor = new PaypalProcessor();
            PaymentService pPpaymentService = new PaymentService(paypalProcessor);
            pPpaymentService.ProcessOrderPayment(100.00m);

            Console.ReadKey();
        }
    }
}
