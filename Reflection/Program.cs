var converter = new ObjectToTextConverter();

Console.WriteLine(converter.Convert(
    new House("123 Maple Road, Berrytown", 170.6d, 2)));

Console.WriteLine(converter.Convert(
    new Pet("Taiga", PetType.Dog, 30)));

Console.ReadKey();

class ObjectToTextConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();

        var properties = type
            .GetProperties()
            .Where(property => property.Name != "EqualityContract");

        return string.Join(
            ", ", 
            properties
                .Select(property => 
                $"{property.Name} is {property.GetValue(obj)}"));
    }
}

public record Pet(string Name, PetType PetType, float Weight);
public record House(string Adderss, double Area, int Floors);
public enum PetType {Cat, Dog, Fish}