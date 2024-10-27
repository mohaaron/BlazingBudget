namespace BlazingBudget.TUnitTesting.Tests;

/// <summary>
/// https://github.com/thomhurst/TUnit
/// </summary>
public class TUnitTests
{
	private int standardValue = 1;

	[Before(Test)]
	public async Task BeforeEachTest()
	{
		if (standardValue != 1)
		{
			standardValue = 1;
		}

		await Task.CompletedTask;
	}

    [Test]
    public async Task TestMethod1()
    {
        int result = Add(standardValue, 2);
		_ = await Assert.That(result).IsEqualTo(3);
    }

	[Test]
	public async Task TestMethod2()
	{
		standardValue = 2;
		int result = Add(standardValue, 2);
		_ = await Assert.That(result).IsEqualTo(4);
	}

	[Test]
	public async Task TestMethod3()
	{
		standardValue = 3;
		int result = Add(standardValue, 2);
		_ = await Assert.That(result).IsEqualTo(5);
	}

	private int Add(int x, int y) => x + y;
}
