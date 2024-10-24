namespace BlazingBudget.TUnitTesting.Tests;

/// <summary>
/// https://github.com/thomhurst/TUnit
/// </summary>
public class TUnitTests
{
    [Test]
    public async Task TestMethod1()
    {
        int result = Add(1, 2);
		_ = await Assert.That(result).IsEqualTo(3);
    }

	private int Add(int x, int y) => x + y;
}
