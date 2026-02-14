//int[] arr = { 1, 2, 3 };
//string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
//int sum = 0;

//foreach (string day in days)
//{
//    Console.WriteLine(day);
//}

//Console.WriteLine(days.Length);

//Console.WriteLine(arr[2]);
//Console.WriteLine(arr.Sum());

//Console.WriteLine(days[0]);

//foreach (int num in arr)
//{

//    sum += num;
//}

//Console.WriteLine(sum);


//for (int i = 0; i < arr.Length; i++)
//{
//    sum += arr[i];
//}

//Console.WriteLine(sum);

//int[,] array2D = new int[3, 3];
//int[,,] array3D = new int[3, 3, 3];
//int[,] array2DI = { {1, 2}, {3, 4} };



//Console.WriteLine(array2DI[1, 0]);



//int[][] jaggedArray = new int[3][];

//jaggedArray[0] = new int[] { 1, 2, 3 };
//jaggedArray[1] = new int[] { 4, 5 };
//jaggedArray[2] = new int[] { 6, 7, 8, 9 };

//// Printing elements
//for (int i = 0; i < jaggedArray.Length; i++)
//{
//    Console.Write("Row " + i + ": ");
//    for (int j = 0; j < jaggedArray[i].Length; j++)
//    {
//        Console.Write(jaggedArray[i][j] + " ");
//    }
//    Console.WriteLine();
//}


//Create a simple C# program that initializes a 3x3 two-dimensional array with integers, calculates the sum of each row, and prints the sums to the console.

//The program should:

//    Declare and initialize a 3x3 two-dimensional array with the following values:

//        1 2 3
//        4 5 6
//        7 8 9

//    Calculate the sum of each row in the array.

//    Print the sum of each row to the console.

//Alert!

//The result of execution for the default string should be:

//    6
//    15
//    24



string[,] array2D = {{"1", "2", "3"}, {"4", "5", "6"}, {"7", "8", "9"}};

int rows = array2D.GetLength(0);
int columns = array2D.GetLength(1);

for (int i = 0; i < rows; i++)
{
	int rowSum = 0;
	for (int j = 0; j < columns; j++)
	{
		rowSum += int.Parse(array2D[i, j]);
	}
    Console.WriteLine($"Sum of row: {i}: {rowSum}");
}

