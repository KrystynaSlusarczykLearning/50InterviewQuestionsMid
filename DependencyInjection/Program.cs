namespace DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        //creation of objects
        var logger = new Logger();
        var peopleDataReader = new PeopleDataReader(logger);
        var formatterFactory = new FormatterFactory();
        var personalDataFormatter = new PersonalDataFormatter(
            peopleDataReader,
            logger,
            formatterFactory);

        //actual run of the application
        Console.WriteLine(personalDataFormatter.Format(false));

        Console.ReadKey();
    }
}

class PersonalDataFormatterWithFunc
{
    private readonly Func<IEnumerable<Person>> _readPeople;

    public PersonalDataFormatterWithFunc(
        Func<IEnumerable<Person>> readPeople)
    {
        _readPeople = readPeople;
    }

    public string Format()
    {
        var people = _readPeople();

        return string.Join("\n",
          people.Select(p => $"{p.Name} born in" +
          $" {p.Country} on {p.YearOfBirth}"));
    }
}

class PersonalDataFormatter
{
    private readonly ILogger _logger;
    private readonly IPeopleDataReader _peopleDataReader;
    private readonly IFormatterFactory _formatterFactory;

    public PersonalDataFormatter(
        IPeopleDataReader peopleDataReader,
        ILogger logger,
        IFormatterFactory formatterFactory)
    {
        _peopleDataReader = peopleDataReader;
        _logger = logger;
        _formatterFactory = formatterFactory;
    }

    public string Format(bool isDefaultFormatting)
    {
        _logger.Log("Formatter running...");
        var people = _peopleDataReader.ReadPeople();

        if (isDefaultFormatting)
        {
            return string.Join("\n",
              people.Select(p => $"{p.Name} born in" +
              $" {p.Country} on {p.YearOfBirth}"));
        }
        var formatter = _formatterFactory.Create();
        return formatter.Format(people);
    }
}

class PersonalDataFormatterWithoutDependencyInjection
{
    public string Format()
    {
        var peopleDataReader = new PeopleDataReader(new Logger());

        var people = peopleDataReader.ReadPeople();
        return string.Join("\n",
            people.Select(p => $"{p.Name} born in" +
            $" {p.Country} on {p.YearOfBirth}"));
    }
}

interface IPeopleDataReader
{
    IEnumerable<Person> ReadPeople();
}

class PeopleDataReader : IPeopleDataReader
{
    private readonly ILogger _logger;

    public PeopleDataReader(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<Person> ReadPeople()
    {
        _logger.Log("Reading from database");
        return new List<Person>
        {
            new Person("John", 1982, "USA"),
            new Person("Aja", 1992, "India"),
            new Person("Tom", 1954, "Australia"),
        };
    }
}

record Person(string Name, int YearOfBirth, string Country);

interface ILogger
{
    void Log(string message);
}

class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

interface IFormatterFactory
{
    IFormatter Create();
}

class FormatterFactory : IFormatterFactory
{
    public IFormatter Create()
    {
        return new NameOnlyFormatter();
    }
}

interface IFormatter
{
    string Format(IEnumerable<Person> people);
}

class NameOnlyFormatter : IFormatter
{
    public string Format(IEnumerable<Person> people)
    {
        return string.Join("\n",
            people.Select(p => p.Name));
    }
}