# Windows
Write-Host "`nWindows version: $([System.Environment]::OSVersion.Version.ToString())"

# .NET Core
Write-Host "`ndotnet core version: $(dotnet --version)"

# Packages
Write-Host "`nPackage versions:"
dotnet list stayawake.csproj package
