//using System.Diagnostics.Metrics;

//int currentScore = 0;
//int sum = 0;
//int counter = 0;

//Console.WriteLine("Enter -1 to quit and get the avarage.");

//do
//{
//    Console.WriteLine("Enter the score.");
//    currentScore = int.Parse(Console.ReadLine());
//    if (currentScore != -1)
//    {
//        sum = sum + currentScore;
//        counter++;
//    }
//} while (currentScore != -1);

//int avarage = sum / counter;

//Console.WriteLine($"The avarage of the scores is: {avarage}");

//Console.ReadKey();

for (int i = 0; i < 5; i++)
{
    if (i == 3)
    {

        continue;
        //break;
    }

    Console.WriteLine(i);
}