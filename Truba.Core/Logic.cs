namespace Truba.Core;

public static class Logic
{
    public static TResult Pipe<TArgument, TResult>(TArgument argument, Func<TArgument, TResult> func) =>
        func(argument);

    public static async Task<TResult> PipeAsync<TArgument, TResult>(Task<TArgument> argumentTask, Func<TArgument, Task<TResult>> funcAsync) =>
        await funcAsync(await argumentTask);

    public static Pipe<TResult> PipeV<TArgument, TResult>(TArgument argument, Func<TArgument, TResult> func) =>
        new(() => func(argument));

    public static Pipe<TResult> PipeD<TArgument, TResult>(Pipe<TArgument> argumentPipe, Func<TArgument, TResult> func) =>
        new(() => func(argumentPipe.Func()));

    public static T PipeR<T>(Pipe<T> pipe) =>
        pipe.Func();

    public static AsyncPipe<TResult> PipeVAsync<TArgument, TResult>(Task<TArgument> argumentTask, Func<TArgument, Task<TResult>> funcAsync) =>
        new(async () => await funcAsync(await argumentTask));

    public static AsyncPipe<TResult> PipeDAsync<TArgument, TResult>(AsyncPipe<TArgument> argumentPipe, Func<TArgument, Task<TResult>> funcAsync) =>
        new(async () => await funcAsync(await argumentPipe.FuncAsync()));

    public static Task<T> PipeRAsync<T>(AsyncPipe<T> pipe) =>
        pipe.FuncAsync();
}
