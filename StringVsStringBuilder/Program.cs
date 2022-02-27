//string is immutable, so every modification actually creates a new string
using System.Text;

var someString = "abc";
someString = "def";
someString += "g";
Console.WriteLine("someString is " + someString);

//if result is not built incrementally but in one instruction, stick to simple string:
var firstName = "John";
var lastName = "Smith";
string name1 = firstName + " " + lastName;
//behind the scenes it actually gets translated to:
string name = String.Concat(firstName, " ", lastName);

//this is not only uglier but actually slower:
StringBuilder builder = new StringBuilder();
builder.Append(firstName);
builder.Append(" ");
builder.Append(lastName);
string name2 = builder.ToString();

Console.ReadLine();
