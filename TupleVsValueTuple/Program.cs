//Tuple.Create is the simplest way to create a tuple
var tuple = Tuple.Create(1, "aaa");
//we can also use the constructor, but we must provide type parameters
var tupleCreatedWithConstructor = new Tuple<int, string>(1, "aaa");
//tuple can have up to 8 values, so the below will not compile:
//var hugeTuple = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8, 9);

//tuples are reference types, so they are compared by reference
var tuple1 = Tuple.Create(1, "aaa");
var tuple2 = Tuple.Create(1, "aaa");
Console.WriteLine("tuple1 == tuple2: " + (tuple1 == tuple2));
//please note that if we need to compare tuples by value, we can
//we must use the Equals method then:
Console.WriteLine("tuple1.Equals(tuple2) " + tuple1.Equals(tuple2));

//ValueTuples are value types, so they are compared by value
var valueTuple = new ValueTuple<int, string>(3, "ccc");
var valueTuple1 = (2, "bbb");
var valueTuple2 = (2, "bbb");
Console.WriteLine("valueTuple1 == valueTuple2: " +
    (valueTuple1 == valueTuple2));

var dictionaryTuple = new Dictionary<Tuple<int, string>, string>();
dictionaryTuple[Tuple.Create(1, "aaa")] = "some value 1";
Console.WriteLine(dictionaryTuple[Tuple.Create(1, "aaa")]);

//tuples are immutable, so the below will not compile
//tuple1.Item1 = 5;

//value tuples are mutable:
valueTuple1.Item1 = 5;

//we can't name tuple's items as we want, we are forced to use "Item1"
var numberFromTuple = tuple1.Item1;

//for value tuples, we can use names we like
var valueTuple3 = (number: 2, text: "ccc");
var numberFromValueTuple = valueTuple3.number;
//...but Item1 and Item2 still works:
var numberFromValueTuple1 = valueTuple1.Item1;

//but if we skip the name, the defaults are the same as with tuples:
var numberFromValueTuple2 = valueTuple2.Item1;

//When working in a small scope, it's easy to follow that Item1 or Item2 means
//but if, for example, the tuple is a result of a method, it becomes complicated.
//For example, this is not very readable:
var result1 = SumCollectionTuple(
    new int[] { 1, 2, 3, 1, 4, 1 });
Console.WriteLine(
    $"Calculation result is: {result1.Item1}, {result1.Item2}");
//we need to actually look into the SumCollectionValueTuple to understand what 
//Item1 and Item2 mean

//this is much better:
var result2 = SumCollectionValueTuple(
    new int[] { 1, 2, 3, 1, 4, 1 });
Console.WriteLine(
    $"Calculation result is: {result2.sum}, {result2.count}");

//ValueTuples support deconstruction
//deconstruction breaks down the tuple into separate variables
var (sum, count) = SumCollectionValueTuple(new int[] { 1, 2, 3, 1, 4, 1 });

//we can declare ValueTuples with more than 8 items
var hugeValueTuple = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
var last = hugeValueTuple.Item12;
Console.ReadKey();

(int sum, int count) SumCollectionValueTuple(IEnumerable<int> values)
{
    return (values.Sum(), values.Count());
}

Tuple<int, int> SumCollectionTuple(IEnumerable<int> values)
{
    return Tuple.Create(values.Sum(), values.Count());
}

Tuple<int,int> GetSummaryAboutCollection(IEnumerable<int> values)
{
    var sum = values.Sum();
    var count = values.Count();
    return new Tuple<int, int>(sum, count);
}

//the alternative would be to use custom types, but this is awkward
//if the type will not be reused in different context

//SumAndCount GetSummaryAboutCollection(IEnumerable<int> values)
//{
//    var sum = values.Sum();
//    var count = values.Count();
//    return new SumAndCount { Sum = sum, Count = count };
//}

//struct SumAndCount
//{
//    public int Sum;
//    public int Count;
//}