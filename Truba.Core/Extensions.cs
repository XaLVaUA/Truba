namespace Truba.Core;

public static class Extensions
{
    public static T Value<T>(this Pipe<T> pipe) => Logic.GetValue(pipe);

    public static Pipe<T> Pipe<T>(this T value) => Logic.GetPipe(value);

    public static Pipe<TResult> Pipe<TArgument, TResult>(this Pipe<TArgument> pipe, Func<TArgument, TResult> func) =>
        Logic.GetPipe(pipe, func);

    public static Pipe<TResult> Pipe<TArgument, TResult>(this TArgument value, Func<TArgument, TResult> func) =>
        Logic.GetPipe(func(value));
}
