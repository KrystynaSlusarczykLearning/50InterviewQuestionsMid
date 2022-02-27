var person = new { Name = "Martin", City = "Savannah", Age = 45 };

Console.WriteLine($"This person's name is {person.Name}," +
    $"he lives in {person.City} and is {person.Age} years old");

//anonymous types properties are read-only
//so this will not compile
//person.Name = "Jack";

var pets = new[]
    {
        new Pet("Hannibal", PetType.Fish, 1.1f),
        new Pet("Anthony", PetType.Cat, 2f),
        new Pet("Ed", PetType.Cat, 0.7f),
        new Pet("Taiga", PetType.Dog, 35f),
        new Pet("Rex", PetType.Dog, 40f),
        new Pet("Lucky", PetType.Dog, 5f),
        new Pet("Storm", PetType.Cat, 0.9f),
        new Pet("Nyan", PetType.Cat, 2.2f)
    };

//we could use a regular type, but it most likely would not be used anywhere else
//var averageWeightsData = pets
//    .GroupBy(pet => pet.PetType)
//    .Select(grouping => new PetTypeAverageWeightPair(
//        grouping.Key, 
//        grouping.Average(pet => pet.Weight)))
//    .OrderBy(data => data.AverageWeight)
//    .Select(data => $"Average weight for type {data.Type} is {data.WeightAverage}");

var averageWeightsData = pets
    .GroupBy(pet => pet.PetType)
    .Select(grouping => new
    {
        Type = grouping.Key,
        WeightAverage = grouping.Average(pet => pet.Weight)
    })
    .OrderBy(data => data.WeightAverage)
    .Select(data => $"Average weight for type " +
    $"{data.Type} is {data.WeightAverage}");

Console.WriteLine(string.Join(Environment.NewLine, averageWeightsData));

//anonymous types support non-destructive mutation
var someData = new { number = 5, text = "hello!" };
var changedData = someData with { number = 10 };

var theSameData = new { number = 5, text = "hello!" };
Console.WriteLine("Are equal? " + someData.Equals(theSameData));
Console.WriteLine($"someData hashcode: {someData.GetHashCode()}, " +
    $"theSameData: {theSameData.GetHashCode()}");
Console.ReadKey();

record PetTypeAverageWeightPair(
    PetType PetType, float AverageWeight);

public record Pet(string Name, PetType PetType, float Weight);
public enum PetType { Cat, Dog, Fish }

