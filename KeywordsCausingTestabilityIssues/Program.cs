using NUnit.Framework;

public interface IDatabaseConnection<T>
{
    Person GetById(int personId);
    void CreateNew(Person person);
    void Update(Person person);
}

public class Person
{
    public int? Id { get; }
    public int Name { get; }
}

public class PersonController
{
    private IDatabaseConnection<Person> _databaseConnection;

    public PersonController(IDatabaseConnection<Person> databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public Person GetById(int personId)
    {
        return _databaseConnection.GetById(personId);
    }

    public void Person(Person person)
    {
        if(person.Id == null)
        {
            _databaseConnection.CreateNew(person);
        }
        else
        {
            _databaseConnection.Update(person);
        }
    }
}

[TestFixture]
public class PersonControllerTests
{
    [Test]
    public void 
}