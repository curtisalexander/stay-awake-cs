# stayawake

Keep a Windows computer awake using the [win32 API](https://docs.microsoft.com/en-us/windows/win32/apiindex/windows-api-list).

## Reason for Development

Experiment with [DragonFruit](https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview) console app in [C#](https://docs.microsoft.com/en-us/dotnet/csharp/). 

Other planned experiments include:
- Explore [.NET Core 3](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0) features
    - [Single file executable](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables)
    - [Assembly linking](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking)
    - [ReadyToRun](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#readytorun-images)
- Distribution
    - [.NET Core global tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools)
    - [Nuget](https://www.nuget.org/)
    - [Github Package Registry](https://help.github.com/en/github/managing-packages-with-github-package-registry/configuring-nuget-for-use-with-github-package-registry)
- Building
    - [Azure Dev Ops](https://azure.microsoft.com/en-us/services/devops/)
    - [Cross compiling](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)


## Colophon

### Requirements
Built with [.NET Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0).

Version information compiled using [versions.ps1]() script.

```
Windows version: 10.0.19008.0

dotnet core version: 3.1.100-preview1-014459

Package versions:
Project 'stayawake' has the following package references
   [netcoreapp3.1]:
   Top-level Package                     Requested             Resolved
   > System.CommandLine.DragonFruit      0.3.0-alpha.19405.1   0.3.0-alpha.19405.1
```

### Initial Setup

Create a new project.

```sh
dotnet new console -o stayawake
```

Add dependency for [System.CommandLine.DragonFruit](https://www.nuget.org/packages/System.CommandLine.DragonFruit).

```sh
dotnet add package System.CommandLine.DragonFruit --version 0.3.0-alpha.19405.1
```

### Build, Run, Test

#### Build

```sh
dotnet build
```

#### Run

```sh
# Help 
dotnet run -- --help

# Keep display on
dotnet run -- --awake-mode Display
```

#### Test

In order to test, open PowerShell with elevated (admin) privleges.  After executing the program, run the following.

```sh
powercfg -requests
```

### References
- `System.CommandLine.DragonFruit`
    - [Hanselman blog post](https://www.hanselman.com/blog/DragonFruitAndSystemCommandLineIsANewWayToThinkAboutNETConsoleApps.aspx)
    - [DragonFruit Wiki](https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview)
- `SetThreadExecutionState`
    - [pinvoke.NET for SetThreadExecutionState](https://www.pinvoke.net/default.aspx/kernel32/SetThreadExecutionState.html)
    - [win32 API for SetThreadExecutionState](https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadexecutionstate?redirectedfrom=MSDN)
    - [Platform Invoke Example](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interop/how-to-use-platform-invoke-to-play-a-wave-file)
