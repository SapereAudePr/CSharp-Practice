using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    class ChatApp
    {
        private readonly IWriter _writer;

        public void Terminal()
        {
            Console.WriteLine("Welcome! What would you like to do?");

            Censor censor = new Censor();

            string? userInput = Console.ReadLine();

            censor.CensorText(userInput);
            

            
        }
    }

    public interface IPaymentProcessor
    {
        public void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Credit card payment: {amount}");
        }
    }

    public class PaypalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Paypal payment: {amount}");
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void ProcessOrderPayment(decimal amount)
        {
            _paymentProcessor.ProcessPayment(amount);
        }
    }
}
