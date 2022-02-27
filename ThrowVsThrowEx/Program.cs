//MethodA();

try
{
    MethodThrow();
}
catch (Exception ex)
{
    Console.WriteLine("Throw");
    Console.WriteLine(
        "Exception caught, logging some" +
        " information. Stack trace:\n");
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine();
}

try
{
    MethodThrowEx();
}
catch (Exception ex)
{
    Console.WriteLine("Throw ex");
    Console.WriteLine("Exception caught, logging some" +
        " information. Stack trace:\n");
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine();
}

Console.ReadKey();

void MethodThrow()
{
    try
    {
        var collection = Enumerable.Empty<int>();
        var first = collection.First();
    }
    catch (Exception ex)
    {
        throw;
    }
}

void MethodThrowEx()
{
    try
    {
        var collection = Enumerable.Empty<int>();
        var first = collection.First();
    }
    catch (Exception ex)
    {
        throw ex;
    }
}

static void MethodA()
{
    Console.WriteLine("In method A");
    MethodB();
}

static void MethodB()
{
    Console.WriteLine("In method B");
    MethodC();
}

static void MethodC()
{
    Console.WriteLine("In method C");
    Console.WriteLine(Environment.StackTrace);
    Console.WriteLine();
}

decimal Divide(decimal a, decimal b)
{
    if(b == 0)
    {
        throw new ArgumentException("B can't be zero!");
    }
    return a / b;
}

