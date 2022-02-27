using System.Diagnostics;
using System.Text;

int iterations = 100000;
var (resultForString, text) = StringTest(iterations);

var (resultForStringBuilder, textBuiltByStringBuilder)  = StringBuilderTest(iterations);

Console.WriteLine($"Concatenation of {iterations} strings for " +
    $"string took { resultForString } ticks while for " +
    $"StringBuilder it took {resultForStringBuilder}");
Console.WriteLine($"string took {(((double)resultForString / (double)resultForStringBuilder) - 1d) * 100}% longer");
Console.WriteLine("Are results equal? " + (text == textBuiltByStringBuilder));
Console.ReadKey();

(long, string) StringTest(int iterations)
{
    Stopwatch stopWatch = Stopwatch.StartNew();
    string a = "";
    for (int i = 0; i < iterations; i++)
    {
        a += "a";
    }
    stopWatch.Stop();
    return (stopWatch.ElapsedTicks, a);
}

(long, string) StringBuilderTest(int iterations)
{
    Stopwatch stopWatch = Stopwatch.StartNew();
    StringBuilder a = new StringBuilder();
    for (int i = 0; i < iterations; i++)
    {
        a.Append("a");
    }
    stopWatch.Stop();
    return (stopWatch.ElapsedTicks, a.ToString());
}