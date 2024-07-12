namespace FibonacciAverageApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the depth for the Fibonacci series: ");
        int depth = int.Parse(Console.ReadLine());

        FibonacciCalculator calculator = new FibonacciCalculator();
        int[] fibonacciSeries = calculator.GenerateSeries(depth);

        AverageCalculator avgCalculator = new AverageCalculator();
        double average = avgCalculator.CalculateAverage(fibonacciSeries);

        Console.WriteLine($"The average of the Fibonacci series is: {average}");

    }
}
