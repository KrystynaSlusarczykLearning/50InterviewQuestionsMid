#define MY_SYMBOL
#if MY_SYMBOL
Console.WriteLine("MY_SYMBOL is defined");
#endif

#if (DEBUG && NET5_0_OR_GREATER)
Console.WriteLine("We are in Debug mode in .NET 5 or greater.");
#elif (DEBUG && !NET5_0_OR_GREATER)
    Console.WriteLine("We are in Debug mode in .NET older than 5.");
#elif (RELEASE && NET6_0_IOS)
    Console.WriteLine("We are in Release mode and we target iOS.");
#endif

#region someCollapsibleCode
Console.WriteLine("Not much going on here");
Console.WriteLine("...");
Console.WriteLine("...");
#endregion

#warning this method is deprecated, use NewMethod instead
OldMethod();

try
{
    //some code that can throw
}
catch (Exception ex)
{
#pragma warning disable CA2200
    throw ex;
#pragma warning restore CA2200
}

#nullable disable
string nullable = null;
#nullable enable
Console.WriteLine(nullable);

Console.ReadKey();

void OldMethod()
{
    Console.WriteLine(
        "This method shouldn't be used, use NewMethod instead");
}

void NewMethod()
{
    Console.WriteLine("Brand new method");
}
