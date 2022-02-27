global using System.Diagnostics;

using PersonDTO = DTOs.Person;
using PersonDomain = DomainObjects.Person;
using static System.Console;
using System.Text;

var stopwatch = new Stopwatch();

var personDTO = new PersonDTO();
var domainPerson = new PersonDomain();

WriteLine("Hello!");
WriteLine("How");
WriteLine("are");
WriteLine("you?");

FileStream fileStream1 = File.Open("some path", FileMode.Open);
try
{
    //some operations
}
finally
{
    fileStream1.Dispose();
}

using(var fileStream2 = File.Open("some path", FileMode.Open))
{
    //some operations
}

//this is possible staring with C# 8

using var fileStream3 = File.Open("some path", FileMode.Open);
//some operations

ReadLine();