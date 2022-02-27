var factory = new PersonalDataFormatterFactory();

var fromExcel = factory.Create(Source.Excel);
Console.WriteLine(fromExcel.Format());

Console.WriteLine();

var fromDatabase = factory.Create(Source.Database);
Console.WriteLine(fromDatabase.Format());

Console.ReadKey();

enum Source { Database, Excel }

class PersonalDataFormatterFactory
{
    public PersonalDataFormatter Create(Source source)
    {
        switch (source)
        {
            case Source.Database:
                return new DatabaseSourcedPersonalDataFormatter();
            case Source.Excel:
                return new ExcelSourcedPersonalDataFormatter();
            default:
                throw new ArgumentException("Invalid source");
        }
    }
}

abstract class PersonalDataFormatter
{
    public string Format()
    {
        var people = ReadPeople();
        return string.Join("\n",
            people.Select(p => $"{p.Name} born in" +
            $" {p.Country} on {p.YearOfBirth}"));
    }

    protected abstract IEnumerable<Person> ReadPeople();
}

class DatabaseSourcedPersonalDataFormatter : PersonalDataFormatter
{
    protected override IEnumerable<Person> ReadPeople()
    {
        Console.WriteLine("Reading from database");
        return new List<Person>
        {
            new Person("John", 1982, "USA"),
            new Person("Aja", 1992, "India"),
            new Person("Tom", 1954, "Australia"),
        };
    }
}

class ExcelSourcedPersonalDataFormatter : PersonalDataFormatter
{
    protected override IEnumerable<Person> ReadPeople()
    {
        Console.WriteLine("Reading from an Excel file");
        return new List<Person>
        {
            new Person("Martin", 1972, "France"),
            new Person("Aiko", 1995, "Japan"),
            new Person("Selene", 1944, "Great Britain"),
        };
    }
}

record Person(string Name, int YearOfBirth, string Country);
