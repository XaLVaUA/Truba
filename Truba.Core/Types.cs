namespace Truba.Core;

public record struct Pipe<T>(T Value);

public record struct AsyncPipe<T>(Task<T> Value);
