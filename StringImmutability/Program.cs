//value type bahavior - they are passed by value
var valueType = 5;
Console.WriteLine($"Value type is {valueType}");
Console.WriteLine("Executing AddOneToValueType method");
AddOneToValueType(valueType);
Console.WriteLine($"Now value type is {valueType}");

Console.WriteLine();

//reference type bahavior - they are passed by reference
var referenceType = new List<int> { 5 };
Console.WriteLine($"Reference type has {referenceType.Count} elements");
Console.WriteLine("Executing AddOneToReferenceType method");
AddOneToReferenceType(referenceType);
Console.WriteLine($"Now reference type has {referenceType.Count} elements");

Console.WriteLine();

//string behavior
var text = "Hello!";
Console.WriteLine($"text is {text}");
Console.WriteLine("Executing AddOneToString method");
AddOneToString(text);
Console.WriteLine($"Now text is {text}");

Console.WriteLine();

List<int> list1 = new List<int> { 1, 2, 3 };
List<int> list2 = new List<int> { 1, 2, 3 };
Console.WriteLine(
    $"Are two reference type objects equal " +
    $"by value considered equal?: {list1 == list2}");

var string1 = "abc";
var string2 = "abc";
Console.WriteLine(
    $"Are two string objects equal " +
    $"by value considered equal?: {string1 == string2}");

//Interning
//if many variables point to the same strings
//the runtime actually holds only one copy of it in the memory
var text1 = "Hello!";
var text2 = "Hello!";
var text3 = "Hello!";
var text4 = "Hello!";

Console.ReadKey();


void AddOneToValueType(int valueType)
{
    ++valueType;
}

void AddOneToReferenceType(List<int> referenceType)
{
    referenceType.Add(6);
}

void AddOneToString(string text)
{
    text += "1";
}