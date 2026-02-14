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
            public bool ProcessPayment(Customer customer, decimal amount);
        }

        public class CreditCard : IPaymentService
        {
            public bool ProcessPayment(Customer customer, decimal amount)
            {
                if (customer.Balance >= amount)
                {
                    customer.Balance -= amount;
                    Console.WriteLine($"Credit card payment {amount}$: Name: {customer.Name} | ID: {customer.Id}");
                    Console.WriteLine($"Balance after purchase: {customer.Balance}$");
                    return true;
                }
                else
                {
                    Console.WriteLine("Purchase failed: not enough balance!");
                    return false;
                }
            }
        }

        public class DebitCard : IPaymentService
        {
            public bool ProcessPayment(Customer customer, decimal amount)
            {
                if (customer.Balance >= amount)
                {
                    customer.Balance -= amount;
                    Console.WriteLine($"Debit card payment {amount}$: Name: {customer.Name} | ID: {customer.Id}");
                    Console.WriteLine($"Balance after purchase: {customer.Balance}$");
                    return true;
                }
                else
                {
                    Console.WriteLine("Purchase failed: not enough balance!");
                    return false;
                }
            }
        }

        public class Pay
        {
            private readonly IPaymentService _paymentService;

            public Pay(IPaymentService paymentService)
            {
                _paymentService = paymentService;
            }

            public bool Payment(Customer customer, decimal amount)
            {
                return _paymentService.ProcessPayment(customer, amount);
            }
        }
    }
}
