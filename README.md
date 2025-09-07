# Truba

A lightweight C# library for method piping, enabling fluent and functional-style programming. The `Pipe` struct and extension methods allow you to chain operations on values in a readable, composable way, similar to functional programming pipelines. This library is ideal for simplifying complex transformations and improving code clarity.

## Installation

Install the `Truba` package via NuGet:

```bash
dotnet add package Truba.Core --version 1.0.0
```

Or use the NuGet Package Manager in Visual Studio to search for `Truba.Core`.

## Usage

The `Truba` library provides a `Pipe<T>` struct and extension methods to enable fluent method chaining. Below are some examples to demonstrate how to use it.

### Basic Example

Chain operations on a value using the `Pipe` extension methods:

```csharp
using Truba.Core;

int result =
    1337
        .Pipe()
        .Pipe(x => x + 5)
        .Pipe(x => x * 2)
        .Value(); // Returns 2684
```

### Complex Transformation

Transform an integer into a formatted string with multiple steps:

```csharp
using Truba.Core;

string result =
    1337
        .Pipe()
        .Pipe(x => x + 5)
        .Pipe(x => $"label: {x}")
        .Pipe(str => str.ToUpper())
        .Value(); // Returns "LABEL: 1342"
```

## License

This project is dedicated to the public domain under the Unlicense. See the [LICENSE](LICENSE) file for details.
