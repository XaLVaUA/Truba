using Truba.Core;

namespace Truba.Tests;

[TestClass]
public sealed class ExtensionsTests
{
    [TestMethod]
    public void PipeInstance_Value_ReturnsValue()
    {
        const int expectedValue = 1337;
        var pipe = new Pipe<int>(expectedValue);
        var actualValue = pipe.Value();
        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public void Pipe_Value_ReturnsCorrectValue()
    {
        const int expectedValue = 1337;
        var pipe = expectedValue.Pipe();
        var actualValue = pipe.Value;
        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public void Pipe_SeveralMethods_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        const int initialValue = 1337;

        var pipe =
            initialValue
                .Pipe()
                .Pipe(Add5)
                .Pipe(WithLabel)
                .Pipe(str => str.ToUpper());

        var actualValue = pipe.Value();

        Assert.AreEqual(expectedValue, actualValue);

        return;

        static int Add5(int value) => value + 5;
        static string WithLabel(int value) => $"label: {value}".ToUpper();
    }
}
