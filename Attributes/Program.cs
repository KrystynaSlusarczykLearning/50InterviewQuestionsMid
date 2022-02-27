//we can access type's metadata using reflection
var type = typeof(Person);

var validPerson = new Person("John", 1982);
var invalidDog = new Dog("R");
var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ?
    "Person is valid" :
    "Person is not valid");
Console.WriteLine();
Console.WriteLine(validator.Validate(invalidDog) ?
    "Dog is valid" :
    "Dog is not valid");

Console.ReadKey();

public class Dog
{
    [StringLengthValidate(2, 10)]
    public string Name { get; } 
    public Dog(string name) => Name = name;
}

public class Person
{
    [StringLengthValidate(2, 25)]
    public string Name { get; } 
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public Person(string name) => Name = name;
}

[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidateAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public StringLengthValidateAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

class Validator
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type
            .GetProperties()
            .Where(property => 
                Attribute.IsDefined(
                    property, typeof(StringLengthValidateAttribute)));

        foreach (var property in propertiesToValidate)
        {
            var attribute = (StringLengthValidateAttribute)
                property.GetCustomAttributes(
                    typeof(StringLengthValidateAttribute), true).First();
            object? propertyValue = property.GetValue(obj);
            if(propertyValue is not string)
            {
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidateAttribute)} " +
                    $"can only be applied to strings.");
            }
            var value = (string)propertyValue;
            if (value.Length < attribute.Min || value.Length > attribute.Max)
            {
                Console.WriteLine($"Property {property.Name} is invalid. " +
                    $"Value: {value}. The length must be between " +
                    $"{attribute.Min} and {attribute.Max}");
                return false;
            }
        }
        return true;
   }
}