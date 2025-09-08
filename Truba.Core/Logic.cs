namespace Truba.Core;

public static class Logic
{
    public static T GetValue<T>(Pipe<T> pipe) => pipe.Value;

    public static Pipe<T> GetPipeV<T>(T value) => new(value);

    public static Pipe<TResult> GetPipeF<TArgument, TResult>(Pipe<TArgument> argumentPipe, Func<TArgument, TResult> func) =>
        new(func(GetValue(argumentPipe)));

    public static Pipe<TResult> GetPipeV<TArgument, TResult>(TArgument argument, Func<TArgument, TResult> func) =>
        GetPipeF(GetPipeV(argument), func);

    public static Task<T> GetValue<T>(AsyncPipe<T> asyncPipe) => asyncPipe.Value;

    public static AsyncPipe<T> GetPipeVAsync<T>(Task<T> value) => new(value);

    public static AsyncPipe<TResult> GetPipeFAsync<TArgument, TResult>(TArgument argument, Func<TArgument, Task<TResult>> funcAsync) =>
       GetPipeVAsync(funcAsync(argument));

    public static AsyncPipe<TResult> GetPipeFAsync<TArgument, TResult>(Pipe<TArgument> argumentPipe, Func<TArgument, Task<TResult>> funcAsync) =>
        GetPipeFAsync(GetValue(argumentPipe), funcAsync);

    public static AsyncPipe<TResult> GetPipeFAsync<TArgument, TResult>(AsyncPipe<TArgument> asyncPipe, Func<TArgument, Task<TResult>> funcAsync) =>
        new(BindAsync(GetValue(asyncPipe), funcAsync));

    public static AsyncPipe<TResult> GetPipeVAsync<TArgument, TResult>(Task<TArgument> argument, Func<TArgument, Task<TResult>> funcAsync) =>
        GetPipeFAsync(GetPipeVAsync(argument), funcAsync);

    public static async Task<TResult> BindAsync<TArgument, TResult>(Task<TArgument> argumentTask, Func<TArgument, Task<TResult>> func) =>
        await func(await argumentTask);
}
