Random random = new Random();

int minNum = 1;
int maxNum = 4;
int guessCount = 0;
int coins = 3;
bool isLooping = true;
bool hasBoughtCoins = false;

Console.WriteLine($"Welcome to number guess game! You have {coins} coins currently!");
Console.WriteLine($"Guess the number between {minNum} - {maxNum}");

while (isLooping)
{
    if (coins >= 1)
    {
        int rndNum = random.Next(minNum, maxNum + 1);
        Console.WriteLine("Take a Guess!");
        string userInput = Console.ReadLine().Trim();
        bool tryParse = int.TryParse(userInput, out int parsedInput);
        if (parsedInput > maxNum)
        {
            Console.WriteLine("Number can't be greater than the max number!");
            continue;
        }
        else
        {
            if (tryParse)
            {
                if (parsedInput == rndNum)
                {
                    coins++;
                    guessCount++;
                    Console.WriteLine($"The number was: {rndNum}");
                    Console.WriteLine($"Congratz you guessed correctly! Your total coins: {coins}");
                    continue;
                }
                else
                {
                    coins--;
                    Console.WriteLine($"The number was: {rndNum}");
                    Console.WriteLine($"Your guess was wrong! Your total coins: {coins}");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Write a number!");
                continue;
            }
        }
    }
    else
    {
        if (guessCount > 1 && hasBoughtCoins == false)
        {
            Console.WriteLine($"Game Over! You have guessed the number {guessCount} times. Do you want to buy {guessCount} coins to try again?");
            Console.WriteLine($"\"y\" or \"n\"");
            string userAnswer = Console.ReadLine().Trim().ToLower();
            if (userAnswer == "y")
            {
                coins += guessCount;
                hasBoughtCoins = true;
                Console.WriteLine($"Continue! Your total coins: {coins}");
                continue;
            }
            else
            {
                Console.WriteLine("GoodBye!");
                isLooping = false;
                break;
            }
        }
        else
        {
            Console.WriteLine($"Your total coins: {coins} and you did {guessCount} correct guesses. So, Game Over! Try Again!");
            isLooping = false;
            break;
        }
    }
}

Console.WriteLine($"You guessed {guessCount} times!");