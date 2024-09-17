#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UberSystem.Api.Driver/UberSystem.Api.Driver.csproj", "UberSystem.Api.Driver/"]
RUN dotnet restore "UberSystem.Api.Driver/UberSystem.Api.Driver.csproj"
COPY . .
WORKDIR "/src/UberSystem.Api.Driver"
RUN dotnet build "UberSystem.Api.Driver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UberSystem.Api.Driver.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UberSystem.Api.Driver.dll"]
