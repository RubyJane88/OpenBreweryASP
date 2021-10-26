FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OpenBreweryASP/OpenBreweryASP.csproj", "OpenBreweryASP/"]
RUN dotnet restore "OpenBreweryASP/OpenBreweryASP.csproj"
COPY . .
WORKDIR "/src/OpenBreweryASP"
RUN dotnet build "OpenBreweryASP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenBreweryASP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenBreweryASP.dll"]
