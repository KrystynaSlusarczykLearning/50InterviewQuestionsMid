var calculatorTests = new CalculatorTests();
Console.WriteLine(calculatorTests.Run() ? "Success!" : "Failure");
Console.ReadKey();

abstract class TestFixture
{
    public bool Run()
    {
        int failedTestsCount = 0;
        foreach (var test in GetTests())
        {
            SetUp();
            if (!test())
            {
                failedTestsCount++;
            }
            TearDown();
        }
        return failedTestsCount == 0;
    }

    protected abstract IEnumerable<Func<bool>> GetTests();
    protected abstract void SetUp();
    protected abstract void TearDown();
}

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

class CalculatorTests : TestFixture
{
    private Calculator _cut;

    protected override void SetUp()
    {
        _cut = new Calculator();
        Console.WriteLine("SetUp of MyTests class");
    }

    protected override IEnumerable<Func<bool>> GetTests()
    {
        return new List<Func<bool>>()
        {
            () => 
            {
                Console.WriteLine("3 + 2 shall be 5");
                return _cut.Add(3,2) == 5;
            },
            () =>
            {
                Console.WriteLine("10 + (-10) shall be 0");
                return _cut.Add(10, -10) == 0;
            }
        };
    }

    protected override void TearDown()
    {
        Console.WriteLine("TearDown of MyTests class");
    }
}

