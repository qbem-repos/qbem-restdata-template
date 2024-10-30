##TODO: melhorar este script powershell.
## Gerando o pacote do nuget.
Write-Output "Download nuget.exe from $nugetUrl"
Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/v5.9.1/nuget.exe" -OutFile nuget.exe

.\nuget.exe pack .\.nuspec -OutputDirectory .\dist\ -NoDefaultExcludes

## Instalando o template localmente
dotnet new install .\ --force

## Desistalando o template localmente
#dotnet new uninstall .\ProjectBase\

## Realizando push para o nuget
..\.github\ConfigurarGithubCredentialsWindows.ps1
dotnet nuget push .\dist\Qbem.RestData.WebApi.1.0.0.nupkg -k $env:PERSONAL_ACCESS_TOKEN_GITHUB -s https://nuget.pkg.github.com/qbem-repos/index.json 
