using System.Collections;

//we can have different types in single ArrayList
var arrayList = new ArrayList() {
    1, "hello", new DateTime(2022, 1, 1) };

var numbers = new ArrayList() { 1, 2, 3 };
var strings = new ArrayList() { "a", "b", "c" };

Console.ReadKey();

int Sum(ArrayList hopefullyNumbers)
{
    int result = 0;
    foreach (var number in hopefullyNumbers)
    {
        try
        {
            //we are not sure if those objects are ints
            //so we try to cast, but in try-catch in case
            result += (int)number;
        }
        catch (InvalidCastException)
        {
            Console.WriteLine($"{number} is not really an int!");
            throw;
        }
    }
    return result;
}