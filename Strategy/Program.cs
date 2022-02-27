var games = new List<Game>
{
    new Game(
        "Stardew Valley", 19.99m, 98, 
        new DateTime(2016, 2, 26), true),
    new Game(
        "Red Dead Redemption II", 60m, 92,
        new DateTime(2018, 10, 26), true),
    new Game(
        "Spiritfarer", 25m, 95,
        new DateTime(2020, 8, 18), false),
    new Game(
        "Heroes III", 10m, 82,
        new DateTime(1999, 3, 3), false),
    new Game(
        "God of War", 60m, 97,
        new DateTime(2018, 4, 20), true),

};

var selectedOption = FilteringType.BestGames;
var searchWord = "Red";

//Code without strategy pattern

//IEnumerable<Game> filteredGames = null;
//switch (selectedOption)
//{
//    case FilteringType.ByTitle:
//        filteredGames = FindByTitle(games, searchWord);
//        break;
//    case FilteringType.BestGames:
//        filteredGames = FindBestGames(games);
//        break;
//    case FilteringType.GamesOfThisYear:
//        filteredGames = FindGamesOfThisYear(games);
//        break;
//    case FilteringType.BestDeals:
//        filteredGames = FindBestDeals(games);
//        break;
//}

var strategy = SelectStrategy(selectedOption, searchWord);

var filteredGames = FindBy(strategy, games);
foreach (var game in filteredGames)
{
    Console.WriteLine(game);
}

Console.ReadKey();

Func<Game,bool> SelectStrategy(
    FilteringType selectedOption, string searchWord)
{
    switch (selectedOption)
    {
        case FilteringType.ByTitle:
            return game => game.Title.Contains(searchWord);
        case FilteringType.BestGames:
            return game => game.Rating > 95;
        case FilteringType.GamesOfThisYear:
            return game => game.ReleaseDate.Year ==
                DateTime.Now.Year;
        case FilteringType.BestDeals:
            return game => game.Price < 25;
        default:
            throw new ArgumentException("Invalid option");
    }
}

IEnumerable<Game> FindByTitle(
    IEnumerable<Game> games,
    string searchWord)
{
    return games.Where(g => g.IsAvailable &&
    g.Title.Contains(searchWord));
}

IEnumerable<Game> FindBestGames(
    IEnumerable<Game> games)
{
    return games.Where(g => g.IsAvailable &&
    g.Rating > 95);
}

IEnumerable<Game> FindGamesOfThisYear(
    IEnumerable<Game> games)
{
    return games.Where(g => g.IsAvailable &&
    g.ReleaseDate.Year == DateTime.Now.Year);
}

IEnumerable<Game> FindBestDeals(
    IEnumerable<Game> games)
{
    return games.Where(g => g.IsAvailable &&
    g.Price < 25);
}

IEnumerable<Game> FindBy(
    Func<Game, bool> strategy, 
    IEnumerable<Game> games)
{
    return games.Where(g => g.IsAvailable && strategy(g));
}

record Game(
    string Title, 
    decimal Price, 
    decimal Rating, 
    DateTime ReleaseDate,
    bool IsAvailable);

enum FilteringType
{
    ByTitle,
    BestGames,
    GamesOfThisYear,
    BestDeals
}