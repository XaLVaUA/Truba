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
        var pipe = expectedValue.PipeV();
        var actualValue = pipe.Value;
        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public void Pipe_ChainMethods_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        const int initialValue = 1337;

        var pipe =
            initialValue
                .PipeV()
                .PipeF(Add5)
                .PipeF(WithLabel)
                .PipeF(str => str.ToUpper());

        var actualValue = pipe.Value();

        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public void Pipe_ChainMethodsWithInitial_ReturnsCorrectValue()
    {
        const string expectedValue = "LABEL: 1342";
        const int initialValue = 1337;

        var pipe =
            initialValue
                .PipeV(Add5)
                .PipeF(WithLabel)
                .PipeF(str => str.ToUpper());

        var actualValue = pipe.Value();

        Assert.AreEqual(expectedValue, actualValue);
    }

    [TestMethod]
    public async Task AsyncPipeInstance_Value_ReturnsValue()
    {
        var expectedValue = Task.FromResult(1337);
        var pipe = new AsyncPipe<int>(expectedValue);
        var actualValue = pipe.Value();
        Assert.AreEqual(await expectedValue, await actualValue);
    }

    [TestMethod]
    public async Task AsyncPipe_Value_ReturnsCorrectValue()
    {
        var expectedValue = Task.FromResult(1337);
        var pipe = expectedValue.PipeVAsync();
        var actualValue = pipe.Value;
        Assert.AreEqual(await expectedValue, await actualValue);
    }

    [TestMethod]
    public async Task AsyncPipe_ChainMethods_ReturnsCorrectValue()
    {
        var expectedValue = Task.FromResult("LABEL: 1342");
        var initialValue = Task.FromResult(1337);

        var pipe =
            initialValue
                .PipeVAsync()
                .PipeFAsync(Add5Async)
                .PipeFAsync(WithLabelAsync)
                .PipeFAsync(str => Task.FromResult(str.ToUpper()));

        var actualValue = pipe.Value();

        Assert.AreEqual(await expectedValue, await actualValue);
    }

    [TestMethod]
    public async Task AsyncPipe_ChainMethodsWithInitial_ReturnsCorrectValue()
    {
        var expectedValue = Task.FromResult("LABEL: 1342");
        var initialValue = Task.FromResult(1337);

        var pipe =
            initialValue
                .PipeVAsync(Add5Async)
                .PipeFAsync(WithLabelAsync)
                .PipeFAsync(str => Task.FromResult(str.ToUpper()));

        var actualValue = pipe.Value();

        Assert.AreEqual(await expectedValue, await actualValue);
    }

    [TestMethod]
    public async Task AsyncPipe_ChainMethodsFromInitial_ReturnsCorrectValue()
    {
        var expectedValue = Task.FromResult("LABEL: 1342");
        const int initialValue = 1337;

        var pipe =
            initialValue
                .PipeFAsync(Add5Async)
                .PipeFAsync(WithLabelAsync)
                .PipeFAsync(str => Task.FromResult(str.ToUpper()));

        var actualValue = pipe.Value();

        Assert.AreEqual(await expectedValue, await actualValue);
    }

    [TestMethod]
    public async Task AsyncPipe_ChainMethodsFromPipe_ReturnsCorrectValue()
    {
        var expectedValue = Task.FromResult("LABEL: 1342");
        const int initialValue = 1337;

        var pipe =
            initialValue
                .PipeV(Add5)
                .PipeFAsync(WithLabelAsync)
                .PipeFAsync(str => Task.FromResult(str.ToUpper()));

        var actualValue = pipe.Value();

        Assert.AreEqual(await expectedValue, await actualValue);
    }

    private static int Add5(int value) => value + 5;

    private static string WithLabel(int value) => $"label: {value}".ToUpper();

    private static Task<int> Add5Async(int value) => Task.FromResult(Add5(value));

    private static Task<string> WithLabelAsync(int value) => Task.FromResult(WithLabel(value));
}
