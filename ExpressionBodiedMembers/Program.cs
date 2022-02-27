
Console.ReadKey();

public class Person
{
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public Person(string name) => Name = name;

    ~Person() => Console.WriteLine("Destructing the Person object");

    //this takes 7 lines
    //public int Age
    //{
    //    get
    //    {
    //        return DateTime.Now.Year - YearOfBirth;
    //    }
    //}

    //and this takes 1!
    public int Age => DateTime.Now.Year - YearOfBirth;


    //old-fashioned property with extra operation on set
    private string _lastName;
    //public string LastName
    //{
    //    get
    //    {
    //        return _lastName;
    //    }
    //    set
    //    {
    //        _lastName = value.Trim();
    //    }
    //}

    //expression-bodied property with extra operation on set
    public string LastName
    {
        get => _lastName;
        set => _lastName = value.Trim();
    }

    public override string ToString() => $"{Name} who was born on {YearOfBirth}";

    public void Print() => Console.WriteLine(ToString());

    //we can;t make this method an expression-bodied method, because it has more
    //than one statement or expression
    public bool IsNameValid()
    {
        if (Name == null)
        {
            Console.WriteLine("Name is null.");
            return false;
        }
        if (Name.Length == 0)
        {
            Console.WriteLine("Name is too short.");
            return false;
        }
        if (Name.Length > 25)
        {
            Console.WriteLine("Name is too long.");
            return false;
        }
        return true;
    }
}

