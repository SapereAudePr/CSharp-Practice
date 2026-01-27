int minNum = 1;
int maxNum = 6;
Random random = new Random();


int lives = 3;
int guessCount = 0;

Console.WriteLine($"Guess the number between {minNum} - {maxNum}");
Console.WriteLine($"You have {lives} amount of chance!");

while (lives > 0)
{
    int rndNum = random.Next(minNum, maxNum + 1);
    Console.WriteLine("Guess the number");
    string usrInpt = Console.ReadLine().Trim();
    bool parseToInt = int.TryParse(usrInpt, out int parsedStr);
    if (parseToInt)
    {
        if (parsedStr <= maxNum)
        {
            if (parsedStr == rndNum)
            {
                Console.WriteLine("Congratz you guessed the number!");
                lives++;
                guessCount++;
                Console.WriteLine($"You have gained one extra coin! Current amount: {lives}");
            }
            else
            {
                Console.WriteLine($"That was wrong, try again!The number was: {rndNum}");
                lives--;
                Console.WriteLine($"You've lost one coin! Current amount: {lives}");
            }
        }
        else
        {
            Console.WriteLine($"Entered number can't be greater than {maxNum}!");
        }
    }
    else
    {
        Console.WriteLine("Enter a number next time");
    }
    if (lives == 0)
    {
        Console.WriteLine("You don't have any more coin. Game Over!");
        Console.WriteLine($"You've guessed: {guessCount} times!");
    }
}