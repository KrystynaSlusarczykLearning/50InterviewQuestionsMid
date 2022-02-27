var input = @"Said the Duck, ‘As I sate on the rocks,
    I have thought over that completely,
And I bought four pairs of worsted socks
    Which fit my web-feet neatly.
And to keep out the cold I’ve bought a cloak,
And every day a cigar I’ll smoke,
    All to follow my own dear true
    Love of a Kangaroo!";

ReadLineByLine(input, () => Console.WriteLine("Finished!"));
Console.ReadKey();

void ReadLineByLine(string input, Action onFinished)
{
    string[] lines = input.Split(Environment.NewLine);
    for (int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];
        Console.WriteLine($"[Line number {i}] {line}");
    }
    onFinished();
}

//Interfaces and callbacks (Funcs, Actions) have much in common
//Func or action is like an interface with single method
class PersonalDataFormatterWithInterface
{
    private readonly IPeopleDataReader _peopleDataReader;

    public PersonalDataFormatterWithInterface(IPeopleDataReader peopleDataReader)
    {
        _peopleDataReader = peopleDataReader;
    }

    public string Format()
    {
        var people = _peopleDataReader.ReadPeople();
        return string.Join("\n",
            people.Select(p => $"{p.Name} born in" +
            $" {p.Country} on {p.YearOfBirth}"));
    }
}

class PersonalDataFormatterWithFunc
{
    private readonly Func<IEnumerable<Person>> _getPeople;

    public PersonalDataFormatterWithFunc(Func<IEnumerable<Person>> getPeople)
    {
        _getPeople = getPeople;
    }

    public string Format()
    {
        var people = _getPeople();
        return string.Join("\n",
            people.Select(p => $"{p.Name} born in" +
            $" {p.Country} on {p.YearOfBirth}"));
    }
}

interface IPeopleDataReader
{
    IEnumerable<Person> ReadPeople();
}

record Person(string Name, int YearOfBirth, string Country);