namespace Truba.Core;

public static class Logic
{
    public static TResult Pipe<TArgument, TResult>(TArgument argument, Func<TArgument, TResult> func) =>
        func(argument);
}
