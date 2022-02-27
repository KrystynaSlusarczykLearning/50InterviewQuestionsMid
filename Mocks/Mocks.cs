using Moq;
using NUnit.Framework;

namespace Mocks
{
    //public class Program
    //{
    //    //in production code we would use a real DatabasePeopleDataReader
    //    //in tests, we will use mock
    //    //(this code is commented as the type of this project is class library,
    //    //not the Console Application

    //    public static void Main(string[] args)
    //    {
    //        var personalDataFormatter = new PersonalDataFormatter(
    //            new DatabasePeopleDataReader());

    //        Console.WriteLine(personalDataFormatter.Format());

    //    var enthusiasticGreeter = new EnthusiasticGreeter(
    //        message => Console.WriteLine(message));

    //    enthusiasticGreeter.PrintHelloNTimes(5);

    //        Console.ReadKey();
    //    }
    //}

    public class EnthusiasticGreeter
    {
        readonly Action<string> _printToConsole;

        public EnthusiasticGreeter(Action<string> printToConsole)
        {
            _printToConsole = printToConsole;
        }

        public void PrintHelloNTimes(int n)
        {
            for(int i = 0; i < n; i++)
            {
                _printToConsole("Hello!");
            }
        }
    }

    [TestFixture]
    public class EnthusiasticGreeterTests
    {
        private Mock<Action<string>> _printToConsoleMock;
        private EnthusiasticGreeter _cut;

        [SetUp]
        public void SetUp()
        {
            _printToConsoleMock = new Mock<Action<string>>();
            _cut = new EnthusiasticGreeter(
                _printToConsoleMock.Object);
        }

        [Test]
        public void ShallPrintHello5Times_WhenCalledPrintHello5Times()
        {
            _cut.PrintHelloNTimes(5);
            _printToConsoleMock.Verify(
                mock => mock("Hello!"), Times.Exactly(5));
        }
    }

    [TestFixture]
    public class PersonalDataFormatterTests
    {
        private Mock<IPeopleDataReader> _peopleDataReaderMock;
        private PersonalDataFormatter _cut;

        [SetUp]
        public void SetUp()
        {
            _peopleDataReaderMock = new Mock<IPeopleDataReader>();
            _cut = new PersonalDataFormatter(
                _peopleDataReaderMock.Object);
        }

        [Test]
        public void ShallFormatPersonalDataCorrectly()
        {
            _peopleDataReaderMock.Setup(mock => mock.ReadPeople())
                .Returns(new List<Person>
                    {
                        new Person("Person1", 1982, "Country1"),
                        new Person("Person2", 1992, "Country2"),
                        new Person("Person3", 1954, "Country3"),
                    });

            var result = _cut.Format();
            var expectedResult = @"Person1 born in Country1 on 1982
Person2 born in Country2 on 1992
Person3 born in Country3 on 1954";
            Assert.AreEqual(expectedResult, result);
        }
    }

    class PersonalDataFormatter
    {
        private readonly IPeopleDataReader _peopleDataReader;

        public PersonalDataFormatter(
            IPeopleDataReader peopleDataReader)
        {
            _peopleDataReader = peopleDataReader;
        }

        public string Format()
        {
            var people = _peopleDataReader.ReadPeople();
            return string.Join(Environment.NewLine,
                people.Select(p => $"{p.Name} born in" +
                $" {p.Country} on {p.YearOfBirth}"));
        }
    }

    public interface IPeopleDataReader
    {
        IEnumerable<Person> ReadPeople();
    }

    public class DatabasePeopleDataReader : IPeopleDataReader
    {
        public IEnumerable<Person> ReadPeople()
        {
            Console.WriteLine("Reading from real database");
            return new List<Person>
            {
                new Person("John", 1982, "USA"),
                new Person("Aja", 1992, "India"),
                new Person("Tom", 1954, "Australia"),
            };
        }
    }

    public record Person(string Name, int YearOfBirth, string Country);
}