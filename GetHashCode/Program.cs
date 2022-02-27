var anyObject1 = "abc";
Console.WriteLine(
    $"'{anyObject1}' hashcode is {anyObject1.GetHashCode()}");

var anyObject2 = 123;
Console.WriteLine(
    $"{anyObject2} hashcode is {anyObject2.GetHashCode()}");

var point1 = new Point(10, 20);
var point2 = new Point(10, 20);
var point3 = new Point(20, 30);
Console.WriteLine($"{point1} hash code is {point1.GetHashCode()}");
Console.WriteLine($"{point2} hash code is {point2.GetHashCode()}");
Console.WriteLine($"{point3} hash code is {point3.GetHashCode()}");

Console.ReadKey();

class Point
{
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString()
    {
        return $"X={X}, Y={Y}";
    }
}

class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public int YearOfBirth { get; }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, YearOfBirth);
    }

    public Person(string firstName, string lastName, int yearOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        YearOfBirth = yearOfBirth;
    }
}