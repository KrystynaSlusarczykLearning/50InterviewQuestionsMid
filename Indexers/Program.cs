var numbers = new int[] { 10, 20, 30 };
var atIndex1 = numbers[1]; //indexer of an array

var list = new List<decimal> { 5.5m, 3m, 0m };
var thirdElement = list[2];

var text = "hello";
var secondLetter = text[1]; //indexer of a string

var currencies = new Dictionary<string, string>
{
    ["USA"] = "USD",
    ["Great Britain"] = "GBP",
    ["Poland"] = "PLN"
};
var currencyInGreatBritain = currencies["Great Britain"]; //indexer of a Dictionary

//custom indexers, defined for our own type
var myList = new MyList<int>(numbers);
var secondValue = myList[1];
var firstValue = myList["0"];
var thirdValue = myList[1, 1]; //value at index 1+1 will be retrieved
//this indexer is readonly, so we can't update the value
//myList[1, 1] = 5;

Console.ReadKey();

class MyList<T>
{
    private T[] _numbers;

    public MyList(T[] numbers)
    {
        _numbers = numbers;
    }

    //this is correct, but much longer than expression-bodied indexer defined below
    //public T this[int index]
    //{
    //    get 
    //    { 
    //        return _numbers[index]; 
    //    }
    //    set 
    //    {
    //        _numbers[index] = value; 
    //    }
    //}

    public T this[int index]
    {
        get => _numbers[index]; 
        set => _numbers[index] = value; 
    }

    public T this[string textIndex]
    {
        get => _numbers[int.Parse(textIndex)];
        set => _numbers[int.Parse(textIndex)] = value;
    }

    public T this[int index1, int index2]
    {
        get => _numbers[index1 + index2];
    }
}
