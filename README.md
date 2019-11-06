# stayawake

## Background
Keep a Windows Computer awake akin to [Amphetamine](https://apps.apple.com/us/app/amphetamine/id937984704?mt=12).

Originally inspired by [this gist](https://gist.github.com/CMCDragonkai/bf8e8b7553c48e4f65124bc6f41769eb).


## Colophon

### Requirements
Built with [.NET Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)


### Setup

Create a new project.

```sh
dotnet new console -o stayawake
```

Add dependency.

```sh
dotnet add package System.CommandLine.DragonFruit --version 0.3.0-alpha.19405.1
```

Add `System.CommandLine.DragonFruit` within `Program.cs`.

```cs
using System.CommandLine.DragonFruit;
```

Build.

```
dotnet build
```

Test.

```
dotnet run -- --verbose --flavor "chocolate" --count 4
```

### References
- [Hanselman blog post](https://www.hanselman.com/blog/DragonFruitAndSystemCommandLineIsANewWayToThinkAboutNETConsoleApps.aspx)
- [Platform Invoke Example](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interop/how-to-use-platform-invoke-to-play-a-wave-file)
- [pinvoke.NET for SetThreadExecutionState](https://www.pinvoke.net/default.aspx/kernel32/SetThreadExecutionState.html)
- [win32 API for SetThreadExecutionState](https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadexecutionstate?redirectedfrom=MSDN)
