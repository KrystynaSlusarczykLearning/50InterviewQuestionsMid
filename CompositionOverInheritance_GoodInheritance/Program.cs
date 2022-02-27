
Console.ReadLine();

public class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public int YearOfBirth { get; }

    public Person(string firstName, string lastName, int yearOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        YearOfBirth = yearOfBirth;
    }
}

public class Employee : Person
{
    public Employee(
        string firstName, 
        string lastName, 
        int yearOfBirth, 
        string position) :
        base(firstName, lastName, yearOfBirth)
    {
        Position = position;
    }

    public string Position { get; }
}

//in this case using composition is awkward
public class ComposedEmployee
{
    private Person _person;
    public string FirstName => _person.FirstName;
    public string LastName => _person.LastName;
    public int YearOfBirth => _person.YearOfBirth;
    public string Position { get; }

    public ComposedEmployee(Person person, string position)
    {
        _person = person;
        Position = position;
    }
}

