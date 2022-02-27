Console.WriteLine(TypeCheck("some string"));
Console.WriteLine(Properties("not a pet"));
Console.WriteLine(Properties(new Pet("Bobby", PetType.Fish, 136000)));
Console.WriteLine(Properties(new Pet("Taiga", PetType.Dog, 30)));

Console.ReadKey();

//null check
string NullCheck(object obj)
{
    if (obj is null)
    {
        return "Object is null!";
    }
    else
    {
        return "Object is null not null: " + obj.ToString();
    }
}

//type check
string TypeCheck(object obj)
{
    if (obj is string asString)
    {
        return "String is: " + asString;
    }
    else
    {
        return "Obj is not a string";
    }
}

object ComparingDiscreteValues(string number, string type)
{
    return type switch
    {
        "int" => int.Parse(number),
        "decimal" => decimal.Parse(number),
        "float" => float.Parse(number),
        _ => throw new ArgumentException($"{type} type is not supported"),
    };
}

string Relational(int age)
{
    return age switch
    {
        18 => "just become adult, at least in some countries",
        (> 20) and (< 60) => "middle-aged",
        < 11 => "child",
        < 20 => "teenager",
        > 60 => "senior",
    };
}

string Properties(object obj)
{
    if (obj is Pet { Weight: > 10000, TypeOfPet: PetType.Fish })
    {
        return "It must be a whale shark!";
    }
    if(obj is Pet)
    {
        return "It's some kind of pet.";
    }
    return "It's definitely not a pet.";
}

string Deconstruction(Pet pet)
{
    return pet switch
    {
        (_, TypeOfPet: PetType.Dog, Weight: 10) => "Small dog of any name",
        (Name: "Hannibal", TypeOfPet: PetType.Fish, _) => "Fish called Hannibal",
        Pet { Weight: >100 } => "Heavy pet",
        _ => "Unknown!"
    };
}

public record Pet(string Name, PetType TypeOfPet, float Weight);
public enum PetType { Cat, Dog, Fish }
