@echo off
dotnet sonarscanner begin /k:"Shop" /d:sonar.token="%SONAR_TOKEN%" || exit /b 1
dotnet build || exit /b 1
dotnet sonarscanner end /d:sonar.token="%SONAR_TOKEN%" || exit /b 1
echo Done
