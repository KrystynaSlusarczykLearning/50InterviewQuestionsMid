using System.Diagnostics;

const int setSize = 1000000000;
var checkedResult = MeasureChecked(setSize);
Console.WriteLine($"Checked test for {setSize} took {checkedResult} ms");

GC.Collect();
var uncheckedResult = MeasureUnchecked(setSize);
Console.WriteLine($"Unchecked test for {setSize} took {uncheckedResult} ms");
Console.WriteLine($"Checked took {(((double)checkedResult / (double)uncheckedResult) - 1d) * 100}% longer");

GC.Collect();
var uncheckedWithManualCheckResult = MeasureUncheckedWithManualCheck(setSize);
Console.WriteLine($"Unchecked with manual check test for {setSize} took {uncheckedWithManualCheckResult} ms");

Console.ReadLine();

static long MeasureChecked(int setSize)
{
    var stopwatch = Stopwatch.StartNew();

    int a = 1;
    int b = 2;

    checked
    {
        for (int i = 0; i < setSize; i++)
        {
            a = i + b + a;
            a = 1;
        }
    }

    stopwatch.Stop();
    return stopwatch.ElapsedMilliseconds;
}

static long MeasureUnchecked(int setSize)
{
    var stopwatch = Stopwatch.StartNew();

    int a = 1;
    int b = 2;

    unchecked
    {
        for (int i = 0; i < setSize; i++)
        {
            a = i + b + a;
            a = 1;
        }
    }

    stopwatch.Stop();
    return stopwatch.ElapsedMilliseconds;
}

static long MeasureUncheckedWithManualCheck(int setSize)
{
    var stopwatch = Stopwatch.StartNew();

    int a = 1;
    int b = 2;

    unchecked
    {
        for (int i = 0; i < setSize; i++)
        {
            if (((long)i + (long)b + (long)a) > int.MaxValue)
            {
                throw new InvalidOperationException(
                    "The operation will result in int overflow");
            }
            a = i + b + a;
            a = 1;
        }
    }

    stopwatch.Stop();
    return stopwatch.ElapsedMilliseconds;
}


