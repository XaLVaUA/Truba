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

## License

This project is dedicated to the public domain under the Unlicense. See the [LICENSE](LICENSE) file for details.
