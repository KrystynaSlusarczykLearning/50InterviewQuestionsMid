var numbers = new[] { 1, 3, 6, 1, 12 };

Console.WriteLine(
    "IsAnyLargerThan10? " + IsAny(numbers, IsLargerThan10));

Console.WriteLine(
    "IsAnyEven? " + IsAny(numbers, IsEven));

//the same result, but with lambda expressions
Console.WriteLine(
    "IsAnyLargerThan10? " + IsAny(numbers, n => n > 10));

Console.WriteLine(
    "IsAnyEven? " + IsAny(numbers, n => n % 2 == 0));


//this function takes int, DateTime and string and resturns a bool
Func<int, DateTime, string, decimal> someFunc;

//this function takes two strings and a bool and is void

Action<string, string, bool> someAction;

Console.ReadKey();

bool IsAny(
    IEnumerable<int> numbers,
    Func<int, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}

bool IsAnyLargerThan10(IEnumerable<int> numbers)
{
    foreach (var number in numbers)
    {
        if (number > 10)
        {
            return true;
        }
    }
    return false;
}

bool IsAnyEven(IEnumerable<int> numbers)
{
    foreach (var number in numbers)
    {
        if (number % 2 == 0)
        {
            return true;
        }
    }
    return false;
}

bool IsLargerThan10(int number)
{
    return number > 10;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}