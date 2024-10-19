namespace BlazingBudget.TUnitTesting.Tests;

/// <summary>
/// https://github.com/thomhurst/TUnit
/// </summary>
public class TUnitTests
{
    [Test]
    public async Task TestMethod1()
    {
        var result = Add(1, 2);
        await Assert.That(result).IsEqualTo(3);
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}
