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

    [TestMethod]
    public async Task PipeAsync_ChainMethods_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        var initialValue = Task.FromResult(1337);

        var actualValue =
            await initialValue
                .PipeAsync(Add5Async)
                .PipeAsync(WithLabelAsync)
                .PipeAsync(static str => Task.FromResult(str.ToUpper()));

        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public void PipeVD_ChainMethods_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        const int initialValue = 1337;

        var actualValue =
            initialValue
                .PipeV(Add5)
                .PipeD(WithLabel)
                .PipeD(static str => str.ToUpper())
                .PipeR();

        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public async Task PipeVDAsync_ChainMethods_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        var initialValue = Task.FromResult(1337);

        var actualValue =
            await initialValue
                .PipeVAsync(Add5Async)
                .PipeDAsync(WithLabelAsync)
                .PipeDAsync(static str => Task.FromResult(str.ToUpper()))
                .PipeRAsync();

        Assert.AreEqual(expectedValue, actualValue);
    }

    private static int Add5(int value) => value + 5;

    private static string WithLabel(int value) => $"label: {value}".ToUpper();

    private static Task<int> Add5Async(int value) => Task.FromResult(Add5(value));

    private static Task<string> WithLabelAsync(int value) => Task.FromResult(WithLabel(value));
}
