namespace Truba.Core;

public record Pipe<T>(Func<T> Func);

public record AsyncPipe<T>(Func<Task<T>> FuncAsync);
