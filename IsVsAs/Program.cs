
//"is" keyword checks if object is of given type
//it returns a boolean result
object text = "Hello!";
//"as" can be only used to cast to reference types of Nullable
//int textAsInt = text as int;

bool isString = text is string;
Console.WriteLine("isString? " + isString);

//we can use "is" to check if an object is a reference type or a value type
bool isInt = text is int;
Console.WriteLine("isInt? " + isInt);

//"as" is used to cast an object to a given type
string textAsString = text as string;

Console.WriteLine(textAsString + " -> it's now a string");

//"as" doesn't work with value types 
//that's why below line doesn't compile
//long longNumber = number as long;

//the only expection is nullable
//it is a value type, but we can use "as" with it
int number = 10;
int? nullableNumber = number as int?;
Console.WriteLine(nullableNumber + " -> it's now a nullable int");

int? nullAsNullableInt = null as int?;
Console.WriteLine(nullAsNullableInt + " -> it's null");

//the reason why casting with "as" must be to reference types or nullable
//is that if the casting will not succeed, the result will be null

//This is the main difference between casting with "as" and regular casting
//is that when casting with "as" fails, it will give null
//whereas if regular casting will fail, it will throw an exception

object numbers = new int[] { 1, 2, 3 };

//the below will succeed and will give a non-null value
var asIList = numbers as IList<int>;
Console.WriteLine("asIList is null? : " + (asIList == null));
var castToIList = (IList<int>)numbers;

//the below will not succeed and will give a null value
var asList = numbers as List<int>;
Console.WriteLine("asList is null? : " + (asList == null));

//the below will not succeed and will throw an exception
try
{
    var castToList = (List<int>)numbers;
}
catch (InvalidCastException)
{
    Console.WriteLine("InvalidCastException has been thrown");
}

Console.ReadKey();