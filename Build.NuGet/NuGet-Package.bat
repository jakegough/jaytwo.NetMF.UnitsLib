call NuGet-Settings.cmd

"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Nuget-Clean
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget Net 3.0"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget Net 3.5"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget Net 4.0"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget Net 4.5"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget NetMF 3.0"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget NetMF 4.0"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget NetMF 4.1"
"%MSBUILD_EXE%" %NUGET_PROJECT% /t:Build /p:Configuration="Nuget NetMF 4.2"

"%NUGET_EXE%" pack "%NUGET_PROJECT%" -Verbosity detailed -Build -Properties Configuration="Nuget Net 4.0"

pause