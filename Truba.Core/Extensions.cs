namespace Truba.Core;

public static class Extensions
{
    public static T Value<T>(this Pipe<T> pipe) => Logic.GetValue(pipe);

    public static Pipe<T> PipeV<T>(this T value) => Logic.GetPipeV(value);

    public static Pipe<TResult> PipeF<TArgument, TResult>(this Pipe<TArgument> pipe, Func<TArgument, TResult> func) =>
        Logic.GetPipeF(pipe, func);

    public static Pipe<TResult> PipeV<TArgument, TResult>(this TArgument argument, Func<TArgument, TResult> func) =>
        Logic.GetPipeV(argument, func);

    public static Task<T> Value<T>(this AsyncPipe<T> asyncPipe) => Logic.GetValue(asyncPipe);

    public static AsyncPipe<T> PipeVAsync<T>(this Task<T> value) => Logic.GetPipeVAsync(value);

    public static AsyncPipe<TResult> PipeFAsync<TArgument, TResult>(this TArgument argument, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.GetPipeFAsync(argument, funcAsync);

    public static AsyncPipe<TResult> PipeFAsync<TArgument, TResult>(this Pipe<TArgument> argumentPipe, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.GetPipeFAsync(argumentPipe, funcAsync);

    public static AsyncPipe<TResult> PipeFAsync<TArgument, TResult>(this AsyncPipe<TArgument> asyncPipe, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.GetPipeFAsync(asyncPipe, funcAsync);

    public static AsyncPipe<TResult> PipeVAsync<TArgument, TResult>(this Task<TArgument> argument, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.GetPipeVAsync(argument, funcAsync);
}
