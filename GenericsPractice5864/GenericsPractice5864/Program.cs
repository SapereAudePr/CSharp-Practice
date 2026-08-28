namespace GenericsPractice5864
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var delivery = Delivery<Box<Create<string>>>.Success(
                new Box<Create<string>>(
                    new Create<string>(
                        new List<string> {
                            "test", "test2" })));


            Console.WriteLine(delivery.Arrived);
            Console.WriteLine(delivery.Package.Contents.Counts);

            Console.WriteLine(string.Join(Environment.NewLine,
                delivery.Package.Contents.Items));


            Console.ReadLine();
        }
    }
}
