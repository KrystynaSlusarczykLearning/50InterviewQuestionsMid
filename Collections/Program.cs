var strings = new string[5];
strings[0] = "hello";
//this would thrown an IndexOutOfRangeException
//strings[10] = "this is not going to work";

var numbers = new[] { 1, 2, 3 };
var twoDimensionalArray = new int[3,5];
twoDimensionalArray[1, 2] = 10;

var jaggedArray = new[]
{
    new[] { 1, 2, 3 },
    new[] { 1 },
    new[] { 1, 2 },
};
jaggedArray[2][1] = 5;


Console.ReadKey();
