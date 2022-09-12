
set msBuildDir="C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\msbuild.exe"
REM package module


call %msBuildDir% /target:PackageModule ..\BtbTweet.csproj

set msBuildDir=
pause