using static PaymentServicePractice.PaymentService;

namespace PaymentServicePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentService creditPayment = new CreditCard();
            Pay creditCard = new Pay(creditPayment);
            creditCard.Payment(120.00m);

            IPaymentService debitPayment = new DebitCard();
            Pay debitCard = new(debitPayment);
            debitCard.Payment(180.00m);

            Console.ReadKey();
        }
    }
}
