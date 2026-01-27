using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        double[] temperatures = { 22, 23, 24, 25 };

        public void PrintAverage(double[] temperatures)
        {
            Console.WriteLine($"The average temperature is: {CalculateAverage(temperatures)}");
        }

        public double CalculateAverage(double[] temperatures)
        {
            double average = temperatures.Sum() / temperatures.Length;
            return average;
        } 
    }
}
