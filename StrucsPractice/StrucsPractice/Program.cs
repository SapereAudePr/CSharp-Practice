namespace StrucsPractice
{
    internal class Program
    {
        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
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

            Point p2;
            p2.X = 70;
            p2.Y = 30;
            p2.Display();

            Point p3 = p2;
            p3.Y = 80;
            p3.Display();

            Console.ReadKey();
        }
    }
}
