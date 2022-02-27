using var fileReader = new FileReader("input.txt");
var line1 = fileReader.ReadLine();
var line2 = fileReader.ReadLine();

//below we trigger the destruction
//of the john object from the SomeMethod method
SomeMethod();

GC.Collect();
Console.ReadKey();

void SomeMethod()
{
    var john = new Person("John");
}

class Person
{
    string Name { get; }
    public Person(string name) => Name = name;
    ~Person()
    {
        Console.WriteLine($"Person {Name} is being destructed");
    }

    //we can't declare the Finalize method, we must use the destructor
    //protected override void Finalize()
    //{

    //}
}

class FileReader : IDisposable
{
    private StreamReader? _streamReader;
    private readonly string _path;

    public FileReader(string path)
    {
        _path = path;
    }

    public string ReadLine()
    {
        _streamReader ??= new StreamReader(_path);
        return _streamReader.ReadLine();
    }

    public void Dispose()
    {
        _streamReader?.Dispose();
    }
}