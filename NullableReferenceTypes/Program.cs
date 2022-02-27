//the compiler gives us a warning,
//because we assign null to non-nullable type
using NUnit.Framework;

string nonNullableTextBeingNull = null;

string? nullableText = null;
string nonNullableText = "hello!";

Console.WriteLine(
    "Nullable text length" + GetLength(nullableText));
Console.WriteLine(
    "Non-Nullable text length" + GetLength(nonNullableText));

var array = new string[10];
Console.WriteLine(array[0].Length);

//the nullable reference types feature can be enabled/disabled per project
//but we can also enable/disable it manually per file or a code fragment
#nullable disable
string text = null;
Console.WriteLine(text);
#nullable enable

Console.ReadKey();

int GetLength(string? nullableText)
{
    if(nullableText == null)
    {
        return 0;
    }
    return nullableText.Length;
}

string FormatHousesData(IEnumerable<House> houses)
{
    return string.Join("\n",
        houses.Select(house =>
        $"Owner is {house.OwnerName}, " +
        $"address is {house.Address.Number} " +
        $"{house.Address.Street}"));
}

bool ValidateAddress(House house)
{
    if(house == null)
    {
        Console.WriteLine("house is null");
        return false;
    }
    if(house.Address == null)
    {
        Console.WriteLine("address is null");
        return false;
    }
    if(house.Address.Number == null)
    {
        Console.WriteLine("address/number is null");
        return false;
    }
    if(house.Address.Street == null)
    {
        Console.WriteLine("address/street is null");
        return false;
    }
    if(house.Address.Number.Length == 0)
    {
        Console.WriteLine("address/number is empty");
        return false;
    }
    if (house.Address.Street.Length == 0)
    {
        Console.WriteLine("address/street is empty");
        return false;
    }
    return true;
}

class House
{
    public string OwnerName { get; }
    public Address Address { get; }

    public House(string ownerName, Address address)
    {
        if(ownerName == null)
        {
            throw new ArgumentNullException(nameof(ownerName));
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address));
        }
        OwnerName = ownerName;
        Address = address;  
    }
}

class Address
{
    public string Street { get; }
    public string Number { get; }

    public Address(string street, string number)
    {
        Street = street;
        Number = number;
    }
}

class Calculator
{
    public int Add(int a, int b) => a + b;
}

[TestFixture]
public class CalculatorTests
{
    private Calculator? _cut;

    [SetUp]
    public void SetUp()
    {
        _cut = new Calculator();
    }

    [Test]
    public void Add5And10_ShallGive15()
    {
        Assert.AreEqual(15, _cut!.Add(10, 5));
    }
}

[TestFixture]
public class HouseTests
{
    [Test]
    public void NullOwnerName_ShallThrowException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new House(null!, new Address("Maple Street", "12B")));
    }
}

