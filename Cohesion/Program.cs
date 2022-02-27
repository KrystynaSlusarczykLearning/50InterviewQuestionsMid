var house = new House("123 Maple Road", 155, 1);
var ownersDatabase = new OwnersDatabase();
var housePricerLowCohesion = new HousePricerLowCohesion(2000, ownersDatabase);
housePricerLowCohesion.SendPriceToOwner(house);

var housePricer = new HousePricer(2000);
var price = housePricer.GetPrice(house);
var ownerNotifier = new OwnerNotifier(ownersDatabase);
ownerNotifier.SendPriceToOwner(price, house.Address);

Console.ReadKey();

//this class is highly cohesive
class PetsCollection
{
    private List<Pet> _pets = new ();

    public void Add(Pet pet) => _pets.Add(pet);
    public int Count => _pets.Count;
    public IEnumerable<PetType> GetCurrentlyStoredTypes() => 
        _pets.Select(pet => pet.PetType).Distinct();
    public bool Contains(PetType petType) =>
        GetCurrentlyStoredTypes().Any(type => type == petType);
}

public record Pet(string Name, PetType PetType, float Weight);
public enum PetType { Cat, Dog, Fish }

//this class is not cohesive
public class HousePricerLowCohesion
{
    private IOwnersDatabase _ownersDatabase;
    private decimal _dollarsPerSquareMeter;
    public HousePricerLowCohesion(
        decimal dollarsPerSquareMeter, 
        IOwnersDatabase ownersDatabase)
    {
        _dollarsPerSquareMeter = dollarsPerSquareMeter;
        _ownersDatabase = ownersDatabase;
    }

    public decimal GetPrice(House house) =>
        _dollarsPerSquareMeter * (decimal)house.Area *
        GetPriceMultiplierBasedOnFloors(house.Floors);

    private decimal GetPriceMultiplierBasedOnFloors(int floors) =>
        floors switch { 1 => 1m, 2 => 1.5m, _ => 1.6m };

    public void SendPriceToOwner(House house) =>
        Console.WriteLine($"Sending price {GetPrice(house)}" +
            $" to {FindOwnerEmail(house.Address)}");

    private string FindOwnerEmail(string address) =>
        _ownersDatabase.GetEmailByAddress(address);
}

//the above class can be split into two highly-cohesive classes
public class HousePricer
{
    private decimal _dollarsPerSquareMeter;
    public HousePricer(decimal dollarsPerSquareMeter)
    {
        _dollarsPerSquareMeter = dollarsPerSquareMeter;
    }

    public decimal GetPrice(House house) =>
        _dollarsPerSquareMeter * (decimal)(house.Area) *
        GetPriceMultiplierBasedOnFloors(house.Floors);

    private decimal GetPriceMultiplierBasedOnFloors(int floors) =>
        floors switch { 1 => 1m, 2 => 1.5m, _ => 1.6m };
}

public class OwnerNotifier
{
    private IOwnersDatabase _ownersDatabase;
    public OwnerNotifier(IOwnersDatabase ownersDatabase)
    {
        _ownersDatabase = ownersDatabase;
    }

    public void SendPriceToOwner(decimal price, string address) =>
        Console.WriteLine($"Sending price price" +
            $" to {FindOwnerEmail(address)}");

    private string FindOwnerEmail(string address) =>
        _ownersDatabase.GetEmailByAddress(address);
}

public record House(string Address, double Area, int Floors);

public interface IOwnersDatabase
{
    string GetEmailByAddress(string address);
}

public class OwnersDatabase : IOwnersDatabase
{
    public string GetEmailByAddress(string address)
    {
        if(address == "123 Maple Road")
        {
            return "john_smith@mail.com";
        }
        throw new InvalidOperationException("Unknown address");
    }
}