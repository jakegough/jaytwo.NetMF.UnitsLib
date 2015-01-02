set MSBUILD_EXE=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe
set NUGET_EXE=nuget.exe
set NUGET_PROJECT=..\UnitsLib\UnitsLib.csproj
set NUGET_CONFIGURATION=Release
set NUGET_NUPKG=jaytwo.NetMF.UnitsLib.*.nupkg
set NUGET_API_KEY=

call NuGet-Settings.private.cmd