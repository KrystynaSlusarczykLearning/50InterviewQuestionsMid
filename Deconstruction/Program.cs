//we can deconstruct ValueTuples
var numbers = new[] { 1, 4, 2, 6, 11, 5, 83, 1, 2 };
int count;
double average;
(var sum, count, average) = AnalyzeNumbers(numbers);

if (count == 0)
{
    Console.WriteLine("The collection is empty");
}
else
{
    Console.WriteLine($"The collection has {count}" +
      $" elements, with total sum of {sum} " +
      $"and average of {average}");
}
var numbersAverageSize = average > 100 ?
    "large" : 
    "small";

Console.WriteLine(
    $"The numbers in the collection are " +
    $"relatively {numbersAverageSize}");

//we can also deconstruct tuples
var tuple = new Tuple<string, bool, int>("abc", true, 10);
var (text, boolean, number) = tuple;

//and positional records:
var bob = new Person("Bob", 1950, "USA");
var (name, _, country) = bob;

//classes, by default, can't be deconstructed
var hannibal = new PetNoDeconstruct("Hannibal", PetType.Fish, 1.1f);
//var (petName, type, _) = hannibal;

//but they can be if we implement Deconstruct method
var taiga = new Pet("Taiga", PetType.Dog, 30f);
var (petName, petType, weight) = taiga;

var date = new DateTime(2020, 1, 8);
var (year, month, day) = date;

Console.ReadKey();

(int sum, int count, double average) AnalyzeNumbers(
    IEnumerable<int> numbers)
{
    var sum = 0;
    var count = 0;
    foreach (var number in numbers)
    {
        sum += number;
        count++;
    }
    var average = (double)sum / count;
    return (sum, count, average);
}

class Pet
{
    public string Name { get; }
    public PetType PetType { get; }
    public float Weight { get; }

    public Pet(string name, PetType petType, float weight)
    {
        Name = name;
        PetType = petType;
        Weight = weight;
    }

    public void Deconstruct(
        out string name, 
        out PetType petType, 
        out float weight)
    {
        name = Name;
        petType = PetType;
        weight = Weight;
    }
}

class PetNoDeconstruct
{
    public string Name { get; }
    public PetType PetType { get; }
    public float Weight { get; }

    public PetNoDeconstruct(string name, PetType petType, float weight)
    {
        Name = name;
        PetType = petType;
        Weight = weight;
    }
}

public enum PetType { Cat, Dog, Fish }

record Person(string Name, int YearOfBirth, string Country);

static class DateTimeExtensions
{
    public static void Deconstruct(
        this DateTime date, 
        out int year, 
        out int month,
        out int day)
    {
        year = date.Year;
        month = date.Month;
        day = date.Day;
    }
}

