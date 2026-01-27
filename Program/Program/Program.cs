int age = 0;
string answer = "";
string name = "";
bool hasSpecialState = false;

Console.WriteLine("Hello!");
Console.WriteLine("Please enter \"start\" to start the conversation.");
answer = Console.ReadLine();

if (answer == "start")
{
    Console.WriteLine("What's your name?");
    name = Console.ReadLine();

    if (name != "Raven")
    {
        Console.WriteLine("Would you like to sign-up? \"y\" or \"n\\");
        answer = Console.ReadLine();
        if (answer == "y")
        {
            Console.WriteLine("Please enter your name");
            answer = Console.ReadLine();
            Console.WriteLine($"Welcome {answer}");
        }
        else
        {
            Console.WriteLine("Please submit your age");

            age = int.Parse(Console.ReadLine());

            if (age >= 18)
            {
                Console.WriteLine("You may enter the building!");
            }
            else
            {
                Console.WriteLine("Are your parents with you? \"y\" or \"n\\");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("You may enter the building with your parents");
                    Console.WriteLine("Access Granted!");
                }
                else
                {
                    Console.WriteLine("You can't enter the building without your parents");
                }
            }
        }

        Console.WriteLine("Would you like to take a surver? \"y\" or \"n\\?");
        answer = Console.ReadLine();
        if (answer == "y")
        {
            Console.WriteLine("Tell us what you think.");
            answer = Console.ReadLine();
            Console.WriteLine($"Thank you for your thoughts, your message is sent! \n Your message: {answer}");
            Console.WriteLine("Hit enter to quit");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine($"Welcome {name}!");
        Console.WriteLine("Hit enter to quit");
        Console.ReadKey();
    }
}
else
{
    Console.WriteLine("Type \"start\" next time!");
    Console.WriteLine("Hit enter to quit");
    Console.ReadKey();
}