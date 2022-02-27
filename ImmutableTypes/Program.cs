var immutablePoint = new ImmutablePoint(10, 11);
//we can't change the value of an immutable object,
//so the below line will not compile
//immutablePoint.X = 5;

var point = new Point(5, 10);
SomeMethod(point);
SomeOtherMethod(point);
Console.WriteLine($"X:{point.X}, Y:{point.Y}");

void SomeMethod(Point point)
{
    point.X = 500;
}

void SomeOtherMethod(Point point)
{
}

var person = new Person("123456789", "John", 1987);
//this will make the person object invalid,
//yet it is allowsed with mutable objects
//person.Id = null;

//objects used as keys in the dicitonary should be immutable
//otherwise their identity may change over time
var dict = new Dictionary<Person, string>();
dict[person] = "aaa";
person.Id = "new id";
//the below will throw because there is no such key in the dictionary,
//because the hashcode changed because it's built using the Id that changed
//Console.WriteLine(dict[person]);

if(string.IsNullOrEmpty(person.Name) ||
    person.Name.Length < 2 ||
    person.Name.Length > 25)
{
    //test this path
}
else
{
    //test this path too
}

var januaryThe1st = new DateTime(2022, 1, 1);
var januaryThe8th = januaryThe1st.AddDays(7);

Console.ReadKey();

public class ImmutablePoint 
{
    public int X { get; }
    public int Y { get; }

    public ImmutablePoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set;}

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Person
{
    public Person(string id, string name, int yearOfBirth)
    {
        if (string.IsNullOrEmpty(id) ||
            id.Length != 9 ||
            !id.All(character => char.IsDigit(character)))
        {
            throw new ArgumentException("Id is invalid");
        }
        if (string.IsNullOrEmpty(name) || name.Length < 2 || name.Length > 25)
        {
            throw new ArgumentException("Name is invalid");
        }
        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentException("YearOfBirth is invalid");
        }
        Id = id;
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public int YearOfBirth { get; set; }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}