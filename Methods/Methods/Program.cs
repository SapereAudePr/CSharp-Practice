//int Add(int val1, int val2) => val1 + val2;

//Console.WriteLine("Enter the first number");
//if (int.TryParse(Console.ReadLine(), out int num1))
//Console.WriteLine("Enter the second number");
//if (int.TryParse(Console.ReadLine(), out int num2))


//Console.WriteLine($"Result: {Add(num1, num2)}");

using System.Threading.Channels;

void Add()
{
    int num1 = 0;
    int num2 = 0;
    int result = 0;
    Console.WriteLine("Enter the first number");
    while (!int.TryParse(Console.ReadLine(), out num1))
    {
        Console.WriteLine("Enter a number");
    }
    Console.WriteLine("Enter the second number");
    while (!int.TryParse(Console.ReadLine(), out num2))
    {
        Console.WriteLine("Enter a number");
    }
    Console.WriteLine($"Result is: {num1 + num2}");
}

Add();