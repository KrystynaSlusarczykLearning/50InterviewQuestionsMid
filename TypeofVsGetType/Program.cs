var type1 = typeof(Base);
Console.WriteLine("type1: " + type1.FullName);

var baseObj = new Base();
var type2 = baseObj.GetType();
Console.WriteLine("type2: " + type2.FullName);

Derived derived = new Derived();
var type3 = derived.GetType();
Console.WriteLine("type3: " + type3.FullName);

Base derivedAsBase = new Derived();
var type4 = derivedAsBase.GetType();
Console.WriteLine("type4: " + type4.FullName);

Console.WriteLine();

PrintTypeName(derived);

string text = "abc";
PrintTypeName(text);

Console.ReadKey();

void PrintTypeName(object obj)
{
    var type = obj.GetType();
    Console.WriteLine("type name is: " + type.FullName);
}

class Base
{

}

class Derived : Base
{

}