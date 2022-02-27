var currencies = new Dictionary<string, string>();
currencies["USA"] = "USD";
currencies["Japan"] = "JPY";
currencies["Brazil"] = "BRL";

var currenciesValuesComparedToDollar = new Dictionary<string, decimal>();
currenciesValuesComparedToDollar.Add("USD", 1m);
currenciesValuesComparedToDollar.Add("JPY", 0.0086m);
currenciesValuesComparedToDollar.Add("BRL", 0.18m);
//Dictionary keys must be unique, so the below line will throw an exception
//currenciesValuesComparedToDollar.Add("BRL", 0.18m);

currenciesValuesComparedToDollar["BRL"] = 0.19m; //this will update the value

var savedGames = new Dictionary<string, string>
{
    ["save1"] = @"C:/saves/save1.dat",
    ["autosave"] = @"C:/saves/auto/save.dat",
    ["beforeBossFight"] = @"C:/saves/beforeBossFight.dat",
};

var employees = new List<Employee>
{
    new Employee(Department.Xenobiology, 15000),
    new Employee(Department.MissionControl, 10000),
    new Employee(Department.PlanetTerraforming, 9000),
    new Employee(Department.PlanetTerraforming, 8000),
    new Employee(Department.MissionControl, 11000),
    new Employee(Department.MissionControl, 12000),
};

//let's build a mapping from the department to the average
//salary in this department
Dictionary<Department, decimal> departmentsAverageSalaries =
    employees
    .GroupBy(e => e.Department)
    .ToDictionary(
        grouping => grouping.Key,
        grouping => grouping.Average(g => g.Salary));

foreach (var departmentsAverageSalary in departmentsAverageSalaries)
{
    Console.WriteLine($"{departmentsAverageSalary.Key}: {departmentsAverageSalary.Value}");
}

Console.ReadKey();

record Employee(Department Department, decimal Salary);
enum Department { MissionControl, Xenobiology, PlanetTerraforming }