namespace StrucsPractice
{
    internal class Program
    {
        public enum Nums
        {
            One = 1,
            Two = 2,
            Three = 3
        }

        public struct Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double GetDistance(Point other)
            {
                double dx = other.X - X;
                double dy = other.Y - Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            public void Display()
            {
                Console.WriteLine($"{X} | {Y}");
            }
        }

        static void Main(string[] args)
        {
            Point p1 = new(10, 30);
            p1.Display();

            Point p2 = new(70, 30);
            p2.Display();

            double distance = p1.GetDistance(p2);

            Console.WriteLine($"Distance: {distance:F4}");

            var num = (int)Nums.One;
            Console.WriteLine(num);

            Console.ReadKey();
        }
    }
}
