@echo off
set msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
echo Building PlovdivTournament.Entities

%msbuild% src\PlovdivTournament.Entities\PlovdivTournament.Entities.csproj /verbosity:Normal
set BUILD_STATUS=%ERRORLEVEL% 
if %BUILD_STATUS%==0 goto DbCreation
if not %BUILD_STATUS%==0 goto fail 
 
:DbCreation
echo PlovdivTournament.Entities Built
echo Building database creation tool

%msbuild%  Tools\PlovdivTournament.Tools.DatabaseTool\PlovdivTournament.Tools.DatabaseTool.csproj  /verbosity:Normal

set BUILD_STATUS=%ERRORLEVEL% 
if %BUILD_STATUS%==0 goto RunDbCreation
if not %BUILD_STATUS%==0 goto fail 

:RunDbCreation
echo Building database creation tool finished
echo Running Database Creation Tool

call lib\Compile\PlovdivTournament.Tools.DatabaseTool\MyPhoto.Tools.DatabaseTool.exe

set BUILD_STATUS=%ERRORLEVEL% 
if %BUILD_STATUS%==0 goto end
if not %BUILD_STATUS%==0 goto fail 


:fail 
set /p id="ERROR" %=%
exit /b 1 
 
:end 
set /p id="Success " %=%
exit /b 0 