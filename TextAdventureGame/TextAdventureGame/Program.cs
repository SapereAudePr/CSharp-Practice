using System.ComponentModel.Design;

Random random = new Random();
string className = "";

int maxPlayerHp = 0;
int currentPlayerHp = 0;
int playerAttack = 0;

int goldAmount = 100;

Console.WriteLine("Welcome to the game. Type anything to start.");
Console.ReadLine();

Console.WriteLine("What's your name?");
string userName = Console.ReadLine().Trim();

Console.WriteLine($"Hi, {userName}! What class do you want to play? Type one of the number to select: 1-(Warrior) | 2-(Mage) | 3-(Tank)");
string userAnswer = Console.ReadLine().Trim();

switch (userAnswer)
{
    case "1":
        className = "Warrior";
        maxPlayerHp = 200;
        currentPlayerHp = maxPlayerHp;
        playerAttack = 30;
        break;

    case "2":
        className = "Mage";
        maxPlayerHp = 100;
        currentPlayerHp = maxPlayerHp;
        playerAttack = 60;
        break;

    case "3":
        className = "Tank";
        maxPlayerHp = 300;
        currentPlayerHp = maxPlayerHp;
        playerAttack = 15;
        break;

    default:
        Console.WriteLine("Error! Type a valid class number.");
        break;
}

Console.WriteLine($"{userName} your class is: {className}. Your initial attack is: {playerAttack} and your health is: {currentPlayerHp}");

Console.WriteLine("You're walking in a village and a guy wants to talk to you. Do you want to talk? Y or N");
userAnswer = Console.ReadLine().Trim().ToUpper();

if (userAnswer == "Y")
{
    Console.WriteLine("The guy tells you: My daugther has been missing for hours, I believe she went to the Dark Forest.\nCan you find and bring my daughter please? Y or N");
    userAnswer = Console.ReadLine().Trim().ToUpper();
    if (userAnswer == "Y")
    {
        Console.WriteLine("You started walking to the Dark Forest and you encountered a merchant. Do you want to check what's he selling? Y or N");
        userAnswer = Console.ReadLine().Trim().ToUpper();
        if (userAnswer == "Y")
        {
            VisitMerchant(ref currentPlayerHp, ref maxPlayerHp, ref playerAttack, ref goldAmount);
        }
        else if (userAnswer == "N")
        {
            Console.WriteLine($"You didn't buy anything. You're nearly at the Dark Forest!");
        }
    }
    else if (userAnswer == "N")
    {
        Console.WriteLine("You wander around in the village and you see someone suspicious");
        Thread.Sleep(2000);
        Console.WriteLine("...");
        Thread.Sleep(2000);
        Console.WriteLine("The guy pull his sword and call his friends to raid that village!\nDo you want to hide or fight with them? \"attack\" or \"hide\"");
        userAnswer = Console.ReadLine().Trim().ToLower();
        if (userAnswer == "attack")
        {
            Console.WriteLine("You decided to fight with them!");
            Thread.Sleep(2000);
            Console.WriteLine("...");
            Thread.Sleep(2000);
            bool isSuccess = DiceEngine(random);

            if (isSuccess)
            {
                int defeatedNum = random.Next(1, 10);
                Console.WriteLine($"You've won! You defeated {defeatedNum} soldiers and the others ran!");
                if (defeatedNum >= 5)
                {
                    maxPlayerHp += 40;
                    currentPlayerHp -= 20;
                    goldAmount += 50;
                    Console.WriteLine($"You took 50 damage but you've gained 50 gold and looted one Old Armor. Your current health:\n{currentPlayerHp}/{maxPlayerHp}\ntotal gold: {goldAmount}");
                }
                else
                {
                    currentPlayerHp -= 20;
                    goldAmount += 30;
                    Console.WriteLine($"You took 40 damage but you've gained 50 gold and looted few gold coins. Your current health: {currentPlayerHp} and your gold is: {goldAmount}");
                }
            }
            else
            {
                currentPlayerHp -= 60;
                Console.WriteLine($"You've lost the fight. Your current health is: {currentPlayerHp}/{maxPlayerHp}");
            }
        }
        else if (userAnswer == "hide")
        {
            Console.WriteLine("You decided to hide!");
        }
    }
}
else if (userAnswer == "N")
{
    Console.WriteLine("You didn't talk to that guy. What he was going to say? I guess you'll never know...");
}

static void VisitMerchant(ref int currentHp, ref int maxHp, ref int attack, ref int gold)
{
    int potionCost = 100;
    int potionHeal = 50;

    Console.WriteLine($"Merchant: Welcome!\n1-Shiny Hat(80 Gold)\n2-Might Sword (120 Gold)\n3- Health Potion (100 Gold - 50 Hp)\n4- Leave");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        if (gold >= 80)
        {
            maxHp += 40;
            gold -= 80;
            Console.WriteLine($"You've bought the Shiny Hat. Your health increased to {currentHp}");
        }
        else
        {
            Console.WriteLine($"You don't have enough gold 80/{gold}");
        }
    }
    else if (choice == "2")
    {
        if (gold >= 120)
        {
            attack += 20;
            gold -= 120;
            Console.WriteLine($"You've bought the Mighty Sword. Your attack increased to {attack}");
        }
        else
        {
            Console.WriteLine($"You don't have enough gold 120/{gold}");
        }
    }
    else if (choice == "3")
    {
        if (gold >= 100)
        {
            currentHp = Math.Min(currentHp + potionHeal, maxHp);
            gold -= potionCost;
            Console.WriteLine($"You drank the potion. Your health: {currentHp}/{maxHp}");
        }
        else
        {
            Console.WriteLine($"You don't have enough gold to buy it {gold}/{potionCost}");
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine($"You decided to buy nothing. Your total gold amount is {gold}");
    }
}
 
static bool DiceEngine(Random random)
{
    int dice = random.Next(1, 21);
    if (dice >= 10)
    {
        return true;
    }
    else
    {
        return false;
    }
}


Console.ReadKey();