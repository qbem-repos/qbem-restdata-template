#TODO: configurar para um imagem base (REGISTRY QBEM) para .NET CORE 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app

#TODO: configurar para um imagem base (REGISTRY QBEM) para .NET CORE 8
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Debug
ARG USERNAME_GITHUB
ARG PERSONAL_ACCESS_TOKEN_GITHUB
WORKDIR /source
COPY ./Nuget.Config ./Nuget.Config
RUN dotnet nuget update source "Github" --username $USERNAME_GITHUB --password $PERSONAL_ACCESS_TOKEN_GITHUB --configfile ./Nuget.Config --store-password-in-clear-text
COPY ["./src/DomainNames.RestData", "./src/DomainNames.RestData/"]
RUN dotnet restore "./src/DomainNames.RestData/DomainNames.RestData.csproj" --configfile ./Nuget.Config \
&& dotnet build "./src/DomainNames.RestData/DomainNames.RestData.csproj" --no-restore -c $BUILD_CONFIGURATION

COPY ["./tests/DomainNames.Application.Tests", "./tests/DomainNames.Application.Tests/"]
RUN dotnet restore "./tests/DomainNames.Application.Tests" --configfile ./Nuget.Config \
&& dotnet test "./tests/DomainNames.Application.Tests" --no-restore -c $BUILD_CONFIGURATION

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /source
RUN dotnet publish "./src/DomainNames.RestData/DomainNames.RestData.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true --no-restore -r linux-musl-x64 /p:PublishTrimmed=true /p:PublishSingleFile=true --self-contained true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./DomainNames.RestData"]