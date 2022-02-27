using IronPython.Hosting;

dynamic text = "Some text";

//this will compile, but will fail at runtime
//text.ThisMethodDoesNotExistInStringType();

//the below variable is also of type dynamic
var textToUpper = text.ToUpper();

//casting can be used to "unwrap" the actual type from the dynamic variable
//implicitly...
string actualText = text;

//or explicitly...
string actualTextExplicitCast = (string)text;

var someClass = new SomeClass(text);

Console.WriteLine(RunPython());

Console.ReadKey();

dynamic RunPython()
{
    const string pythonScript =
    @"class PythonClass:
    def toUpper(self, input):
        return input.upper()";

    var engine = Python.CreateEngine();
    var scope = engine.CreateScope();
    var operations = engine.Operations;

    engine.Execute(pythonScript, scope);
    var pythonClassObj = scope.GetVariable("PythonClass");
    dynamic instance = operations.CreateInstance(pythonClassObj);

    return instance.toUpper("Hello!");
}

class SomeClass
{
    public string Text { get; }
    public SomeClass(dynamic hopefullyText)
    {
        Text = hopefullyText;
    }
}