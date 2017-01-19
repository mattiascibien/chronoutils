# Chrono Utils [![Build Status](https://travis-ci.org/mattiascibien/chronoutils.svg?branch=develop)](https://travis-ci.org/mattiascibien/chronoutils)

Chrono utils is a library for getting metrics about pieces of .NET Code.

## Usage

To measure a piece of code just wrap that using the `Measure` method of the `Chrono` class:

```csharp
using ChronoUtils;
[...]
void Code()
{
    TimeSpan elapsed = Chrono.Measure(() => 
    {
        LongRunningAction();
        AnotherLongRunningActon();
    });

    Logger.Log(elapsed.ToString("g"));
}
```

If your code is a function returning a value that you need later in the code:

```csharp
using ChronoUtils;
[...]
void Code()
{
    TimeSpan elapsed;
    int val = Chrono.Measure(() => 
    {
        LongRunningAction();
        AnotherLongRunningActon();

        return 5;
    }
    , elapsed);

    Assert(5, val);

    Logger.Log(elapsed.ToString("g"));
}
```