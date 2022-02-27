public class Program
{
    public static void Main(string[] args)
    {
        #if DEBUG
        Console.WriteLine("We are in Debug mode!");
        #endif

        #if RELEASE
        Console.WriteLine("We are in Release mode!");
        #endif

        int someUnusedVariable = 5;
        const string Hello = "Hello!";
        Console.WriteLine(Hello + Hello);
        Console.ReadKey();
    }
}

