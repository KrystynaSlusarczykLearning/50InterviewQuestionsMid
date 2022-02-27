//we can assign functions to a variable of delegate type
ProcessString processString1 = TrimTo5Letters;
ProcessString processString2 = ToUpper;

Console.WriteLine(processString1("Helloooooooooooooo"));
Console.WriteLine(processString2("Helloooooooooooooo"));

Print print1 = text => Console.WriteLine(text.ToLower());
Print print2 = text => Console.WriteLine(text.ToUpper());
Print print3 = print1 + print2;
print3("Crocodile");

Print print4 = text => Console.WriteLine(text.Substring(0,3));
print3 += print4;
print3("Giraffe");

//altenatively, we can use Funcs, which are generic delegates
Func<string, string> processString1Func = TrimTo5Letters;
Func<string, string> processString2Func = ToUpper;

Func<string, string, int> sumLengths =
    (text1, text2) => text1.Length + text2.Length;

Func<string, string, int> sumLengths2 = SumLenghts;

//to represent a void function, we must use Action instead of Func
Action<string> printToConsole = PrintToConsole;

//we can't have Funcs or actions with ref or out parameters
//Func<out string, ref int, double> funcWithRefOut;

//also, we can't have Funcs or Actions with optional parameters
//Func<string, int, bool> funcWithOptionalParameters =
//    (text, number = 0) => true;

//nor with "params" parameters
//Func<params string[], int> funcWithParams;

Func<int, string, bool, DateTime, float> verySpecificFunc;
Calculate superComplexFuncionUsedEverywhereInTheProject;

Console.ReadKey();

void PrintToConsole(string text)
{
    Console.WriteLine(text);
}

int SumLenghts(string text1, string text2)
{
    return text1.Length + text2.Length;
}

string TrimTo5Letters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProcessString(string input);

delegate void Print(string input);

delegate float Calculate(
    int number, string text, bool flag, DateTime date);

//built-in Func type is also a delegate
//delegate TReturn Func<TInput1, TInput2, TReturn>(
//    TInput1 input1, TInput2 input2);

//delegates, unlike Funcs or Actions, can use ref or out parameters
delegate double DelegateWithRefOut(
    out string text, ref int number);

//..optional parameters
delegate bool DelegateWithOptionalParam(
    string text, int number = 0);

//...and "params"
delegate int DelegateWithParams(params string[] words);

interface ICommandExecutor
{
    void Execute(Func<CommandType, bool> command);
    void Execute(RunCommand command);
}

enum CommandType { Start, Stop, Reset }

delegate bool RunCommand(CommandType commandType);
