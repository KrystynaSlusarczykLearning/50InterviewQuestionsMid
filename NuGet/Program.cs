using Moq;
using NUnit.Framework;

Console.ReadKey();

public interface IFlyable
{
    public void Fly();
}

[TestFixture]
public class Tests
{
    private Mock<IFlyable> _flyableMock;
}

