# stay-awake

Keep a Windows computer awake using the [win32 API](https://docs.microsoft.com/en-us/windows/win32/apiindex/windows-api-list).

## Reason for Development

- [x] Experiment with [DragonFruit](https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview) console app in [C#](https://docs.microsoft.com/en-us/dotnet/csharp/). 
- [ ] Experiment with [System.CommandLine](https://github.com/dotnet/command-line-api/wiki/Your-first-app-with-System.CommandLine) console app in [C#](https://docs.microsoft.com/en-us/dotnet/csharp/).

Other planned experiments include:

#### Explore [.NET Core 3](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0) features
- [x] [Single file executable](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables)
- [x] [Assembly linking](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking)
- [ ] [ReadyToRun](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#readytorun-images)

#### Distribution
- [ ] [.NET Core global tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools)
- [ ] [Nuget](https://www.nuget.org/)
- [ ] [Github Package Registry](https://help.github.com/en/github/managing-packages-with-github-package-registry/configuring-nuget-for-use-with-github-package-registry)

#### Building
- [ ] [Azure Dev Ops](https://azure.microsoft.com/en-us/services/devops/)
- [ ] [Cross compiling](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)


## Colophon

### Requirements
Built with [.NET Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0).

Version information compiled using [versions.ps1](https://github.com/curtisalexander/stay-awake/blob/master/versions.ps1) script.

```
Windows version: 10.0.19013.0

dotnet core version: 3.1.100-preview2-014569

Package versions:
Project 'stay-awake' has the following package references
   [netcoreapp3.1]:
   Top-level Package                     Requested
 Resolved
   > System.CommandLine.DragonFruit      0.3.0-alpha.19405.1   0.3.0-alpha.19405.1
```

### Initial Setup

Create a new project.

```pwsh
dotnet new console -o stay-awake
```

Add dependency for [System.CommandLine.DragonFruit](https://www.nuget.org/packages/System.CommandLine.DragonFruit).

```pwsh
dotnet add package System.CommandLine.DragonFruit --version 0.3.0-alpha.19405.1
```

### Build, Run, Test

#### Build

```pwsh
dotnet build
```

#### Run

```pwsh
# Help 
dotnet run -- --help

# Keep display on
dotnet run -- --awake-mode Display
```

#### Test

In order to test, open PowerShell with elevated (admin) privleges.  After executing the program, run the following.

```pwsh
powercfg -requests
```

#### Publish

For a single file exe, add the following to the `stay-awake.csproj` file.

```xml
<PropertyGroup>
    <RuntimeIdentifier>win10-x64</RuntimeIdentifier>
    <PublishSingleFile>true</PublishSingleFile>
</PropertyGroup>
```

For assembly linking, add the following to the `stay-awake.csproj` file.

```xml
<PropertyGroup>
   <PublishTrimmed>true</PublishTrimmed>
</PropertyGroup>
```

For a ReadyToRun image, add the following to the `stay-awake.csproj` file.

```xml
<PropertyGroup>
  <PublishReadyToRun>true</PublishReadyToRun>
</PropertyGroup>
```

To publish, run the following.

```pwsh
dotnet publish -c Release
```

To test the exe, run the following.

```pwsh
.\bin\Release\netcoreapp3.1\win10-x64\stay-awake.exe --help
```

Finally, to check the size of the exe, run the following.

```pwsh
# In KB
(Get-ChildItem -File .\bin\Release\netcoreapp3.1\win10-x64\stay-awake.exe).Length/1KB

# In MB
(Get-ChildItem -File .\bin\Release\netcoreapp3.1\win10-x64\stay-awake.exe).Length/1MB
```

### References
- `System.CommandLine.DragonFruit`
    - [Hanselman blog post](https://www.hanselman.com/blog/DragonFruitAndSystemCommandLineIsANewWayToThinkAboutNETConsoleApps.aspx)
    - [DragonFruit Wiki](https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview)
- `SetThreadExecutionState`
    - [pinvoke.NET for SetThreadExecutionState](https://www.pinvoke.net/default.aspx/kernel32/SetThreadExecutionState.html)
    - [win32 API for SetThreadExecutionState](https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadexecutionstate?redirectedfrom=MSDN)
    - [Platform Invoke Example](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interop/how-to-use-platform-invoke-to-play-a-wave-file)
