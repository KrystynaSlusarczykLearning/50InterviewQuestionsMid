var array = new int[5]; //this array will hold 5 zeros
//array[10] = 7; //this will throw an IndexOutOfRangeException

var stringsArray = new [] {"a", "b", "c"};

//single-dimensional array filled with defaults (0s in case of int)
var numbers = new int[5];

//two-dimensional array
var matrix = new int[3, 5];
matrix[1, 1] = 10;

//jagged array
var jagged = new int[3][];
jagged[0] = new int[2];
jagged[1] = new int[1];
jagged[2] = new int[3];

jagged[2][1] = 7;

Console.ReadKey();
