Console.WriteLine("Hello! What's your name?");
var name = Console.ReadLine();
int yearOfBirth;
do
{
    Console.WriteLine("What year you were born?");
}
while (!int.TryParse(Console.ReadLine(), out yearOfBirth));

Console.WriteLine(
    $"Hello {name}, you are " +
    $"{DateTime.Now.Year - yearOfBirth} years old!");

Console.ReadKey();

