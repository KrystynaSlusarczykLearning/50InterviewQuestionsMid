Console.WriteLine("Double:");
Console.WriteLine("0.3d == (0.1d + 0.2d): " + (0.3d == (0.1d + 0.2d)));

Console.WriteLine("\nDecimal:");
Console.WriteLine("0.3m == (0.1m + 0.2m): " + (0.3m == (0.1m + 0.2m)));

Console.WriteLine("\nAreEqual(1d, 1.0000000001d, 0.000000001d)");
Console.WriteLine(AreEqual(1d, 1.0000000001d, 0.000000001d));

Console.WriteLine("\nAreEqual(1d, 1.0000000001d, 0.0000000001d)");
Console.WriteLine(AreEqual(1d, 1.0000000001d, 0.0000000001d));
Console.ReadKey();

//when checking doubles for equality, we should check if 
//the difference between them is smaller than some tolerance
bool AreEqual(double a, double b, double tolerance)
{
    return Math.Abs(a - b) < tolerance;
}
