Console.WriteLine("Welcome to the Conditional Based Calculator");

Console.WriteLine("Enter your first number");

string firstNum = Console.ReadLine().Trim();

bool tryParse1 = int.TryParse(firstNum, out int parsedNum1);

Console.WriteLine("Enter your second number");

string secondNum = Console.ReadLine().Trim();
bool tryParse2 = int.TryParse(secondNum, out int parsedNum2);

Console.WriteLine("Enter one of the operators: + - / *");

string operatorInput = Console.ReadLine().Trim();

if (tryParse1 && tryParse2 && parsedNum1 > 0 && parsedNum2 > 0)
{
    if (operatorInput == "+")
    {
        Console.WriteLine(parsedNum1 + parsedNum2);
    }
    else if (operatorInput == "-")
    {
        Console.WriteLine(parsedNum1 - parsedNum2);
    }
    else if (operatorInput == "/")
    {
        Console.WriteLine(parsedNum1 / parsedNum2);
    }
    else if (operatorInput == "*")
    {
        Console.WriteLine(parsedNum1 * parsedNum2);
    }
}
else
{
    Console.WriteLine("You didn't enter numbers or the number is not greater than 0");
}