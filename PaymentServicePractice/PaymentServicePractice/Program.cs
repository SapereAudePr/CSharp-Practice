using static PaymentServicePractice.PaymentService;

namespace PaymentServicePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerDb customerDb = new();
            ShopDb shopDb = new(customerDb);
            Terminal _terminal = new(customerDb, shopDb);
            _terminal.StartTerminal();

            Console.ReadKey();
        }
    }
}
