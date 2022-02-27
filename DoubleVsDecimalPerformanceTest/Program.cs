using System.Diagnostics;

int iterations = 30000000;
var resultForDouble = DoubleTest(iterations);
var resultForDecimal = DecimalTest(iterations);

Console.WriteLine($"Calculation of {iterations} elements for " +
    $"double took { resultForDouble } ticks while for " +
    $"decimal it took {resultForDecimal}");
Console.WriteLine($"Decimal took {(((double)resultForDecimal / (double)resultForDouble) - 1d) * 100}% longer");

Console.ReadKey();


long DoubleTest(int iterations)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    double z = 0;
    for (int i = 0; i < iterations; i++)
    {
        double x = i;
        double y = x * i;
        z += y;
    }
    stopwatch.Stop();
    return stopwatch.ElapsedTicks;
}

long DecimalTest(int iterations)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    decimal z = 0;
    for (int i = 0; i < iterations; i++)
    {
        decimal x = i;
        decimal y = x * i;
        z += y;
    }
    stopwatch.Stop();
    return stopwatch.ElapsedTicks;
}