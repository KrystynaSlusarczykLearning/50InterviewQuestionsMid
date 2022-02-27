using Microsoft.Extensions.Caching.Memory;

var peopleController = new PeopleController(
    new PeopleRepositoryMock());

var john = peopleController.GetByName("John", "Smith");
john = peopleController.GetByName("John", "Smith");
john = peopleController.GetByName("John", "Smith");

Console.ReadKey();

class Cache<TKey, TValue> where TKey: notnull
{
    private readonly Dictionary<TKey, TValue> _cachedData = new();

    public TValue Get(TKey key, Func<TValue> getValueForTheFirstTime)
    {
        if (!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getValueForTheFirstTime();
        }
        return _cachedData[key];
    }
} 

class PeopleController
{
    private readonly Cache<(string, string), Person?> _cache = new();
    private readonly IRepository<Person> _peopleRepository;

    public PeopleController(IRepository<Person> peopleRepository)
    {
        _peopleRepository = peopleRepository;
    }

    public Person? GetByName(string firstName, string lastName)
    {
        return _cache.Get(
            (firstName, lastName),
            () => _peopleRepository
                .GetByName(firstName, lastName)
                .FirstOrDefault());
    }

    private readonly MemoryCache _memoryCache =
        new MemoryCache(new MemoryCacheOptions());

    //alternatively we can use the Microsoft's MemotyCache
    public Person? GetByNameMemoryCache(string firstName, string lastName)
    {
        return _memoryCache.GetOrCreate(
            (firstName, lastName),
            cacheEntry => _peopleRepository
                .GetByName(firstName, lastName)
                .FirstOrDefault());
    }
}

internal interface IRepository<T>
{
    IEnumerable<Person> GetByName(string firstName, string lastName);
}

record Person(string FirstName, string LastName);

class PeopleRepositoryMock : IRepository<Person>
{
    public IEnumerable<Person> GetByName(string firstName, string lastName)
    {
        if (firstName == "John" && lastName == "Smith")
        {
            return new[] { new Person("John", "Smith") };
        }
        throw new NotImplementedException();
    }
}