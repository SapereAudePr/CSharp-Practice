namespace PasswordHashingPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hasher = new PasswordHasher();
            var hashedPw =  hasher.Hash("12345678");
            Console.WriteLine(hashedPw);


            Console.ReadLine();
        }
    }
}
