namespace Truba.Core;

public static class Extensions
{
    public static TResult Pipe<TArgument, TResult>(this TArgument argument, Func<TArgument, TResult> func) => 
        Logic.Pipe(argument, func);
}
