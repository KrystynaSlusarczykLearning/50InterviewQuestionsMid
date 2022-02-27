var list = new List<int> { 1,2,3 };
list.Add(4);
list[0] = 5;
var last = list[list.Count - 1];

//List provided many useful methods
list.RemoveAt(0); //removes element at given index
list.Clear(); //empties the List
list.AddRange(new []{ 5, 6, 7 }); //adds multiple elements
bool contains7 = list.Contains(7); //checks if contains a value
list.Prepend(10); //adds element at the beginning of the :ist
list.Sort(); //sorts the List

var newList = new List<int>();
Console.WriteLine(
    $"Newly created list capacity: {newList.Capacity}");

newList.Add(5);
Console.WriteLine(
    $"Capacity after adding 1 item: {newList.Capacity}");

newList.AddRange(new [] {6,7,8,9});
Console.WriteLine(
    $"Capacity when 5 items inside: {newList.Capacity}");

newList.Clear();
Console.WriteLine(
    $"Capacity after clearing: {newList.Capacity}");

var listOfCapacity1050 = new List<int>(1050);
Console.WriteLine(
    $"Capacity set to: {listOfCapacity1050.Capacity}");

listOfCapacity1050.AddRange(Enumerable.Range(0, 2000));
Console.WriteLine(
    $"Capacity is now: {listOfCapacity1050.Capacity}");

var listOfCapacity1000 = new List<int>(1000);
listOfCapacity1000.Add(5);
listOfCapacity1000.TrimExcess(); //sets the Capacity to the actual count of items
Console.WriteLine(
    $"Capacity after TrimExcess: {listOfCapacity1000.Capacity}");

var listOfSize4 = new List<int> { 1, 2, 3, 4 };
//the below will throw an exception, because
//Capacity can't be smaller than actual size
//listOfSize4.Capacity = 1;

//inserting the elements is an O(N) operation
var someList = new List<int> { 1, 2, 3, 5, 6 };
someList.Insert(3, 4);

Console.ReadKey();
