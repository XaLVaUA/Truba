namespace Truba.Core;

public static class Logic
{
    public static T GetValue<T>(Pipe<T> pipe) => pipe.Value;

    public static Pipe<T> GetPipe<T>(T value) => new(value);

    public static Pipe<TResult> GetPipe<TArgument, TResult>(Pipe<TArgument> pipe, Func<TArgument, TResult> func) =>
        new(func(GetValue(pipe)));
}
