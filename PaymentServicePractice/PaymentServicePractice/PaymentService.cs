using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePractice
{
    class PaymentService
    {
        public interface IPaymentService
        {
            public void ProcessPayment(decimal amount);
        }

        public class CreditCard : IPaymentService
        {
            public void ProcessPayment(decimal amount)
            {
                Console.WriteLine($"Credit card payment {amount}");
            }
        }

        public class DebitCard : IPaymentService
        {
            public void ProcessPayment(decimal amount)
            {
                Console.WriteLine($"Debit card payment {amount}");
            }
        }

        public class Pay
        {
            private readonly IPaymentService _paymentService;

            public Pay(IPaymentService paymentService)
            {
                _paymentService = paymentService;
            }

            public void Payment(decimal amount)
            {
                _paymentService.ProcessPayment(amount);
            }
        }
    }
}
