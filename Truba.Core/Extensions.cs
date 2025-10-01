namespace Truba.Core;

public static class Extensions
{
    public static TResult Pipe<TArgument, TResult>(this TArgument argument, Func<TArgument, TResult> func) => 
        Logic.Pipe(argument, func);

    public static Task<TResult> PipeAsync<TArgument, TResult>(this Task<TArgument> argumentTask, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.PipeAsync(argumentTask, funcAsync);

    public static Pipe<TResult> PipeV<TArgument, TResult>(this TArgument argument, Func<TArgument, TResult> func) => 
        Logic.PipeV(argument, func);

    public static Pipe<TResult> PipeD<TArgument, TResult>(this Pipe<TArgument> argumentPipe, Func<TArgument, TResult> func) =>
        Logic.PipeD(argumentPipe, func);

    public static T PipeR<T>(this Pipe<T> pipe) =>
        Logic.PipeR(pipe);

    public static AsyncPipe<TResult> PipeVAsync<TArgument, TResult>(this Task<TArgument> argumentTask, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.PipeVAsync(argumentTask, funcAsync);

    public static AsyncPipe<TResult> PipeDAsync<TArgument, TResult>(this AsyncPipe<TArgument> argumentPipe, Func<TArgument, Task<TResult>> funcAsync) =>
        Logic.PipeDAsync(argumentPipe, funcAsync);

    public static Task<T> PipeRAsync<T>(this AsyncPipe<T> pipe) =>
        Logic.PipeRAsync(pipe);
}
