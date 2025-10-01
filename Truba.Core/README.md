# Truba.Core

A lightweight C# library for method piping, enabling fluent and functional-style programming.

## Installation

Install the `Truba.Core` package via NuGet:

```bash
dotnet add package Truba.Core
```

Or use the NuGet Package Manager in Visual Studio to search for `Truba.Core`.

## Usage

Chain operations on a value using `Pipe`:

```csharp
using Truba.Core;

var result =
    value
        .Pipe(Add5)
        .Pipe(WithLabel)
        .Pipe(static str => str.ToUpper());
```

Chain operations on a async value using `PipeAsync`:

```csharp
using Truba.Core;

var result =
    await initialValue
        .PipeAsync(Add5Async)
        .PipeAsync(WithLabelAsync)
        .PipeAsync(static str => Task.FromResult(str.ToUpper()));
```

Chain deferred operations on a value using `PipeV`, `PipeD` and `PipeR`:

```csharp
using Truba.Core;

var result =
    initialValue
        .PipeV(Add5)
        .PipeD(WithLabel)
        .PipeD(static str => str.ToUpper())
        .PipeR();
```

Chain deferred operations on a async value using `PipeVAsync`, `PipeDAsync` and `PipeRAsync`:

```csharp
using Truba.Core;

var result =
    await initialValue
        .PipeVAsync(Add5Async)
        .PipeDAsync(WithLabelAsync)
        .PipeDAsync(static str => Task.FromResult(str.ToUpper()))
        .PipeRAsync();
```

## License

This project is dedicated to the public domain under the Unlicense. See the [LICENSE](LICENSE) file for details.
