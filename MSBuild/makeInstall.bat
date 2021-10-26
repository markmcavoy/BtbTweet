
set msBuildDir="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\msbuild.exe"
REM package module


call %msBuildDir% /target:PackageModule ..\BtbTweet.csproj

set msBuildDir=
pause