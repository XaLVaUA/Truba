using Truba.Core;

namespace Truba.Tests;

[TestClass]
public sealed class ExtensionsTests
{
    [TestMethod]
    public void Pipe_ChainMethods_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        const int initialValue = 1337;

        var actualValue =
            initialValue
                .Pipe(Add5)
                .Pipe(WithLabel)
                .Pipe(static str => str.ToUpper());

        Assert.AreEqual(expectedValue, actualValue);
    }

    private static int Add5(int value) => value + 5;

    private static string WithLabel(int value) => $"label: {value}".ToUpper();
}
