Console.WriteLine("Both logging and count limiting");

IPeopleDataReader loggingCountLimitingPeopleDataReader =
    new CountLimitingDecorator(3,
        new LoggingDecorator(new Logger(),
            new PeopleDataReader()));

//the order of Decorators matters! The below will give different result

//IPeopleDataReader loggingCountLimitingPeopleDataReader =
//    new LoggingDecorator(new Logger(),
//        new CountLimitingDecorator(3,
//            new PeopleDataReader()));

var people1 = loggingCountLimitingPeopleDataReader.Read();
foreach(var person in people1)
{
    Console.WriteLine(person);
}

Console.WriteLine();

Console.WriteLine("Only count limiting");

IPeopleDataReader countLimitingPeopleDataReader =
    new CountLimitingDecorator(3,
        new PeopleDataReader());

var people2 = countLimitingPeopleDataReader.Read();
foreach (var person in people2)
{
    Console.WriteLine(person);
}

Console.WriteLine();

Console.WriteLine("Only logging");

IPeopleDataReader loggingPeopleDataReader =
    new LoggingDecorator(new Logger(),
        new PeopleDataReader());

var people3 = loggingPeopleDataReader.Read();
foreach (var person in people3)
{
    Console.WriteLine(person);
}

Console.ReadKey();

interface IPeopleDataReader
{
    IEnumerable<Person> Read();
}

class PeopleDataReader : IPeopleDataReader
{
    public IEnumerable<Person> Read()
    {
        return new List<Person>
        {
            new Person("Martin", 1972, "France"),
            new Person("Aiko", 1995, "Japan"),
            new Person("Selene", 1944, "Great Britain"),
            new Person("Michael", 1980, "Canada"),
            new Person("Anne", 1974, "New Zealand"),
        };
    }
}

class LoggingDecorator : IPeopleDataReader
{
    private readonly IPeopleDataReader _decoratedReader;
    private readonly ILogger _log;

    public LoggingDecorator(
        ILogger log, 
        IPeopleDataReader decoratedReader)
    {
        _decoratedReader = decoratedReader;
        _log = log;
    }

    public IEnumerable<Person> Read()
    {
        var data = _decoratedReader.Read();
        _log.Log($"Read {data.Count()} elements");
        return data;
    }
}

class CountLimitingDecorator : IPeopleDataReader
{
    private readonly IPeopleDataReader _decoratedReader;
    private readonly int _countLimit;

    public CountLimitingDecorator(
        int countLimit,
        IPeopleDataReader decoratedReader)
    {
        _decoratedReader = decoratedReader;
        _countLimit = countLimit;
    }

    public IEnumerable<Person> Read()
    {
        Console.WriteLine(
            $"LIMITING the result to {_countLimit} elements");
        return _decoratedReader.Read().Take(_countLimit);
    }
}

record Person(string FirstName, int YearOfBirth, string Country);

interface ILogger
{
    void Log(string message);
}

class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

class PeopleDataReaderWithoutDecorators: IPeopleDataReader
{
    bool _shallLog;
    bool _shallLimitCount;
    int _countLimit;
    private readonly ILogger _log;

    public PeopleDataReaderWithoutDecorators(
        bool shallLog,
        bool shallLimitCount, 
        ILogger log, 
        int countLimit = 0)
    {
        _shallLog = shallLog;
        _log = log;
        _shallLimitCount = shallLimitCount;
        _countLimit = countLimit;
    }

    public IEnumerable<Person> Read()
    {        
        var data = new List<Person>
        {
            new Person("Martin", 1972, "France"),
            new Person("Aiko", 1995, "Japan"),
            new Person("Selene", 1944, "Great Britain"),
            new Person("Michael", 1980, "Canada"),
            new Person("Anne", 1974, "New Zealand"),
        };
        if (_shallLog)
        {
            _log.Log($"Read {data.Count()} elements");
        }
        
        return _shallLimitCount ? 
            data.Take(_countLimit) :
            data;
    }
}