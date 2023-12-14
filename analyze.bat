@echo off
dotnet sonarscanner begin /k:"Shop" /d:sonar.token="%SONAR_TOKEN%"
dotnet build
dotnet sonarscanner end /d:sonar.token="%SONAR_TOKEN%"
