# Truba

A lightweight C# library for method piping, enabling fluent and functional-style programming. The `Pipe<T>` and `AsyncPipe<T>` structs, along with their extension methods, allow you to chain operations on values or tasks in a readable, composable way, inspired by functional programming pipelines. This library simplifies complex transformations and enhances code clarity with both synchronous and asynchronous workflows.

## Installation

Install the `Truba` package via NuGet:

```bash
dotnet add package Truba.Core
```

Or use the NuGet Package Manager in Visual Studio to search for `Truba.Core`.

## Usage

The `Truba` library provides `Pipe<T>` and `AsyncPipe<T>` structs with extension methods to enable fluent method chaining for synchronous and asynchronous operations. Below are examples demonstrating their usage, using `PipeV`, `PipeF`, `PipeVAsync`, and `PipeFAsync` with initial transformations to avoid parameterless calls.

### Synchronous Pipeline Example

Chain operations on a value using `PipeV` and `PipeF` with an initial transformation:

```csharp
using Truba.Core;

string result =
    1337
        .PipeV(x => x + 5)
        .PipeF(x => $"label: {x}")
        .PipeF(str => str.ToUpper())
        .Value(); // Returns "LABEL: 1342"
```

### Asynchronous Pipeline Example

Chain asynchronous operations using `PipeVAsync` and `PipeFAsync` with an initial transformation:

```csharp
using Truba.Core;

async Task<string> TransformAsync()
{
    return await Task.FromResult(1337)
        .PipeVAsync(x => Task.FromResult(x + 5))
        .PipeFAsync(x => Task.FromResult($"label: {x}"))
        .PipeFAsync(str => Task.FromResult(str.ToUpper()))
        .Value(); // Returns "LABEL: 1342"
}
```

### Mixed Synchronous and Asynchronous Pipeline

Start with a synchronous pipeline and transition to asynchronous operations:

```csharp
using Truba.Core;

async Task<string> TransformAsync()
{
    return await 1337
        .PipeV(x => x + 5)
        .PipeFAsync(x => Task.FromResult($"label: {x}"))
        .PipeFAsync(str => Task.FromResult(str.ToUpper()))
        .Value(); // Returns "LABEL: 1342"
}
```

### Direct Asynchronous Pipeline from Value

Start an asynchronous pipeline directly from a value using `PipeFAsync`:

```csharp
using Truba.Core;

async Task<string> TransformAsync()
{
    return await 1337
        .PipeFAsync(x => Task.FromResult(x + 5))
        .PipeFAsync(x => Task.FromResult($"label: {x}"))
        .PipeFAsync(str => Task.FromResult(str.ToUpper()))
        .Value(); // Returns "LABEL: 1342"
}
```

## Key Features

- **Synchronous Pipelines**: Use `PipeV` and `PipeF` for fluent, functional-style chaining of operations on values.
- **Asynchronous Pipelines**: Use `PipeVAsync` and `PipeFAsync` for chaining asynchronous operations on `Task<T>` values, with support for starting pipelines directly from values using `PipeFAsync`.
- **Mixed Pipelines**: Seamlessly transition between synchronous and asynchronous operations in a single pipeline.
- **Type Safety**: Generic types ensure compile-time safety for transformations.
- **Lightweight**: Minimal overhead with a focus on simplicity and performance.

## License

This project is dedicated to the public domain under the Unlicense. See the [LICENSE](LICENSE) file for details.